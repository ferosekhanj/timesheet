using System;

namespace Timesheet
{
    public class LogEntryViewModel
    {
        TimeZoneInfo IST = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        
        public LogEntryViewModel()
        {
            data = new LogEntry();
        }

        public LogEntry data{get;set;}
        public int Id 
        { 
            get { return data.Id;}
            set { data.Id = value;}  
        }

        public string Name 
        { 
            get { return data.Name;}
            set { data.Name = value;}  
        }
        public DateTime StartTime
        { 
            get 
            { 
                return TimeZoneInfo.ConvertTime(data.StartTime,TimeZoneInfo.Utc,IST);
            }
            set 
            { 
                data.StartTime = TimeZoneInfo.ConvertTime(value, IST,TimeZoneInfo.Utc);
            }  
        }
        
        public DateTime StopTime 
        { 
            get 
            { 
                return TimeZoneInfo.ConvertTime(data.StopTime,TimeZoneInfo.Utc,IST);
            } 
            set 
            { 
                data.StopTime = TimeZoneInfo.ConvertTime(value, IST,TimeZoneInfo.Utc);
            }  
             
        }

        public TimeSpan TimeSpent 
        { 
            get
            {
                return data.StopTime - data.StartTime;
            } 
        }        
    }
} 
