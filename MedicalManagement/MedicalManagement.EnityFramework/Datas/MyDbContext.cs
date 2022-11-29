using MedicalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Models;

namespace MedicalManagement.EntityFramework.Datas
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<DoctorInfo> DoctorInfos { get; set; }
        public DbSet<MedicineInfo> MedicineInfos { get; set; }
        public DbSet<DoctorAdviceInfo> DoctorAdviceInfos { get; set; }
        public DbSet<PatientInfo> PatientInfos { get; set; }
        public DbSet<PrescriptionInfo> PrescriptionInfos { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorAdviceInfo>(et =>
            {
                et.Property(et => et.CreateDate).HasColumnType("timestamp");
            });
        }




    }
}
