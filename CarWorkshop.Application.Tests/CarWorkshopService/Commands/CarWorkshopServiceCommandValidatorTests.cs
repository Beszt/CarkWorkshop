using FluentValidation.TestHelper;
using Xunit;

namespace CarWorkshop.Application.CarWorkshopService.Commands.Tests;

public class CarWorkshopServiceCommandValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShoulNotHaveValidationErrors()
    {
        var validator = new CreateCarWorkshopServiceCommandValidator();
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Description",
            CarWorkshopEncodedName = "workshop1"
        };

        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Validate_WithInvalidCommand_ShoulHaveValidationErrors()
    {
        var validator = new CreateCarWorkshopServiceCommandValidator();
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "",
            Description = "",
            CarWorkshopEncodedName = null!
        };

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Cost);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.CarWorkshopEncodedName);
    }
}
