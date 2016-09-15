using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Timesheet
{
    
    public class HomeController : Controller
    {
        TimesheetContext db;

        public HomeController (TimesheetContext db)
        {
            this.db = db;
        }
        
        [HttpGet("/")]
        public IActionResult Index(int id = -1)
        {
            var logs = db.logs.ToList();
            return View(logs);
        }

        [Route("/Home/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}