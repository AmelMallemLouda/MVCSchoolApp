using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.data
{
    public class ClassRoom
    {

        [Key]
        [Display(Name ="Classroom Id")]
        public int ClassRoomId { get; set; }
        [Required]
        [Display(Name = "Classroom Name")]
        public string ClassRoomName { get; set; }

        public Guid OwnerID { get; set; }


        [Required]
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        public virtual Schools Schls { get; set; }
    }
}
