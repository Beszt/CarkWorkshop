
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;

namespace CarWorkshop.Application.ApplicationUser.Tests;

public class UserContextTests
{
    [Fact]
    public void GetCurrentUser_WithAuthenticationUser_ShouldReturnCurrentUser()
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Email, "test@tests.com"),
            new(ClaimTypes.Role, "Admin"),
            new(ClaimTypes.Role, "User")
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns( new DefaultHttpContext()
        {
            User = user
        });
        var userContext = new UserContext(httpContextAccessorMock.Object);

        var currentUser = userContext.GetCurrentUser();

        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@tests.com");
        currentUser.Roles.Should().ContainInOrder("Admin", "User");
    }
}
