using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWokrshopService : ICarWokrshopService
    {
        public readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWokrshopService(ICarWorkshopRepository carWorkshop)
        {
            _carWorkshopRepository = carWorkshop;
        }

        public async Task Create(CarWorkshop.Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}