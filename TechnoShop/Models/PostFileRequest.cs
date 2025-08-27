using FluentValidation;
using Persistence;

namespace TechnoShop.Models;

public class PostFileRequest
{
    public required Guid ProductId { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }
}

public class PostFileRequestValidator : AbstractValidator<PostFileRequest>
{
    private const long maxFileSize = 10 * 1024 * 1024;
    private readonly Dictionary<string, List<byte[]>> _fileSignature =
        new Dictionary<string, List<byte[]>>
        {
            {
                ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            {
                ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            {
                ".png", new List<byte[]>
                {
                    new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
                }
            },
            
        };
    
    private readonly TechnoShopContext _context;
    public PostFileRequestValidator(TechnoShopContext context)
    {
        _context = context;

        RuleFor(p => p.ProductId)
            .NotNull()
            .Must(productId => _context.Products.Any(product => product.Id == productId));

        RuleFor(p => p.Files)
            .Must(files => files.All(file =>
            {
                var fileExtension = Path.GetExtension(file.FileName);
                if (!_fileSignature.TryGetValue(fileExtension, out var signatures))
                    return false;

                if (file.Length == 0) return false;
                
                signatures = _fileSignature[fileExtension];
                var maxSignatureLength = signatures.Max(s => s.Length);

                using var stream = file.OpenReadStream();
                using var reader = new BinaryReader(stream);

                var headerBytes = reader.ReadBytes(maxSignatureLength);
                stream.Position = 0; 
                return signatures.Any(signature =>
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            })).WithMessage("Incorrect extension file")
            .Must(files => files.All(file => !(file.Length > maxFileSize)))
            .WithMessage("Image size should be less than 10");
    }
}