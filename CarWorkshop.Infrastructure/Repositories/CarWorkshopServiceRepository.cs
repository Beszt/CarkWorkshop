using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories;

public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopServiceRepository(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(CarWorkshopService carWorkshopService)
    {
        _dbContext.Add(carWorkshopService);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName)
        => await _dbContext.CarWorkshopServices.Where (s => s.CarWorkshop.EncodedName == encodedName).ToListAsync();
}