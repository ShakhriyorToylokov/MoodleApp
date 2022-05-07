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
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class Seed : ISeedService
    {
        // public static async Task SeedStudents(DataContext context,IFormFile file){ 
        //     if(await context.Students.AnyAsync()) return;
        //     var userData= await System.IO.File.ReadAllTextAsync("Data/StudentSeedData.json");
        //     var students = JsonSerializer.Deserialize<List<Student>>(userData); 
        //     foreach (var student in students)
        //     {
        //         using var hmac= new HMACSHA512();
        //         student.UserName=student.UserName.ToLower();
        //         student.PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
        //         student.PasswordSalt= hmac.Key;  
        //         context.Students.Add(student);
        //     }
        //     await context.SaveChangesAsync();
        // }
  
        // public static async Task SeedTeachers(DataContext context){
        //     if(await context.Teachers.AnyAsync()) return;
        //     var userData= await System.IO.File.ReadAllTextAsync("Data/TeacherSeedData.json");
        //     var teachers = JsonSerializer.Deserialize<List<Teacher>>(userData); 
        //     foreach (var teacher in teachers)
        //     {
        //         using var hmac= new HMACSHA512();
        //         teacher.UserName=teacher.UserName.ToLower();
        //         teacher.PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
        //         teacher.PasswordSalt= hmac.Key;

        //         context.Teachers.Add(teacher);
        //     }
        //     await context.SaveChangesAsync();
        // }

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

        public async Task SeedStudents(DataContext context, IFormFile file)
        {
                // long length = file.Length;
                // using var fileStream= file.OpenReadStream();
                // byte[] bytes = new byte[length];
                // fileStream.Read(bytes, 0, (int)file.Length);
//maybe try to copy the file that has been send to data folder then get the path from there
                var filename= ReadAsStringAsync(file).Result.ToString();
          //  var userData= await System.IO.File.ReadAllTextAsync("");
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
       public async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream())){
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync()); 
                }
            return result.ToString();
        }

  public String ToEncodedString(Stream stream, Encoding enc = null)
    {
        enc = enc ?? Encoding.UTF8;

        byte[] bytes = new byte[stream.Length];
        stream.Position = 0;
        stream.Read(bytes, 0, (int)stream.Length);
        string data = enc.GetString(bytes);

        return enc.GetString(bytes);
    }
        public async Task SeedTeachers(DataContext context, IFormFile file)
        {
            var filename= ReadAsStringAsync(file).Result.ToString();
            var userData= await System.IO.File.ReadAllTextAsync("Data/TeacherSeedData.json");
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