using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;


namespace CarWorkshop.Application.CarWorkshop.Commands;

public class UpdateCarWorkshopCommandHandler : IRequestHandler<UpdateCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public UpdateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(UpdateCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);

        if (carWorkshop != null)
        {
            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (!IsEditable)
                return Unit.Value;
        }

        carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

        await _carWorkshopRepository.Update(carWorkshop);

        return Unit.Value;
    }
}
