using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Application.Services;
using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly ICarWokrshopService _carWorkshopService;
    public CarWorkshopController(ICarWokrshopService carWokrshopService)
    {
        _carWorkshopService = carWokrshopService;
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
    {
        await _carWorkshopService.Create(carWorkshop);
        return View();
    }
}