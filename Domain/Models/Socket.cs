namespace Domain.Models;

public class Socket
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Processor> Processors { get; set; }
}