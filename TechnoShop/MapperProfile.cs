using AutoMapper;
using Domain.Models;
using TechnoShop.DTO;

namespace TechnoShop;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<GPUBrand, GpuBrandReadDto>();
        CreateMap<GpuManufacturer, GpuManufacturerReadDto>();
        CreateMap<MemoryType, MemoryTypeReadDto>();
        CreateMap<GPU, GpuReadDto>();
    }
}