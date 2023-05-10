using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands;
using CarWorkshop.Application.CarWorkshop.Queries;
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

    [Authorize]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
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

        if (!dto.IsEditable)
            return RedirectToAction("NoAccess", "Home");

        var command = _mapper.Map<UpdateCarWorkshopCommand>(dto);

        return View(command);
    }

    [HttpPost]
    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(UpdateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}