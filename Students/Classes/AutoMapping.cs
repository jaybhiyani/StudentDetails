using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Students.Models;
using Students.DAL.Entities;

namespace Students.Classes
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Students.DAL.Entities.Department, Students.Models.Department> ();
            CreateMap<Students.DAL.Entities.Student, Students.Models.Student>();
        }
    }
}
