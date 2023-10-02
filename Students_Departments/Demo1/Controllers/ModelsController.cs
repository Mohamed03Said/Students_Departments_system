using Demo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Demo1.Models;
using Demo1.BLL;

namespace Demo1.Controllers
{
    public class ModelsController : Controller
    {
        public ViewResult Display()
        {
            Student s1 = new Student() { Id = 1, Name = "Mohamed", Age = 20 };
            Student s2 = new Student() { Id = 2, Name = "Ahmed", Age = 19 };
            Student s3 = new Student() { Id = 3, Name = "Ali", Age = 20 };

            Department d1 = new Department() { DeptName = "CS", DeptId = 1};
            Department d2 = new Department() { DeptName = "IT", DeptId = 2 };
            Department d3 = new Department() { DeptName = "IS", DeptId = 3 };

            StudentDepartmentView model1 = new StudentDepartmentView() { Student = s1, Department = d1 };
            StudentDepartmentView model2 = new StudentDepartmentView() { Student = s2, Department = d2 };
            StudentDepartmentView model3 = new StudentDepartmentView() { Student = s3, Department = d3 };
            List<StudentDepartmentView> models = new List<StudentDepartmentView>() { model1, model2, model3 };
            ViewBag.Models = models;
            return View();
        }
    }
}
