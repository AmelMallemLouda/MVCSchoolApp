using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.data
{
    public class Schools
    {
        [Key]
        public int SchoolId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        public Guid OwnerID { get; set; }
        public virtual List<ClassRoom> ClassRooms { get; set; }

        public virtual List<Teacher> Teachers  { get; set; }
    }
}
