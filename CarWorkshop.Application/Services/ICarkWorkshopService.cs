using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services;

public interface ICarWokrshopService
{
    Task<IEnumerable<CarWorkshopDto>> GetAll();
    Task Create(CarWorkshopDto carWorkshop);
}
