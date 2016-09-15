using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Timesheet{
public class LogController : Controller
{
    TimesheetContext db;
    ILogger<LogController> logger;
    public LogController (TimesheetContext db, ILogger<LogController> logger)
    {
      this.db = db;
      this.logger = logger;

    }


    [HttpGet("/Log/{Start:DateTime}/{Stop:DateTime}")]
    public IActionResult Add(DateTime Start,DateTime Stop)
    {
        logger.LogInformation("Received Start={0},Stop={1}",Start,Stop);
        
        if(!ModelState.IsValid)
            return RedirectToAction("Error","Home");

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