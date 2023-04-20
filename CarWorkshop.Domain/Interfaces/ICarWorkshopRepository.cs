namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        public Task Create(CarWorkshop.Domain.Entities.CarWorkshop carWorkshop);
    }
}