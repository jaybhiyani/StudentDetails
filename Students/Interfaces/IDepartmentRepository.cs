﻿using Students.Classes;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Students.DAL.Entities;

namespace Students.Interfaces
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
