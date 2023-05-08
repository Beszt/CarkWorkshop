using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories;

public class CarWorkshopRepository : ICarWorkshopRepository
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopRepository(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        _dbContext.Add(carWorkshop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
        => await _dbContext.CarWorkshops.ToListAsync();

    public async Task<Domain.Entities.CarWorkshop?> GetByEncodedName(string encodedName)
        => await _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.EncodedName.ToLower() == encodedName.ToLower());

    public async Task<Domain.Entities.CarWorkshop?> GetByName(string name)
        => await _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

    public async Task Update(Domain.Entities.CarWorkshop carWorkshop)
    {
        var cw = _dbContext.CarWorkshops.FirstOrDefault(cw => cw.Name.ToLower() == carWorkshop.Name.ToLower());
        
        if (cw != null)
        {
            cw.Description = carWorkshop.Description;
            cw.ContactDetails.PhoneNumber = carWorkshop.ContactDetails.PhoneNumber;
            cw.ContactDetails.City = carWorkshop.ContactDetails.City;
            cw.ContactDetails.Street = carWorkshop.ContactDetails.Street;
            cw.ContactDetails.PostalCode = carWorkshop.ContactDetails.PostalCode;

            await _dbContext.SaveChangesAsync();
        }
    }
}