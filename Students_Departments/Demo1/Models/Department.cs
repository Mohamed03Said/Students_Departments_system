using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
