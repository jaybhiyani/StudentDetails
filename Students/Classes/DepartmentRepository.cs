using Students.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Students.Classes;
using AutoMapper;
using Students.DAL.Entities;

namespace Students.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(StudentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<DepartmentView>> GetDepartments()
        {
            //var dep = await _context.Departments.Include(department => department.Students).ToListAsync();
            //var depMapper = _mapper.Map<IEnumerable<DepartmentView>>(dep);
            var departments =  _mapper.Map<IEnumerable<DepartmentView>>(await _context.Departments.Include(department => department.Students).ToListAsync());
            return departments;
        }

        public async Task<DepartmentView> GetDepartment(int departmentId)
        {
            var department = _mapper.Map<DepartmentView>(await _context.Departments.Include(department => department.Students).FirstOrDefaultAsync(department => department.Id == departmentId));
            if ( department == null )
            {
                return null;
            }
            return department;
        }

        public async Task<DepartmentView> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentView>(department);
        }
        //public async Task<DepartmentView> PutDepartment(Department department)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Department>> IDepartmentRepository.GetDepartments()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<IEnumerable<DepartmentView>> SearchDepartment(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentView> PutDepartment(int departmentId, Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            _context.Students.UpdateRange(department.Students);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!DepartmentExists(departmentId))
                {
                    return null;
                }
                else
                {
                    throw (ex);
                }
            }
            return _mapper.Map<DepartmentView>(department);
        }

        public async Task<DepartmentView> DeleteDepartment(int departmentId)
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
                return _mapper.Map<DepartmentView>(department);
            }
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
