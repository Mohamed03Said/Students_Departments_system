using Demo1.Context;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.BLL
{
    public class DepartmentBLL
    {
        CollegeContext DB = new CollegeContext();
        public List<Department> GetAll()
        {
            return DB.Departments.Include(s => s.Students).ToList();
        }
        public Department GetByID(int id)
        {
            return DB.Departments.Include(d => d.Students).SingleOrDefault(a => a.DeptId == id);
        }

        public Department ADD(Department department)
        {
            DB.Add(department);
            DB.SaveChanges();
            return department;
        }
        public void Update(Department department)
        {
            DB.Departments.Update(department);
            DB.SaveChanges();
        }
        public void Delete(int id)
        {
            Department department = GetByID(id);
            if(department != null)
            {
                DB.Departments.Remove(department);
                DB.SaveChanges();
            }
        }
    }
}
