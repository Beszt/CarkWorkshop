using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries;

public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
{
    public string EncodedName { get; set; }

    public GetCarWorkshopServicesQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}