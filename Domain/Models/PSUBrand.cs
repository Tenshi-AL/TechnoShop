using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class PSUBrand
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<PSU> Psus { get; set; }
}