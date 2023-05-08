using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands;

public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
{
    public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(20)
            .Custom((value, context) =>
            {
                var existingCarWorkshop = repository.GetByName(value).Result;

                if (existingCarWorkshop != null)
                    context.AddFailure($"{value} is not unique name for car workshop");
            });

        RuleFor(c => c.Description)
            .NotEmpty();

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(12);
    }
}