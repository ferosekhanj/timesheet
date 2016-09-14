using Microsoft.EntityFrameworkCore;
namespace Timesheet
{
public class TimesheetContext : DbContext
{
    public DbSet<LogEntry> logs{get;set;}

    public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
    {
    }
    
}
}