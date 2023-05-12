using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.CarWorkshop.Queries;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Application.CarWorkshopService.Queries;
using CarWorkshop.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public CarWorkshopController(IMediator mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
        return View(carWorkshops);
    }

    [Authorize(Roles = "Admin, User")]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);

        this.SetNotification("success", $"Created carworkshop: {command.Name}");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    [Route("CarWorkshop/CarWorkshopService")]
    public async Task<IActionResult> CreateCarWorkshopService(CreateCarWorkshopServiceCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    [Route("CarWorkshop/{encodedName}/CarWorkshopService")]
    public async Task<IActionResult> CreateCarWorkshopService(string encodedName)
    {
        var data = await _mediator.Send(new GetCarWorkshopServicesQuery(encodedName));
        return Ok(data);
    }

    [Authorize(Roles = "Admin, User")]
    [Route("CarWorkshop/{encodedName}/Details")]
    public async Task<ActionResult> Details(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        return View(dto);
    }

    [Authorize(Roles = "Admin, User")]
    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<ActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

        if (!dto.IsEditable)
            return RedirectToAction("NoAccess", "Home");

        var command = _mapper.Map<UpdateCarWorkshopCommand>(dto);

        return View(command);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(UpdateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);

        this.SetNotification("info", $"Edited carworkshop: {command.Name}");

        return RedirectToAction(nameof(Index));
    }
}