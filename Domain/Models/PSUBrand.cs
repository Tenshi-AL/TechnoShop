namespace Domain.Models;

public class PSUBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<PSU> Psus { get; set; }
}