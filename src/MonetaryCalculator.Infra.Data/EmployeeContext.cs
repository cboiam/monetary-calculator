using Microsoft.EntityFrameworkCore;
using MonetaryCalculator.Infra.Data.Models;

namespace MonetaryCalculator.Infra.Data
{
    public class EmployeeContext : DbContext
    {
        DbSet<EmployeeModel> Employees { get; set; }
        DbSet<VacationModel> Vacations { get; set; }
        DbSet<WageModel> Wages { get; set; }

        public EmployeeContext(DbContextOptions options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var employeeEntity = modelBuilder.Entity<EmployeeModel>();
            employeeEntity.HasKey(e => e.Id);
            employeeEntity.HasMany(e => e.Wages)
                .WithOne(e => e.Employee);
            employeeEntity.HasMany(e => e.Vacations)
                .WithOne(e => e.Employee);

            var wageEntity = modelBuilder.Entity<WageModel>();
            wageEntity.HasKey(e => e.Id);

            var vacationEntity = modelBuilder.Entity<VacationModel>();
            vacationEntity.HasKey(e => e.Id);
        }
    }
}
