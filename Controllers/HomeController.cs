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
        
        public IActionResult Index(int id = -1)
        {
            var start = DateTime.Now;
            var logs = from l in db.logs select new LogEntryViewModel{data=l};
            logger.LogInformation("Query took {0}",(DateTimeOffset.Now-start).Milliseconds);
            return View(logs.ToList());
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}