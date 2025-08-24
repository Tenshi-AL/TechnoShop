using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class RamBrand
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<RAM> Rams { get; set; }
}