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

    public ActionResult Index()
    {
        var start = DateTime.Now;
        var logs = from l in db.logs select new LogEntryViewModel{data=l};
        logger.LogInformation("Query took {0}",(DateTimeOffset.Now-start).Milliseconds);
        return View(logs.ToList());
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
            StartTime = Start.ToUniversalTime(),
            StopTime = Stop.ToUniversalTime(),
        };
        db.logs.Add(model);
        db.SaveChanges();
        return Content($"Added {Start} {Stop}");
    }

    public ActionResult Edit(int id=-1)
    {
        var logToBeEdited = db.logs.Where(l=>l.Id==id).First(); 
        return View(new LogEntryViewModel{ data= logToBeEdited});
    }

    [HttpPost]
    public ActionResult Save(LogEntryViewModel model)
    {
        db.Update(model.data);
        db.SaveChanges();
        return RedirectToAction("Index",model);
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
        return RedirectToAction("Index");
    }
}
}