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


    [Route("/Log/{Start}/{Stop}")]
    public ActionResult Add(DateTime Start,DateTime Stop)
    {
        if(!ModelState.IsValid)
        {
            logger.LogError("Receiver invalid input {0}",Request.Path);
            return new ContentResult{   
                                        Content     = $"400 Bad request \nUnable to process the log "+ Request.Path,
                                        ContentType = @"text\plain",
                                        StatusCode  = 400 
                                    };
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
        return new ContentResult{ Content=$"Added {Start} {Stop}",ContentType=@"text\plain",StatusCode =200 };
    }
}
}