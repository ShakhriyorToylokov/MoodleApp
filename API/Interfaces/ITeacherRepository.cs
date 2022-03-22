using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ITeacherRepository
    {
        void UpdateTeacher(Teacher teacher);
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> GetTeacherByUsernameAsync(string username);
        Task<bool>  SaveAllChangesAsync(Teacher teacher);
        Task<IEnumerable<TeacherDto>> GetMemberTeachersAsync();
        Task<TeacherDto> GetMemberTeacherAsync(string username);

    }
}