using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public class CarWokrshopService : ICarWokrshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWokrshopService(ICarWorkshopRepository carWorkshop, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshop;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}