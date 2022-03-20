using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class Seed
    {
        public static async Task SeedStudents(DataContext context){ 
            if(await context.Students.AnyAsync()) return;
            var userData= await System.IO.File.ReadAllTextAsync("Data/StudentSeedData.json");
            var students = JsonSerializer.Deserialize<List<Student>>(userData); 
            foreach (var student in students)
            {
                using var hmac= new HMACSHA512();
                student.UserName=student.UserName.ToLower();
                student.PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                student.PasswordSalt= hmac.Key;  
                context.Students.Add(student);
            }
            await context.SaveChangesAsync();
        }
  
        public static async Task SeedTeachers(DataContext context){
            if(await context.Teachers.AnyAsync()) return;
            var userData= await System.IO.File.ReadAllTextAsync("Data/TeacherSeedData.json");
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(userData); 
            foreach (var teacher in teachers)
            {
                using var hmac= new HMACSHA512();
                teacher.UserName=teacher.UserName.ToLower();
                teacher.PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                teacher.PasswordSalt= hmac.Key;

                context.Teachers.Add(teacher);
            }
            await context.SaveChangesAsync();
        }

         public static async Task SeedAdmins(DataContext context){
            if(await context.Admin.AnyAsync()) return;
            var userData= await System.IO.File.ReadAllTextAsync("Data/AdminSeedData.json");
            var admins = JsonSerializer.Deserialize<List<Adminstrator>>(userData); 
            foreach (var admin in admins)
            {
                using var hmac= new HMACSHA512();
                admin.UserName=admin.UserName.ToLower();
                admin.PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                admin.PasswordSalt= hmac.Key;

                context.Admin.Add(admin);
            }
            await context.SaveChangesAsync();
        }
    }
}