using AutoMapper;
using ComputerRepair.Contracts.RepairTypes.Responses;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;

namespace ComputerRepair.Application.Common.Configurations.AutoMapper;

public sealed class RepairTypeMappingConfiguration : Profile
{
    public RepairTypeMappingConfiguration()
    {
        CreateMap<RepairType, GetAllRepairTypesResponse>()
            .ForPath(dst => dst.RepairTypeId, opt => opt.MapFrom(src => src.Id.Value));
    }
}
