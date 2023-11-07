using AutoMapper;
using ComputerRepair.Contracts.Offices.Responses;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;

namespace ComputerRepair.Application.Common.Configurations.AutoMapper;

public sealed class OfficeMappingConfiguration : Profile
{
    public OfficeMappingConfiguration()
    {
        CreateMap<Office, GetAllOfficesResponse>()
            .ForPath(dst => dst.OfficeId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.Region, opt => opt.MapFrom(src => src.Address.Region))
            .ForPath(dst => dst.City, opt => opt.MapFrom(src => src.Address.City))
            .ForPath(dst => dst.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForPath(dst => dst.Home, opt => opt.MapFrom(src => src.Address.Home))
            .ForPath(dst => dst.OfficeTypeName, opt => opt.MapFrom(src => src.OfficeType.Name));

        CreateMap<Office, GetOfficeByIdResponse>()
            .ForPath(dst => dst.OfficeId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.Region, opt => opt.MapFrom(src => src.Address.Region))
            .ForPath(dst => dst.City, opt => opt.MapFrom(src => src.Address.City))
            .ForPath(dst => dst.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForPath(dst => dst.Home, opt => opt.MapFrom(src => src.Address.Home))
            .ForPath(dst => dst.OfficeTypeName, opt => opt.MapFrom(src => src.OfficeType.Name));
    }
}
