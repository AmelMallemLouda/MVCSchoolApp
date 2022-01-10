using School.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.ClassRoomModel
{
    public class ClassRoomListItem
    {

        public int ClassRoomId { get; set; }
        [Required]
        [Display(Name = "Classroom")]
        public string ClassRomName { get; set; }
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        public virtual Schools Schls { get; set; }
    }
}
