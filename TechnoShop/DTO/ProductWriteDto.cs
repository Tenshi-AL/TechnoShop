namespace TechnoShop.DTO;

public class ProductWriteDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required bool InStock { get; init; }
}