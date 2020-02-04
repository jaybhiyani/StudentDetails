using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Dep { get; set; }
        public List<Student> Students { get; set; }
    }
}
