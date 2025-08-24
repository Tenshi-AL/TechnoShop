namespace Domain.Models;

public class RamBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<RAM> Rams { get; set; }
}