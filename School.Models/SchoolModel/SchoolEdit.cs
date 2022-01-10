using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.SchoolModel
{
  public  class SchoolEdit
  {
        public int SchoolId { get; set; }

        [Required]
        [Display(Name="School Name")]
        public string SchoolName { get; set; }
  }
}
