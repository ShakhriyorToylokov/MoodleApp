using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IStudentRepository
    {
        void UpdateStudent(Student student);
        Task<bool>  SaveAllChangesAsync();
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByUsernameAsync(string username);
        Task<IEnumerable<StudentDto>> GetMemberStudentsAsync();
        Task<StudentDto>   GetMemberStudentAsync(string username);
    }
}