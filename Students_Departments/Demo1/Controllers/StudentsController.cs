using Demo1.BLL;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo1.Controllers
{
    public class StudentsController : Controller
    {
        StudentBLL studentBLL = new StudentBLL();
        DepartmentBLL deptBLL = new DepartmentBLL();
        public ViewResult Index()
        {
            var students = studentBLL.GetAll();
            return View(students);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var student = studentBLL.GetByID(id.Value);
            if (student == null)
                return NotFound();

            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "DeptId", "DeptName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentBLL.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Depts = new SelectList(deptBLL.GetAll(), "DeptId", "DeptName");
                return View(student);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            studentBLL.Delete(id.Value);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();

            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "DeptId", "DeptName");
            var student = studentBLL.GetByID(id.Value);
            if (student == null)
                return NotFound();

            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            studentBLL.Update(student);
            return RedirectToAction("index");
        }
        /*
         * delete this and implement it again
         */
        public IActionResult Search(string searchType, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchType) || string.IsNullOrWhiteSpace(searchTerm))
                return RedirectToAction("Index");

            List<Student> searchResults = new List<Student>();

            if (searchType == "id")
            {
                // Search by ID
                if (int.TryParse(searchTerm, out int studentId))
                {
                    var student = studentBLL.GetByID(studentId); // Replace with your data retrieval logic
                    if (student != null)
                    {
                        searchResults.Add(student);
                    }
                }
            }
            else if (searchType == "name")
            {
                // Search by Name
                searchResults = studentBLL.GetBySearch(searchTerm); // Replace with your data retrieval logic
            }

            return View("search", searchResults);
        }
    }

}
