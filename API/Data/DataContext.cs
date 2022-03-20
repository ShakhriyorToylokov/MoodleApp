using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

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
         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
      /*  modelBuilder.Entity<Student>()
            .HasMany(p => p.Courses)
            .WithMany(p => p.Students);
        modelBuilder.Entity<Student>()
            .HasMany(p => p.Teachers)
            .WithMany(p => p.Students);
        */
        // modelBuilder.Entity<Teacher>(entity=>{
        //     // entity.HasMany(p => p.Courses)
        //     // .WithOne(p => p.Teacher).HasForeignKey(p=>p.TeacherId).OnDelete(DeleteBehavior.Restrict);

        //     entity.HasMany(x=>x.Students)
        //           .WithMany(x=>x.Teachers);
            
        //     entity.HasMany(x=>x.Photos)
        //           .WithOne(y=>y.Teacher)
        //           .HasForeignKey(y=>y.TeacherId).OnDelete(DeleteBehavior.Cascade);
            
        // });
        // modelBuilder.Entity<TeacherCourses>()
        //     .HasOne(x=>x.Teacher)
        //     .WithMany(y=>y.Courses)
        //     .HasForeignKey(x=>x.TeacherId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Course>()   // Seed students working but not seed teachers 
                .HasKey(x=>x.Id);
            // modelBuilder.Entity<Teacher>()
            //     .HasMany(x=>x.Courses)
            //     .WithOne(y=>y.Teacher) 
            //     .HasForeignKey(x=>x.TeacherId).OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<StudentPhoto>(entity=>{
                     entity.HasOne(pt => pt.Student)
                    .WithMany(t => t.Photos)
                    .HasForeignKey(pt => pt.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            
                /*   entity.HasOne(pt => pt.Course)
                    .WithMany(t => t.Photos)
                    .HasForeignKey(pt => pt.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                    entity.HasOne(pt => pt.Teacher)
                    .WithMany(t => t.Photos)
                    .HasForeignKey(pt => pt.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict); */

            }); 
                           
    }
}
    }
