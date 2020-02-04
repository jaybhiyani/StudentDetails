//using Students.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Students.Classes;
using AutoMapper;
//using Students.DAL.Entities;
using Students.Interfaces;
using Students.Models;

namespace Students.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //private readonly StudentContext _context;
        private readonly Students.DAL.Interfaces.IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentRepository(IMapper mapper, Students.DAL.Interfaces.IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _departmentRepository.GetDepartments();
            return _mapper.Map<IEnumerable<Department>>(departments);
            //var departments =  _mapper.Map<IEnumerable<DAL.Entities.Department>>(await _context.Departments.Include(department => department.Students).ToListAsync());
            //return departments;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            var department = await _departmentRepository.GetDepartment(departmentId);
            //var department = _mapper.Map<Department>(await _context.Departments.Include(department => department.Students).FirstOrDefaultAsync(department => department.Id == departmentId));
            if (department == null)
            {
                return null;
            }
            return _mapper.Map<Department>(department);
        }

        public async Task<Department> PostDepartment(Department department)
        {
            var newDepartment = await _departmentRepository.PostDepartment(_mapper.Map<DAL.Entities.Department>(department));
            //_context.Departments.Add(department);
            //await _context.SaveChangesAsync();
            return _mapper.Map<Department>(department);
        }

        public Task<IEnumerable<Department>> SearchDepartment(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> PutDepartment(int departmentId, Department department)
        {
            var updatedDepartment = await _departmentRepository.PutDepartment(departmentId, _mapper.Map<DAL.Entities.Department>(department));
            return _mapper.Map<Department>(updatedDepartment);
            //_context.Entry(department).State = EntityState.Modified;
            //_context.Students.UpdateRange(department.Students);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    if (!DepartmentExists(departmentId))
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw (ex);
            //    }
            //}
            //return _mapper.Map<Department>(department);
        }

        public async Task<Department> DeleteDepartment(int departmentId)
        {
            var deletedDepartment = await _departmentRepository.DeleteDepartment(departmentId);
            return _mapper.Map<Department>(deletedDepartment);
            //var department = await _context.Departments.FindAsync(departmentId);
            //if (department == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    _context.Departments.Remove(department);
            //    await _context.SaveChangesAsync();
            //    return _mapper.Map<Department>(department);
            //}
        }

        //private bool DepartmentExists(int id)
        //{
        //    return _context.Departments.Any(e => e.Id == id);
        //}
    }
}
