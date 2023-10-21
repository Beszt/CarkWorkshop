using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshopService.Commands;

public class CreateCarWorkshopServiceCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
{
    public CreateCarWorkshopServiceCommandValidator()
    {
        RuleFor(c => c.CarWorkshopEncodedName)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Cost)
            .NotEmpty()
            .NotNull();
    }
}