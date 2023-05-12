using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.CarWorkshopService;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings;

public class CarWorkshopMappingProfile : Profile
{
    private readonly IUserContext _userContext;
    
    public CarWorkshopMappingProfile(IUserContext userContext)
    {
        _userContext = userContext;
        var user = _userContext.GetCurrentUser();

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
            .ForMember(dto => dto.Street, obj => obj.MapFrom(src => src.ContactDetails.Street))
            .ForMember(dto => dto.IsEditable, obj => obj.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Admin"))));

        CreateMap<CarWorkshopDto, UpdateCarWorkshopCommand>();

        CreateMap<CarWorkshopServiceDto, Domain.Entities.CarWorkshopService>()
            .ReverseMap();
    }
}