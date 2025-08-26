namespace TechnoShop.DTO;

public class ProcessorReadDto: ProductReadDto
{
    public SocketReadDto? Socket { get; set; }
    public MemoryTypeReadDto? MemoryType { get; set; }
    public ProcessorBrandReadDto? ProcessorBrand { get; set; }

    public decimal BaseFrequencyGHz { get; set; } 
    public decimal MaxFrequencyGHz { get; set; }  
    public int L3CacheMB { get; set; }           
    public int CoresCount { get; set; }          
    public int ThreadsCount { get; set; }        
    public int ProcessNM { get; set; }           
    public int TDP_W { get; set; }               
    
    
    public int MemoryChannels { get; set; }      

    public bool IntegratedGPU { get; set; }      
    public bool HyperThreading { get; set; }     
    public bool UnlockedMultiplier { get; set; } 
    
    public string PackageType { get; set; }      
    public string IncludedCooler { get; set; }   
}