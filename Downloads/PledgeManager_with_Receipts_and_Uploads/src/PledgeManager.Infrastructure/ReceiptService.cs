
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PledgeManager.Domain;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PledgeManager.Infrastructure;

public sealed class ReceiptService : IReceiptService
{
    private readonly AppDbContext _db;
    private readonly string _root;

    public ReceiptService(AppDbContext db, IOptions<StorageOptions> options)
    {
        _db = db;
        _root = options.Value.Root;
        if (!Directory.Exists(_root)) Directory.CreateDirectory(_root);
        if (!Directory.Exists(Path.Combine(_root, "receipts"))) Directory.CreateDirectory(Path.Combine(_root, "receipts"));
    }

    public async Task<string> GenerateReceiptPdfAsync(Guid paymentId)
    {
        var pay = await _db.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        if (pay is null) throw new InvalidOperationException("Payment not found");

        var pledge = await _db.Pledges.Include(p=>p.Donor).FirstAsync(p => p.Id == pay.PledgeId);
        var donor = pledge.Donor!;

        // Build a simple one-page PDF
        var fileName = $"{paymentId}.pdf";
        var fullPath = Path.Combine(_root, "receipts", fileName);

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header().Text("Donation Receipt").SemiBold().FontSize(20);
                page.Content().Column(col =>
                {
                    col.Spacing(10);
                    col.Item().Text($"Donor: {donor.Name} ({donor.Email})");
                    col.Item().Text($"Pledge Amount: {pledge.Amount:C} | Frequency: {pledge.Frequency}");
                    col.Item().Text($"Payment Amount: {pay.Amount:C}");
                    col.Item().Text($"Paid On: {pay.PaidOn:yyyy-MM-dd} | Method: {pay.Method}");
                    col.Item().Text($"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC");
                    col.Item().PaddingTop(10).Text("Thank you for your support!");
                });
                page.Footer().AlignCenter().Text(txt =>
                {
                    txt.Span("PledgeManager • ");
                    txt.Span("This receipt was generated automatically.");
                });
            });
        }).GeneratePdf(fullPath);

        // store metadata record
        var blob = new FileBlob
        {
            OwnerType = "Pledge",
            OwnerId = pledge.Id,
            FileName = fileName,
            BlobKey = Path.Combine("receipts", fileName).Replace("\\", "/"),
            ContentType = "application/pdf",
            UploadedAt = DateTime.UtcNow
        };
        _db.FileBlobs.Add(blob);
        await _db.SaveChangesAsync();

        return blob.BlobKey;
    }
}
