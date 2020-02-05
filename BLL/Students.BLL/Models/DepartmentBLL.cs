using System;
using System.Collections.Generic;
using System.Text;

namespace Students.BLL.Models
{
    public class DepartmentBLL
    {
        public int Id { get; set; }
        public string Dep { get; set; }
        public List<StudentBLL> Students { get; set; }
    }
}
