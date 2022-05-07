using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Course;
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
            CreateMap<Course,CourseDto>();
            CreateMap<Faculty,FacultyDto>();
            CreateMap<StudentUpdateDto,Student>();
            CreateMap<TeacherUpdateDto,Teacher>();
            CreateMap<CourseUpdateDto,Course>();
            CreateMap<Announcements,AnnouncementDto>();
            CreateMap<AnnouncementUpdateDto,Announcements>();
            CreateMap<CourseUploadFile,CourseUploadFileDto>();
            CreateMap<LectureVideos,LectureVideosDto>();
            CreateMap<RegisterFile,RegisterFileDto>();
            CreateMap<Adminstrator,AdminDto>();

        }

    }
}