using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.CarWorkshop.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly IMediator _mediator;
    public CarWorkshopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
        return View(carWorkshops);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("CarWorkshop/{encodedName}/Details")]
    public async Task<ActionResult> Details(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        return View(dto);
    }

    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<ActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        
        var command = new UpdateCarWorkshopCommand() {
            Name = dto.Name,
            EncodedName = dto.EncodedName,
            Description = dto.Description,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            Street = dto.Street,
            PostalCode = dto.PostalCode
        };

        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index), nameof(CarWorkshopController), command.EncodedName);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}