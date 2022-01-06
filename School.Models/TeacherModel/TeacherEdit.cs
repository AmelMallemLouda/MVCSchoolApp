using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.TeacherModel
{
    class TeacherEdit
    {

        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
    }
}
