using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.SchoolModel
{
  public  class SchoolListItem
    {

        public int SchoolId { get; set; }

        [Display(Name="Schoo lName")]
        public string SchoolName { get; set; }
    }
}
