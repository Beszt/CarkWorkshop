using MediatR;
using Moq;
using Xunit;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Domain.Interfaces;
using FluentAssertions;

namespace CarWorkshop.Application.Tests.CarWorkshopService.Commands;
public class CarWorkshopServiceCommandHandlerTests
{
    [Fact]
    public async Task Handle_CreateCarWorkshopService_WhenUserIsAuthorized()
    {
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@tests.com", new[] { "User" }));
        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(c => c.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);
        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopServiceCommandHandler(carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object, userContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
    }

    [Fact]
    public async Task Handle_CreateCarWorkshopService_WhenUserIsAdmin()
    {
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@tests.com", new[] { "Admin" }));
        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(c => c.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);
        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopServiceCommandHandler(carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object, userContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
    }

    [Fact]
    public async Task Handle_CreateCarWorkshopService_WhenUserIsNotAuthorized()
    {
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@tests.com", new[] { "User" }));
        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock.Setup(c => c.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);
        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopServiceCommandHandler(carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object, userContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
    }

    [Fact]
    public async Task Handle_CreateCarWorkshopService_WhenUserIsNotAuthenticated()
    {
        var carWorkshop = new Domain.Entities.CarWorkshop()
        {
            Id = 1,
            CreatedById = "1"
        };
        var command = new CreateCarWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            Description = "Description",
            CarWorkshopEncodedName = "workshop1"
        };
        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns((CurrentUser?)null);
        var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
        carWorkshopRepositoryMock
            .Setup(c => c.GetByEncodedName(command.CarWorkshopEncodedName))
            .ReturnsAsync(carWorkshop);
        var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();
        var handler = new CreateCarWorkshopServiceCommandHandler(carWorkshopRepositoryMock.Object, carWorkshopServiceRepositoryMock.Object, userContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(Unit.Value);
        carWorkshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
    }
}