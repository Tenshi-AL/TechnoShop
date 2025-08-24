using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class MotherboardBrand
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<Motherboard> Motherboards { get; set; }
}