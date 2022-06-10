using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Course;
using API.DTOs.Parameters;
using API.Entities;
using API.Entities.CourseDetails;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student,StudentDto>()
                .ForMember(dest=>dest.PhotoUrl, opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<StudentPhoto,StudentPhotoDto>();
            CreateMap<Teacher,TeacherDto>()
                .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<TeacherPhoto,TeacherPhotoDto>();
            CreateMap<TeacherPhotoDto,TeacherPhoto>();
            CreateMap<Course,CourseDto>();
            CreateMap<CourseDto,Course>();
            CreateMap<Faculty,FacultyDto>();
            CreateMap<StudentUpdateDto,Student>();
            CreateMap<TeacherUpdateDto,Teacher>();
            CreateMap<Teacher,CourseTeacherReturnDto>();
            CreateMap<CourseTeacherReturnDto,Teacher>();
            CreateMap<CourseUpdateDto,Course>();
            CreateMap<Announcements,AnnouncementDto>();
            CreateMap<AnnouncementDto,Announcements>();
            CreateMap<AnnouncementUpdateDto,Announcements>();
            CreateMap<CourseUploadFile,CourseUploadFileDto>();
            CreateMap<CourseUploadFileDto,CourseUploadFile>();
            CreateMap<LectureVideos,LectureVideosDto>();
            CreateMap<LectureVideosDto,LectureVideos>();
            CreateMap<RegisterFile,RegisterFileDto>();
            CreateMap<Adminstrator,AdminDto>();
            CreateMap<RegisterDto,Student>();
            CreateMap<RegisterDto,Teacher>();
            CreateMap<RegisterCourseDto,Course>();
            CreateMap<CourseDto,Course>();
            CreateMap<Homework,HomeworkDto>();
            CreateMap<HomeworkDto,Homework>();
            CreateMap<StudentHomework,StudentHomeworkDto>();
            CreateMap<StudentHomeworkDto,StudentHomework>();
            CreateMap<CourseUploadFile,Homework>();
            CreateMap<QuizFiles,QuizFileDto>();
            CreateMap<QuizFileDto,QuizFiles>();
            CreateMap<StudentCoursesUpdateDto,Student>();
        }

    }
}