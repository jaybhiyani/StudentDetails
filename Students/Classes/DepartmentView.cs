using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Classes
{
    public class DepartmentView
    {
        public int Id { get; set; }
        public string Dep { get; set; }
        public List<Student> Students { get; set; }
    }
}
