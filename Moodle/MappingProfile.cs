using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Models;
using Entities.DataTransferObject;

namespace Moodle
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.UserName, opt =>
                opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));
            CreateMap<Course, CourseDto>()
                .ForMember(c => c.Course , opt =>
                opt.MapFrom(x => string.Join(' ', x.CourseName, x.Description)));
            CreateMap<Section, SectionDto>();
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<Submission, SubmissionDto>();
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<UserForCreationDto, User>();
        }
    }
}
