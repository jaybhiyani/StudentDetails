using Students.Classes;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.DAL.Entities;

namespace Students.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<DepartmentView>> GetDepartments();

        public Task<DepartmentView> GetDepartment(int departmentId);

        public Task<IEnumerable<DepartmentView>> SearchDepartment(string searchString);

        public Task<DepartmentView> PostDepartment(Department department);

        public Task<DepartmentView> PutDepartment(int departmentId, Department department);

        public Task<DepartmentView> DeleteDepartment(int departmentId);
    }
}
