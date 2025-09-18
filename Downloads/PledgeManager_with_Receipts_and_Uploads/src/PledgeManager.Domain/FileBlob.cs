
namespace PledgeManager.Domain;
public sealed class FileBlob
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OwnerType { get; set; } = "Pledge";
    public Guid OwnerId { get; set; }
    public string FileName { get; set; } = "";
    public string BlobKey { get; set; } = "";
    public string ContentType { get; set; } = "application/pdf";
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
