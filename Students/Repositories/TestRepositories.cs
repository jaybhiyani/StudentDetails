using Students.Interfaces;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class TestRepositories : IDepartmentRepository
    {
        public Task<Department> DeleteDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department> PostDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Department> PutDepartment(int departmentId, Department department)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> SearchDepartment(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
