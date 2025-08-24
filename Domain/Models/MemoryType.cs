namespace Domain.Models;

public class MemoryType
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Processor> Processors { get; set; }
    public ICollection<GPU> Gpus { get; set; }
    public ICollection<RAM> Rams { get; set; }
}