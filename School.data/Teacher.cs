using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.data
{
    public class Teacher
    {

        [Key]
        [Display(Name = "Teacher Id")]
        public int TeacherId { get; set; }
        [Required]
      
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        public Guid OwnerID { get; set; }
        [Required]
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        public virtual Schools Schls { get; set; }


        


    }
}
