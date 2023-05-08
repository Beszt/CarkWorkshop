using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;


namespace CarWorkshop.Application.CarWorkshop.Commands;

public class UpdateCarWorkshopCommandHandler : IRequestHandler<UpdateCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;

    public UpdateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

        await _carWorkshopRepository.Update(carWorkshop);

        return Unit.Value;
    }
}
