using Demo1.Context;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.BLL
{
    public class StudentBLL
    {
        CollegeContext DB = new CollegeContext();
        public List<Student> GetAll()
        {
            return DB.Students.Include(d => d.Department).ToList();
        }
        public Student GetByID(int id)
        {
            return DB.Students.Include(d => d.Department).SingleOrDefault(a => a.Id == id);
        }
        public List<Student> GrpupByDept(int id)
        {
            return DB.Students.Where(s => s.DeptNo == id).ToList();
        }
        public Student Add(Student student)
        {
            DB.Students.Add(student);
            DB.SaveChanges();
            return student;
        }
        public void Delete(int id)
        {
            Student student = GetByID(id);
            if (student != null)
            {
                DB.Students.Remove(student);
                DB.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            DB.Students.Update(student);
            DB.SaveChanges();
        }

        public void remove_from_dept(Student student)
        {
            student.DeptNo = null;
            DB.SaveChanges();
        }

        public List<Student> GetBySearch(string search)
        {
            return DB.Students.Include(d => d.Department).Where(student => student.Name.Contains(search)).ToList();
        }
    }
}
