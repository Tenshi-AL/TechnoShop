namespace TechnoShop.DTO;

public class PsuReadDto: ProductReadDto
{
    public PsuBrandReadDto? Brand { get; init; }
    public PsuFormFactorReadDto? FormFactor { get; init; }
    
    public int TotalPower_W { get; init; }
    public int Power_3_3_5V_W { get; init; }
    public decimal Power_12V_W { get; init; }

    public decimal Current_5V_A { get; init; }
    public decimal Current_3_3V_A { get; init; }
    public decimal Current_12V1_A { get; init; }
    public decimal Current_minus12V_A { get; init; }
    public decimal Current_5Vsb_A { get; init; }

    public string? MotherboardConnector { get; init; }
    public string? CPUConnector { get; init; }
    public int MolexCount { get; init; }
    public int SATA_Count { get; init; }
    public string? GPUConnector { get; init; }

    public string? InputVoltageRange_V { get; init; }
    public bool APFC { get; init; }
    public string? EfficiencyStandard { get; init; }
    public decimal EfficiencyPercent { get; init; }
    public string? ATXStandard { get; init; }
    public bool ModularCables { get; init; }
    public bool SemiPassiveCooling { get; init; }

    public string? Dimensions_mm { get; init; }
    public int Fan_mm { get; init; }
    public string? Notes { get; init; }
    public string? BrandURL { get; init; }
}