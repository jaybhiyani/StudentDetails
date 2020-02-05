using Students.BLL.Interfaces;
using Students.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Students.BLL.Repositories
{
    public class DepartmentRepositoryBLL : IDepartmentRepositoryBLL
    {
        private readonly Students.DAL.Interfaces.IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentRepositoryBLL(Students.DAL.Interfaces.IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public Task<DepartmentBLL> DeleteDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentBLL> GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartmentBLL>> GetDepartments()
        {
            var departmemts = await _departmentRepository.GetDepartments();
            return _mapper.Map<IEnumerable<DepartmentBLL>>(departmemts);
        }

        public Task<DepartmentBLL> PostDepartment(DepartmentBLL department)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentBLL> PutDepartment(int departmentId, DepartmentBLL department)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentBLL>> SearchDepartment(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
