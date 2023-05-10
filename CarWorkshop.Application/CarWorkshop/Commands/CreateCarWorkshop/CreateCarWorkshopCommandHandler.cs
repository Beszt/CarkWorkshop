using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;


namespace CarWorkshop.Application.CarWorkshop.Commands;

public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var user = _userContext.GetCurrentUser();

        if (user == null)
            return Unit.Value;

        var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
        carWorkshop.EncodeName();
        carWorkshop.CreatedById = user.Id;

        await _carWorkshopRepository.Create(carWorkshop);

        return Unit.Value;
    }
}
