using Xunit;
using FluentAssertions;

namespace CarWorkshop.Application.ApplicationUser.Tests;

public class ApplicationUserTests
{
    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User"});

        var isInRole = currentUser.IsInRole("Admin");

        isInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User"});

        var isInRole = currentUser.IsInRole("Manager");

        isInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User"});

        var isInRole = currentUser.IsInRole("admin");

        isInRole.Should().BeFalse();
    }
}