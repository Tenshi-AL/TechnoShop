using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ProcessorBrand
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<Processor> Processors { get; set; }
}