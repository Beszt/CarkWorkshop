using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System.Net;
using Xunit;


namespace CarWorkshop.MVC.Controllers.Tests;

public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshops()
    {
        var carWorkshops = new List<CarWorkshopDto>
        {
            new(){
                Name = "Workshop 1"
            },
            new(){
                Name = "Workshop 2"
            },
            new(){
                Name = "Workshop 3"
            },
        };
        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(carWorkshops);
        var client = _factory
            .WithWebHostBuilder(b => 
                b.ConfigureTestServices( s => 
                    s.AddScoped( _ => mediatorMock.Object)))
            .CreateClient();

        var response = await client.GetAsync("/CarWorkshop/Index");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should()
            .Contain("<h1>Workshops list</h1>")
            .And.Contain("Workshop 1")
            .And.Contain("Workshop 2")
            .And.Contain("Workshop 3");
    }

    [Fact]
    public async Task Index_ReturnsEmptyView_WhenNoCarWorkshopsExists()
    {
        var carWorkshops = new List<CarWorkshopDto>();
        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(carWorkshops);
        var client = _factory
            .WithWebHostBuilder(b => 
                b.ConfigureTestServices( s => 
                    s.AddScoped( _ => mediatorMock.Object)))
            .CreateClient();

        var response = await client.GetAsync("/CarWorkshop/Index");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should()
            .NotContain("card m-3")
            .And.NotContain("card-body")
            .And.NotContain("card-title");
    }
}
