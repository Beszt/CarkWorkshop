using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands;

public class UpdateCarWorkshopCommandValidator : AbstractValidator<UpdateCarWorkshopCommand>
{
    public UpdateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
    {
        RuleFor(c => c.Description)
            .NotEmpty();

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(12);
    }
}