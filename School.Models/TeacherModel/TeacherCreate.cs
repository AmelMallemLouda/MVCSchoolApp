using School.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.TeacherModel
{
    public class TeacherCreate
    {

       
        [Required]
        [Display(Name ="Teacher Name")]
        public string TeacherName { get; set; }
        [Display(Name = "School Id")]
        [Required]
        public int SchoolId { get; set; }
        public virtual Schools Schls { get; set; }
    }
}
