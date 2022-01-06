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
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }

        public Guid OwnerID { get; set; }


    }
}
