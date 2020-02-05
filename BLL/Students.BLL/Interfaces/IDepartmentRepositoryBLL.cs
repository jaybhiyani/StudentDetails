using Students.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Students.BLL.Interfaces
{
    public interface IDepartmentRepositoryBLL
    {
        public Task<IEnumerable<DepartmentBLL>> GetDepartments();

        public Task<DepartmentBLL> GetDepartment(int departmentId);

        public Task<IEnumerable<DepartmentBLL>> SearchDepartment(string searchString);

        public Task<DepartmentBLL> PostDepartment(DepartmentBLL department);

        public Task<DepartmentBLL> PutDepartment(int departmentId, DepartmentBLL department);

        public Task<DepartmentBLL> DeleteDepartment(int departmentId);
    }
}
