using AutoMapper;
using Domain.Models;
using TechnoShop.DTO;

namespace TechnoShop;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductWriteDto, Product>();
        CreateMap<GPUBrand, GpuBrandReadDto>();
        CreateMap<GpuManufacturer, GpuManufacturerReadDto>();
        CreateMap<MemoryType, MemoryTypeReadDto>();
        CreateMap<GPU, GpuReadDto>();
        CreateMap<GpuWriteDto, GPU>();
    }
}