namespace Domain.Models;

public class ProcessorBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Processor> Processors { get; set; }
}