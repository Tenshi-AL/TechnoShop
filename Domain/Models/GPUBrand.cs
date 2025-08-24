namespace Domain.Models;

public class GPUBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<GPU> Gpus { get; set; }
}