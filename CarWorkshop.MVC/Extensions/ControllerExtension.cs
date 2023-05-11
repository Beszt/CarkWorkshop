
using CarWorkshop.MVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Extensions;

public static class ControllerExtension
{
    public static void SetNotification(this Controller controller, string type, string message)
    {
        var notification = new Notification(type, message);
        controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
    }
}