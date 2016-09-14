using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Timesheet;

namespace Timesheet.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    [Migration("20160914124301_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Timesheet.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<DateTime>("StopTime");

                    b.HasKey("Id");

                    b.ToTable("logs");
                });
        }
    }
}
