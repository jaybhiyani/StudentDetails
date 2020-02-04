using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Students.DAL.Entities;

namespace Students.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> GetDepartments();

        public Task<Department> GetDepartment(int departmentId);

        public Task<IEnumerable<Department>> SearchDepartment(string searchString);

        public Task<Department> PostDepartment(Department department);

        public Task<Department> PutDepartment(int departmentId, Department department);

        public Task<Department> DeleteDepartment(int departmentId);
    }
}
