using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class Seed : ISeedService
    {

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
        public static async Task SeedFaculty(DataContext context){
            if(await context.Faculties.AnyAsync()) return;
            var userData= await System.IO.File.ReadAllTextAsync("Data/FacultySeedData.json");
            var faculties = JsonSerializer.Deserialize<List<Faculty>>(userData); 
            foreach (var faculty in faculties)
            {
                using var hmac= new HMACSHA512();
                faculty.FacultyName=faculty.FacultyName.ToLower();
                context.Faculties.Add(faculty);
            }
            await context.SaveChangesAsync();
        }
        public async Task SeedQuiz(DataContext context, IFormFile file)
        {
            var path= "C:/Users/Dell/Downloads/GR_project/moodle-for-faculty-of-engineering-2/client/src/assets/questions.json";
            var fileString= ReadAsStringAsync(file).Result.ToString();
           File.WriteAllText(path, fileString);
           await context.SaveChangesAsync();
        }
        public async Task SeedStudents(DataContext context, IFormFile file)
        {
            var filename= ReadAsStringAsync(file).Result.ToString();
            var students = JsonSerializer.Deserialize<List<Student>>(filename); 
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
       public static async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream())){
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync()); 
                }
            return result.ToString();
        }

        public async Task SeedTeachers(DataContext context, IFormFile file)
        {
            var filename= ReadAsStringAsync(file).Result.ToString();
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(filename); 
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
    }
}