using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;


namespace CarWorkshop.Application.CarWorkshopService.Commands;

public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateCarWorkshopServiceCommandHandler(ICarWorkshopRepository carWorkshopRepository, ICarWorkshopServiceRepository carWorkshopServiceRepository, IMapper mapper, IUserContext userContext)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _carWorkshopServiceRepository = carWorkshopServiceRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

        if (carWorkshop != null)
        {
            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (!IsEditable)
                return Unit.Value;
        }

        var carWorkshopService = new Domain.Entities.CarWorkshopService()
        {
            Cost = request.Cost,
            Description = request.Description,
            CarWorkshopId = carWorkshop!.Id
        };

        await _carWorkshopServiceRepository.Create(carWorkshopService);

        return Unit.Value;
    }
}
