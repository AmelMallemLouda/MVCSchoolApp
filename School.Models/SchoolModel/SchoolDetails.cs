using School.Models.ClassRoomModel;
using School.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.SchoolModel
{
   public  class SchoolDetails
    {

        [Required]
        public string SchoolName { get; set; }

        public int SchoolId { get; set; }

        public virtual List<ClassRoomListItem> ClassRooms { get; set; }

        public virtual List<TeacherListItem> Teachers { get; set; }
    }
}
