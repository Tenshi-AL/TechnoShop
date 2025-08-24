using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    [MaxLength(100)]public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required bool InStock { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.Now;
}