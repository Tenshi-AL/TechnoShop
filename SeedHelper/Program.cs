using System.Text.Json;
using Domain.Models;
using Persistence;

var db = new TechnoShopContext();

SeedData<Chipset>("chipset.json");
SeedData<GPUBrand>("gpu_brand.json");
SeedData<GpuManufacturer>("gpu_manufacturer.json");
SeedData<MemoryType>("memory_type.json");
SeedData<GPU>("GPU.json");
SeedData<MotherboardBrand>("MotherboardBrand.json");
SeedData<Socket>("sockets.json");
SeedData<Motherboard>("Motherboard.json");
SeedData<ProcessorBrand>("processorBrand.json");
SeedData<Processor>("processor.json");
SeedData<PSUBrand>("psu_brand.json");
SeedData<PSUFormFactor>("psu_form_factor.json");
SeedData<PSU>("psu.json");
SeedData<RamBrand>("ram_brand.json");
SeedData<RAM>("ram.json");
SeedData<SSDBrand>("ssd_brand.json");
SeedData<SSDFormFactor>("ssd_form_factor.json");
SeedData<SSD>("ssd.json");

void SeedData<T> (string filePath)
{
    var json = File.ReadAllText(filePath);
    var list = JsonSerializer.Deserialize<List<T>>(json);
    if (list is null) Console.WriteLine($"error seed with {filePath} file");
    else
    {
        foreach (var item in list)
            db.Add(item);
        db.SaveChanges();
        Console.WriteLine($"success seed with {filePath} file");
    }
}
