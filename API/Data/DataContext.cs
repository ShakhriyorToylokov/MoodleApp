using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Adminstrator> Admin { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w=>w.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
             // ** the warning is about Skip/Take when Include() Photo,Course , for getting single user
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>()   
                .HasKey(x=>x.Id);
            modelBuilder.Entity<StudentPhoto>(entity=>{
                     entity.HasOne(pt => pt.Student)
                    .WithMany(t => t.Photos)
                    .HasForeignKey(pt => pt.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

            }); 
                           
    }
}
    }
