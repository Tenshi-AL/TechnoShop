namespace Domain.Models;

public class MotherboardBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Motherboard> Motherboards { get; set; }
}