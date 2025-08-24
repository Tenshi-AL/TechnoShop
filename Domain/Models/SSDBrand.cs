using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class SSDBrand
{
    public Guid Id { get; set; }
    [MaxLength(50)]public required string Name { get; set; }
    
    public ICollection<SSD> Ssds { get; set; }
}