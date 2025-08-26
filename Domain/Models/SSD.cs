using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("SSDs")]
public class SSD: Product
{
    public required Guid BrandId { get; set; }
    public SSDBrand? Brand { get; set; }
    
    public required Guid FormFactorId { get; set; }
    public SSDFormFactor? FormFactor { get; set; }
    
    public string? Series { get; set; }
    public int CapacityGB { get; set; }
    public string? Interface { get; set; }
    public string? NANDType { get; set; }
    public bool TRIMSupport { get; set; }
    public string? Dimensions_mm { get; set; }
    public int Weight_g { get; set; }
    public int MaxReadMBs { get; set; }
    public int MaxWriteMBs { get; set; }
    public int TBW { get; set; }
    public decimal MTBF_MillionHours { get; set; }
    public string? BrandURL { get; set; }
}