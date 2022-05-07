using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Http;

namespace API.Interfaces
{
    public interface ISeedService
    {
        Task SeedStudents(DataContext context,IFormFile file);
        Task SeedTeachers(DataContext context,IFormFile file);
        // Task SeedAdmins(DataContext context,IFormFile file);
        // Task SeedFaculty(DataContext context,IFormFile file);
    }
}