namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        public Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}