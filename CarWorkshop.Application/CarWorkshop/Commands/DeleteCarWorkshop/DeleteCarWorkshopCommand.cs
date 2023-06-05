using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands;

public class DeleteCarWorkshopCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeleteCarWorkshopCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}