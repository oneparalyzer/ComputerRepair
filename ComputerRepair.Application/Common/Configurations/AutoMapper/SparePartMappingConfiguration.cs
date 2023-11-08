using AutoMapper;
using ComputerRepair.Contracts.SpareParts.Responses;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;

namespace ComputerRepair.Application.Common.Configurations.AutoMapper;

public sealed class SparePartMappingConfiguration : Profile
{
    public SparePartMappingConfiguration()
    {
        CreateMap<SparePart, GetAllSparePartsResponse>()
            .ForPath(dst => dst.SparePartId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.MeasureUnitTitle, opt => opt.MapFrom(src => src.MeasureUnit.Name));
    }
}
