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

    public async Task<IActionResult> Index()
    {
        var carWorkshops = await _carWorkshopService.GetAll();
        return View(carWorkshops);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
    {
        if (!ModelState.IsValid)
        {
            return View(carWorkshop);
        }

        await _carWorkshopService.Create(carWorkshop);
        return RedirectToAction(nameof(Index));
    }
}