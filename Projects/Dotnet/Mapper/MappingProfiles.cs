using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.DTOs;
using Dotnet.Models;

namespace Dotnet.Mapper
{


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Device, DeviceDto>().ReverseMap();
        CreateMap<Simcard, SimcardDto>().ReverseMap();
        CreateMap<EVoucher, EVoucherDto>().ReverseMap();
        // Add other mappings here
    }
}
}