using System;
using System.Linq;
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


    [Route("/Log/{Start}/{Stop}")]
    public ActionResult Add(DateTime Start,DateTime Stop)
    {
        if(!ModelState.IsValid)
        {
            logger.LogError("Receiver invalid input {0}",Request.Path);
            return BadRequest($"Unable to process the log {Request.Path}"); 
        }

        logger.LogInformation("Received Start={0},Stop={1}",Start,Stop);
        var model = new LogEntry
        {
            Name = "Ferose",
            StartTime = Start,
            StopTime = Stop,
        };
        db.logs.Add(model);
        db.SaveChanges();
        return Content($"Added {Start} {Stop}");
    }

    public ActionResult Delete(int id=-1)
    {
        if(!ModelState.IsValid)
        {
            logger.LogError("Receiver invalid input {0}",Request.Path);
            return BadRequest($"Unable to process the log {Request.Path}"); 
        }
        var logToBeDeleted = db.logs.Where(l=>l.Id==id).First(); 
        db.logs.Remove(logToBeDeleted);
        db.SaveChanges();
        return RedirectToAction("Index","Home");
    }
}
}