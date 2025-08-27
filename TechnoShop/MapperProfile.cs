using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using TechnoShop.DTO;

namespace TechnoShop;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductWriteDto, Product>();
        
        CreateMap(typeof(JsonPatchDocument<ProductWriteDto>), typeof(JsonPatchDocument<Product>));
        CreateMap(typeof(Operation<ProductWriteDto>), typeof(Operation<Product>));
        
        CreateMap<GPUBrand, GpuBrandReadDto>();
        CreateMap<GpuManufacturer, GpuManufacturerReadDto>();
        CreateMap<MemoryType, MemoryTypeReadDto>();
        CreateMap<GPU, GpuReadDto>();
        CreateMap<GpuWriteDto, GPU>();
        
        CreateMap(typeof(JsonPatchDocument<GpuWriteDto>), typeof(JsonPatchDocument<GPU>));
        CreateMap(typeof(Operation<GpuWriteDto>), typeof(Operation<GPU>));

        CreateMap<Socket, SocketReadDto>();
        CreateMap<ProcessorBrand, ProcessorBrandReadDto>();
        CreateMap<Processor, ProcessorReadDto>();
        CreateMap<ProcessorWriteDto, Processor>();
        
        CreateMap(typeof(JsonPatchDocument<ProcessorWriteDto>), typeof(JsonPatchDocument<Processor>));
        CreateMap(typeof(Operation<ProcessorWriteDto>), typeof(Operation<Processor>));

        CreateMap<MotherboardBrand, MotherboardBranReadDto>();
        CreateMap<Chipset, ChipsetReadDto>();
        CreateMap<Motherboard, MotherboardReadDto>();
        CreateMap<MotherboardWriteDto, Motherboard>();
        
        CreateMap(typeof(JsonPatchDocument<MotherboardWriteDto>), typeof(JsonPatchDocument<Motherboard>));
        CreateMap(typeof(Operation<MotherboardWriteDto>), typeof(Operation<Motherboard>));

        CreateMap<PSUFormFactor, PsuFormFactorReadDto>();
        CreateMap<PSUBrand, PsuBrandReadDto>();
        CreateMap<PSU, PsuReadDto>();
        CreateMap<PsuWriteDto, PSU>();
        
        CreateMap(typeof(JsonPatchDocument<PsuWriteDto>), typeof(JsonPatchDocument<PSU>));
        CreateMap(typeof(Operation<PsuWriteDto>), typeof(Operation<PSU>));

        CreateMap<RamBrand, RamBrandReadDto>();
        CreateMap<RAM, RamReadDto>();
        CreateMap<RamWriteDto, RAM>();
        
        CreateMap(typeof(JsonPatchDocument<RamWriteDto>), typeof(JsonPatchDocument<RAM>));
        CreateMap(typeof(Operation<RamWriteDto>), typeof(Operation<RAM>));

        CreateMap<SSDFormFactor, SsdFormFactorReadDto>();
        CreateMap<SSDBrand, SsdBrandReadDto>();
        CreateMap<SSD, SsdReadDto>();
        CreateMap<SsdWriteDto, SSD>();
        
        CreateMap(typeof(JsonPatchDocument<SsdWriteDto>), typeof(JsonPatchDocument<SSD>));
        CreateMap(typeof(Operation<SsdWriteDto>), typeof(Operation<SSD>));
    }
}