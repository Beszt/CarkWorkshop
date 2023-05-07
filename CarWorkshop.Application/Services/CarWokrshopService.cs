using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services;

public class CarWokrshopService : ICarWokrshopService
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;

    public CarWokrshopService(ICarWorkshopRepository carWorkshop, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshop;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarWorkshopDto>> GetAll()
    {
        var carWorkshops = await _carWorkshopRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
        
        return dtos;
    }

    public async Task Create(CarWorkshopDto carWorkshopDto)
    {
        var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);

        carWorkshop.EncodeName();

        await _carWorkshopRepository.Create(carWorkshop);
    }
}