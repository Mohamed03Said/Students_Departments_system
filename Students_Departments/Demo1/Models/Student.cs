using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20, MinimumLength=3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Range(19, 23)]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-zA-Z0-9_+@+[a-zA-Z]+.{2,4}", ErrorMessage ="Email dose not match the pattern")]
        public string Email { get; set; }

        [Required(ErrorMessage ="*"),StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

        /*[Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOB { get; set; }

        public string? Address { get; set; }
        [(ErrorMessage = "Gender must be either 'Male' or 'Female'.")]
        public string? Gender { get; set; }*/

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int? DeptNo { get; set; }
        public virtual Department? Department { get; set; }
    }
}
