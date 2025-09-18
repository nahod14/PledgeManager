
using Microsoft.Extensions.Options;
using PledgeManager.Domain;

namespace PledgeManager.Infrastructure;

public sealed class LocalFileStorage : IFileStorage
{
    private readonly AppDbContext _db;
    private readonly string _root;

    public LocalFileStorage(AppDbContext db, IOptions<StorageOptions> options)
    {
        _db = db;
        _root = options.Value.Root;
        if (!Directory.Exists(_root)) Directory.CreateDirectory(_root);
        if (!Directory.Exists(Path.Combine(_root, "uploads"))) Directory.CreateDirectory(Path.Combine(_root, "uploads"));
    }

    public async Task<string> SaveAsync(Stream content, string fileName, string contentType, string ownerType, Guid ownerId)
    {
        var safeName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        var key = Path.Combine("uploads", $"{Guid.NewGuid()}_{safeName}").Replace("\\", "/");
        var fullPath = Path.Combine(_root, key);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        using (var fs = File.Create(fullPath))
        {
            await content.CopyToAsync(fs);
        }

        var blob = new FileBlob
        {
            OwnerType = ownerType,
            OwnerId = ownerId,
            FileName = fileName,
            BlobKey = key,
            ContentType = contentType,
            UploadedAt = DateTime.UtcNow
        };
        _db.FileBlobs.Add(blob);
        await _db.SaveChangesAsync();
        return key;
    }
}
