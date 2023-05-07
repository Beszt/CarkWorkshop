using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings;

public class CarWorkshopMappingProfile : Profile
{
    public CarWorkshopMappingProfile()
    {
        CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
            .ForMember(obj => obj.ContactDetails, dto => dto.MapFrom(src => new CarWorkshopContactDetails()
            {
                City = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode,
                Street = src.Street
            }));

        CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
            .ForMember(dto => dto.City, obj => obj.MapFrom(src => src.ContactDetails.City))
            .ForMember(dto => dto.PhoneNumber, obj => obj.MapFrom(src => src.ContactDetails.PhoneNumber))
            .ForMember(dto => dto.PostalCode, obj => obj.MapFrom(src => src.ContactDetails.PostalCode))
            .ForMember(dto => dto.Street, obj => obj.MapFrom(src => src.ContactDetails.Street));

    }
}