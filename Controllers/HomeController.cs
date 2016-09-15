using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Timesheet
{
    
    public class HomeController : Controller
    {
        TimesheetContext db;
        ILogger<HomeController> logger;

        public HomeController (TimesheetContext db, ILogger<HomeController> logger)
        {
            this.db = db;
            this.logger = logger;
        }
        
        [HttpGet("/")]
        public IActionResult Index(int id = -1)
        {
            var start = DateTime.Now;
            var logs = db.logs.ToList();
            logger.LogInformation("Query took {0}",(DateTimeOffset.Now-start).Milliseconds);
            return View(logs);
        }

        [Route("/Home/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}