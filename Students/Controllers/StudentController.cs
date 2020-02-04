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
    //public class StudentController : BaseController
    //{
    //    private readonly StudentContext _context;

    //    public StudentController(StudentContext context)
    //    {
    //        _context = context;
    //    }
    //    /// <summary>
    //    /// Retrieves students from database.
    //    /// </summary>
    //    /// <returns>Returns list of departments from database.</returns>
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    //    {
    //        return await _context.Students.ToListAsync();
    //    }
    //    /// <summary>
    //    /// Retrieves student with particular student id from database.
    //    /// </summary>
    //    /// <param name="id">Value that provides id of a student to be retrieved from database.</param>
    //    /// <returns>Returns department with the student id provided as a parameter if exists.</returns>
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Student>> GetStudent(int id)
    //    {
    //        var student = await _context.Students.FindAsync(id);

    //        if (student == null)
    //        {
    //            return NotFound();
    //        }

    //        return student;
    //    }

    //    /// <summary>
    //    /// Updates existing student with new values provided.
    //    /// </summary>
    //    /// <param name="id">Provides id of student to be updated.</param>
    //    /// <param name="student">Provides new values to update existing student</param>
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutStudent(int id, Student student)
    //    {
    //        if (id != student.SId)
    //        {
    //            return BadRequest();
    //        }
    //        _context.Entry(student).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!StudentExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return Ok();
    //    }
    //    /// <summary>
    //    /// Creates new student and stores in database.
    //    /// </summary>
    //    /// <param name="student">Provides parameter values required for new student.</param>
    //    /// <returns>Returns Status Code 201CreatedAtAction with new student and route.</returns>
    //    [HttpPost]
    //    public async Task<ActionResult<Student>> PostStudent(Student student)
    //    {
    //        _context.Students.Add(student);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetStudent", new { id = student.SId }, student);
    //    }

    //    /// <summary>
    //    /// Deletes student with id provided as a paramater.
    //    /// </summary>
    //    /// <param name="id">Provides value of student id of student to be deleted.</param>
    //    /// <returns>Returns student that is deleted successfully or Status code 404NotFound if student does not exist.</returns>
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<Student>> DeleteStudent(int id)
    //    {
    //        var student = await _context.Students.FindAsync(id);
    //        if (student == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Students.Remove(student);
    //        await _context.SaveChangesAsync();

    //        return student;
    //    }
    //    /// <summary>
    //    /// Checks whether student with student id provided is present in database or not.
    //    /// </summary>
    //    /// <param name="id">Provides student id to be checked for existence.</param>
    //    /// <returns>Returns true if student is found else false.</returns>
    //    private bool StudentExists(int id)
    //    {
    //        return _context.Students.Any(e => e.SId == id);
    //    }
    //}
}
