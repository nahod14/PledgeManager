
namespace PledgeManager.Domain;
public sealed class Pledge
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DonorId { get; set; }
    public decimal Amount { get; set; }
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public string Frequency { get; set; } = "OneTime"; // OneTime/Monthly
    public string Status { get; set; } = "Active";     // Active/Overdue/Fulfilled

    public Donor? Donor { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public decimal PaidTotal => Payments.Sum(p => p.Amount);
    public decimal Balance => Amount - PaidTotal;
}
