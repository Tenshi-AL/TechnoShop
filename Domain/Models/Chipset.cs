namespace Domain.Models;

public class Chipset
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Motherboard> Motherboards { get; set; }
}