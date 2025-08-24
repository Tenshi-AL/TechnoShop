using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class GpuManufacturer
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<GPU> Gpus { get; set; }
}