namespace Domain.Models;

public class SSDFormFactor
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<SSD> Ssds { get; set; }
}