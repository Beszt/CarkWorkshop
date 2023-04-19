using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkShopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkShopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync() && !_dbContext.CarWorkshops.Any())
            {
                Domain.Entities.CarWorkshop mazdaAso = new()
                {
                    Name = "Mazda ASO",
                    Description = "Official Mazda service",
                    ContactDetails = new()
                    {
                        City = "Badrzychowice",
                        Street = "Ulana 69",
                        PostalCode = "69-666",
                        PhoneNumber = "+48700889410"
                    }
                };
                mazdaAso.EncodeName();

                _dbContext.CarWorkshops.Add(mazdaAso);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}