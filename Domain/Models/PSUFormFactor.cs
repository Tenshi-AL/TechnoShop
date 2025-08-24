namespace Domain.Models;

public class PSUFormFactor
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<PSU> Psus { get; set; }
}