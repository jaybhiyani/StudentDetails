using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly StudentContext _context;

        public DepartmentController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.Include(s => s.Students).ToListAsync();
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.Include(s => s.Students).FirstOrDefaultAsync(i => i.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpGet("search/{searchString}")]
        public IActionResult SearchDepartment(string searchString)
        {
            var departments = from d in _context.Departments.Include(s => s.Students) select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => d.Dep.Contains(searchString) || d.Students.Any(s => s.Name.Contains(searchString))).OrderBy(d => d.Id);
                //departments = departments.Where(d => d.Dep.Contains(searchString)).OrderBy(d => d.Id);
                if (!departments.Any())
                    return NotFound();
                return Ok(value: departments.ToList());
            }
            else
            {
                return NotFound();
            }

        }

        // PUT: api/Department/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDepartmentList(List<Department> departments)
        {
            try
            {
                foreach (Department department in departments)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound("Department with id: " + department.Id + " not found");  
                    }
                    _context.Entry(department).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Ok();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Department
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostDepartment([FromBody] List<Department> departments)
        {
            try
            {
                foreach (Department department in departments)
                {
                    _context.Departments.Add(department);
                    //_context.Students.AddRange(department.Students);
                }
                _context.SaveChanges();
                return CreatedAtAction("GetDepartments", departments);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }
        //[HttpDelete]
        //public IActionResult DeleteDepartmentList(List<Department> departments)
        //{
        //    foreach (Department department in departments)
        //    {
        //        if(!DepartmentExists(department.Id))
        //        {
        //            return NotFound("Department with id: " + department.Id + " not found");
        //        }
        //        _context.Departments.Remove(department);
        //        _context.SaveChanges();
        //    }
        //    return Ok();
        //}

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
