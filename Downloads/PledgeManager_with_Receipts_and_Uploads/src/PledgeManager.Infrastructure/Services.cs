
namespace PledgeManager.Infrastructure;

public interface IReceiptService
{
    Task<string> GenerateReceiptPdfAsync(Guid paymentId);
}

public interface IFileStorage
{
    Task<string> SaveAsync(Stream content, string fileName, string contentType, string ownerType, Guid ownerId);
}

public sealed class StorageOptions
{
    public string Root { get; set; } = "storage";
}
