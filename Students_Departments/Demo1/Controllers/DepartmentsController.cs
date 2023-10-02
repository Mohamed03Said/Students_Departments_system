using Demo1.BLL;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo1.Controllers
{
    public class DepartmentsController : Controller
    {
        StudentBLL studentBLL = new StudentBLL();
        DepartmentBLL deptBLL = new DepartmentBLL();
        public ViewResult Index()
        {
            var depts = deptBLL.GetAll();
            return View(depts);
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
                return BadRequest();

            var dept = deptBLL.GetByID(id.Value);
            if (dept == null)
                return NotFound();

            return View(dept);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if(ModelState.IsValid)
            {
                deptBLL.ADD(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }
        public IActionResult Delete(int? id) 
        {
            if (id == null)
                return BadRequest();
            deptBLL.Delete(id.Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            Department dept = deptBLL.GetByID(id.Value);
            if (dept == null)
                return NotFound();

            return View("update",dept);
        }
        [HttpPost]
        public IActionResult Update(Department dept) 
        {
            if (ModelState.IsValid)
            {
                deptBLL.Update(dept);
                return RedirectToAction("Index");
            }
            return View("update", dept);
        }
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return BadRequest();
            
            Student student = studentBLL.GetByID(id.Value);
            int? deptno = student.DeptNo;
            studentBLL.remove_from_dept(student);
            return RedirectToAction("details", new { id = deptno });
        }
    }
}
