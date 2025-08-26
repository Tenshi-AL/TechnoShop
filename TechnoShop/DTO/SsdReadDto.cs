namespace TechnoShop.DTO;

public class SsdReadDto: ProductReadDto
{
    public SsdBrandReadDto? Brand { get; set; }
    public SsdFormFactorReadDto? FormFactor { get; set; }
    
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