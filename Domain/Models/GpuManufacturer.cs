namespace Domain.Models;

public class GpuManufacturer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<GPU> Gpus { get; set; }
}