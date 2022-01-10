using School.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.SchoolModel
{
    public class SchoolCreate
    {

        [Required]
        public string SchoolName { get; set; }
        
        
    }
}
