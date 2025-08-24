namespace Domain.Models;

public class SSDBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<SSD> Ssds { get; set; }
}