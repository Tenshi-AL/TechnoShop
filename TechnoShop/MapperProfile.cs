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
    }
}