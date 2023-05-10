namespace CarWorkshop.Application.ApplicationUser;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}