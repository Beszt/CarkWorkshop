using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries;

public class GetAllCarWorkshopsQuery : IRequest<IEnumerable<CarWorkshopDto>>
{

}