using System;
using Microsoft.AspNetCore.Mvc;
namespace Timesheet{
public class LogController : Controller
{
    TimesheetContext db;

    public LogController (TimesheetContext db)
    {
      this.db = db;
    }


    [HttpGet("/Log/{Start:DateTime}/{Stop:DateTime}")]
    public IActionResult Add(DateTime Start,DateTime Stop)
    {
        System.Console.WriteLine($"{Start} {Stop}");
        var model = new LogEntry
        {
            Name = "Ferose",
            StartTime = Start,
            StopTime = Stop,
        };
        db.logs.Add(model);
        db.SaveChanges();
        return View("LogDetails",model);
    }
}
}