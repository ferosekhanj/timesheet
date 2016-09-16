using System;

namespace Timesheet
{
    public class LogEntryViewModel
    {
        TimeZoneInfo IST = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        
        public LogEntry data{get;set;}

        public string Name 
        { 
            get { return data.Name;}  
        }
        public DateTime StartTime
        { 
            get { return TimeZoneInfo.ConvertTime(data.StartTime,IST);}  
        }
        
        public DateTime StopTime 
        { 
            get { return TimeZoneInfo.ConvertTime(data.StopTime,IST);}  
        }        
    }
} 
