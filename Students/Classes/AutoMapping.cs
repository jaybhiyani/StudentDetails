using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Students.Models;
using Students.DAL.Entities;
using Students.BLL.Models;

namespace Students.Classes
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Students.Models.Department,  DepartmentBLL > ().ReverseMap();
            CreateMap<Students.Models.Student, StudentBLL > ().ReverseMap();
            CreateMap<Students.DAL.Entities.Department, Students.Models.Department>().ReverseMap();
            CreateMap<Students.DAL.Entities.Student, Students.Models.Student>().ReverseMap();
            CreateMap<DepartmentBLL, Students.DAL.Entities.Department>().ReverseMap();
            CreateMap<StudentBLL, Students.DAL.Entities.Student>().ReverseMap();
        }
    }
}
