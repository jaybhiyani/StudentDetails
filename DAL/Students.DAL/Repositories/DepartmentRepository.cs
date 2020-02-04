using Students.DAL.Entities;
using Students.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Students.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        public DepartmentRepository(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Department> DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null)
            {
                return null;
            }
            else
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return _mapper.Map<Department>(department);
            }
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departments.Include(department => department.Students).ToListAsync();
            return departments;
        }

        public async Task<Department> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public async Task<Department> PutDepartment(int departmentId, Department department)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> SearchDepartment(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
