namespace TechnoShop.DTO;

public class PsuWriteDto: ProductWriteDto
{
    public required Guid BrandId { get; set; }
    public required Guid FormFactorId { get; set; }
    
    public int TotalPower_W { get; set; }
    public int Power_3_3_5V_W { get; set; }
    public decimal Power_12V_W { get; set; }

    public decimal Current_5V_A { get; set; }
    public decimal Current_3_3V_A { get; set; }
    public decimal Current_12V1_A { get; set; }
    public decimal Current_minus12V_A { get; set; }
    public decimal Current_5Vsb_A { get; set; }

    public string? MotherboardConnector { get; set; }
    public string? CPUConnector { get; set; }
    public int MolexCount { get; set; }
    public int SATA_Count { get; set; }
    public string? GPUConnector { get; set; }

    public string? InputVoltageRange_V { get; set; }
    public bool APFC { get; set; }
    public string? EfficiencyStandard { get; set; }
    public decimal EfficiencyPercent { get; set; }
    public string? ATXStandard { get; set; }
    public bool ModularCables { get; set; }
    public bool SemiPassiveCooling { get; set; }

    public string? Dimensions_mm { get; set; }
    public int Fan_mm { get; set; }
    public string? Notes { get; set; }
    public string? BrandURL { get; set; }
}