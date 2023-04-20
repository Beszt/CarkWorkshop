namespace CarWorkshop.Application.Services
{
    public interface ICarWokrshopService
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}