
namespace PledgeManager.Domain;
public sealed class Donor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string? Phone { get; set; }
    public ICollection<Pledge> Pledges { get; set; } = new List<Pledge>();
}
