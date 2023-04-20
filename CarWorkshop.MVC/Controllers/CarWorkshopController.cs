using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Application.Services;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly ICarWokrshopService _carWorkshopService;
    public CarWorkshopController(ICarWokrshopService carWokrshopService)
    {
        _carWorkshopService = carWokrshopService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        await _carWorkshopService.Create(carWorkshop);
        return Ok(carWorkshop);
    }
}