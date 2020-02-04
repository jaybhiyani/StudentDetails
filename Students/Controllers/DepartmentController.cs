using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Interfaces;
using Students.Models;
using Students.Repositories;

namespace Students.Controllers
{
    public class DepartmentController : BaseController
    {       
       private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentRepository.GetDepartments();
            return Ok(departments);
        }

        /// <summary>
        /// Retrieves departments from database.
        /// </summary>
        /// <param name="queryParameters">QueryParameter class object that provides required values for search and sort departments</param>
        /// <returns>List of departments from database</returns>
        //[HttpPost("list")]
        //public async Task<ActionResult<IEnumerable<Department>>> GetDepartments(QueryParameters queryParameters)
        //{
        //    if(!string.IsNullOrEmpty(queryParameters.searchString))
        //    {
        //        return await _context.Departments.Where(d => d.Dep.Contains(queryParameters.searchString)).Include(s => s.Students).ToListAsync();
        //    }
        //    else if(!string.IsNullOrEmpty(queryParameters.sortOrder))
        //    {
        //        return queryParameters.sortOrder switch
        //        {
        //            "a" => await _context.Departments.OrderBy(d => d.Dep).ToListAsync(),
        //            "d" => await _context.Departments.OrderByDescending(d => d.Dep).ToListAsync(),
        //            _ => BadRequest(),
        //        };
        //    }
        //    return await _context.Departments.Include(s => s.Students).OrderBy(d => d.Dep).ToListAsync();
        //}
        /// <summary>
        /// Retrieves department with particular department id from database.
        /// </summary>
        /// <param name="id">Value that provides id of a department to be retrieved from database.</param>
        /// <returns>Returns department with the department id provided as a parameter if exists.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartment(id);
            //var department = await _context.Departments.Include(s => s.Students).FirstOrDefaultAsync(i => i.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
        /// <summary>
        /// Updates existing department with new values provided.
        /// </summary>
        /// <param name="id">Provides id of department to be updated</param>
        /// <param name="department">Provides new values to update existing department</param>
        /// <returns>Returns Status Code 200OK if department is updated successfully or Error Codes 400BadReuest and 404NotFound</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            var updatedDeparment = await _departmentRepository.PutDepartment(id, department);
            //_context.Entry(department).State = EntityState.Modified;
            //_context.Students.UpdateRange(department.Students);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch(Exception ex)
            //{
            //    if (!DepartmentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw(ex);
            //    }
            //}

            return Ok(updatedDeparment);
        }
        /// <summary>
        /// Creates new department and stores in database.
        /// </summary>
        /// <param name="department">Provides parameter values required for new department.</param>
        /// <returns>Returns Status Code 201CreatedAtAction with new department and route</returns>
        [HttpPost]
        public async Task<IActionResult> PostDepartment(Department department)
        {
            //_context.Departments.Add(department);
            //await _context.SaveChangesAsync();
            var departmentPost = await _departmentRepository.PostDepartment(department);

            return CreatedAtAction("GetDepartment", new { id = departmentPost.Id }, departmentPost);
        }
        /// <summary>
        /// Deletes department with id provided as a paramater.
        /// </summary>
        /// <param name="id">Provides value of department id of department to be deleted</param>
        /// <returns>Returns department that is deleted successfully or Status code 404NotFound if department does not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.DeleteDepartment(id);
            //var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            //_context.Departments.Remove(department);
            //await _context.SaveChangesAsync();

            return Ok(department);
        }
        /// <summary>
        /// Checks whether department with department id provided is present in database or not.
        /// </summary>
        /// <param name="id">Provides department id to be checked for existence.</param>
        /// <returns>Returns true if department is found else false.</returns>
        //private bool DepartmentExists(int id)
        //{
        //    return _context.Departments.Any(e => e.Id == id);
        //}
    }
}
