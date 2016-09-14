using System;

namespace Timesheet
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }        
    }
} 
