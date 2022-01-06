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
        public int ClassRoomId { get; set; }
        [Required]
        public string ClassRoomName { get; set; }

        public Guid OwnerID { get; set; }
    }
}
