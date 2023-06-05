using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;


namespace CarWorkshop.Application.CarWorkshop.Commands;

public class DeleteCarWorkshopCommandHandler : IRequestHandler<DeleteCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IUserContext _userContext;

    public DeleteCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IUserContext userContext)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(DeleteCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);

        if (carWorkshop != null)
        {
            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (!IsEditable)
                return Unit.Value;
        }

        await _carWorkshopRepository.Delete(request.EncodedName!);

        return Unit.Value;
    }
}