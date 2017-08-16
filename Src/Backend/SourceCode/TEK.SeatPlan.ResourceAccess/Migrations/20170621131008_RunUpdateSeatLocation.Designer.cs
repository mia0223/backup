using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TEK.SeatPlan.ResourceAccess;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170621131008_RunUpdateSeatLocation")]
    partial class RunUpdateSeatLocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TEK.SeatPlan.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<int>("ProjectId");

                    b.Property<string>("UserCreated")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("UserModified")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("Cols")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("30");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("FloorLevel")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<int?>("ParentId");

                    b.Property<int>("Rows")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("50");

                    b.Property<string>("UserCreated")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("UserModified")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("BackgroundColor");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("ForegroundColor");

                    b.Property<bool>("Internal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("UserCreated")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("UserModified")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Project");
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("Col")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("LocationId");

                    b.Property<int>("Number");

                    b.Property<int>("Row")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Transit")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("UserCreated")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("UserModified")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LocationId", "Number")
                        .IsUnique();

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Employee", b =>
                {
                    b.HasOne("TEK.SeatPlan.Entity.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Location", b =>
                {
                    b.HasOne("TEK.SeatPlan.Entity.Location", "ParentLocation")
                        .WithMany("ChildLocations")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TEK.SeatPlan.Entity.Seat", b =>
                {
                    b.HasOne("TEK.SeatPlan.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TEK.SeatPlan.Entity.Location", "Location")
                        .WithMany("Seats")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
