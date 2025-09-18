
namespace PledgeManager.Domain;
public sealed class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PledgeId { get; set; }
    public decimal Amount { get; set; }
    public DateOnly PaidOn { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public string Method { get; set; } = "Cash";
    public string? Notes { get; set; }
}
