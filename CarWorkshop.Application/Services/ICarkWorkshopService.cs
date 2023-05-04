using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarWokrshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
    }
}