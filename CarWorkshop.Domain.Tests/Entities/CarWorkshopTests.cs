using Xunit;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests;

public class CarWorkshopTests
{
    [Fact]
    public void EncodeName_ShouldSetEncodeName()
    {
        var carWorkshop = new CarWorkshop
        {
            Name = "Test Workshop"
        };

        carWorkshop.EncodeName();

        carWorkshop.EncodedName.Should().Be("test-workshop");
    }

    [Fact]
    public void EncodeName_ShouldThrowException_WhenNameIsNull()
    {
        var carWorkshop = new CarWorkshop();

        Action action = () => carWorkshop.EncodeName();

        action.Invoking(a => a.Invoke())
            .Should().Throw<NullReferenceException>();
    }
}