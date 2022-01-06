﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.ClassRoomModel
{
   public  class ClassRoomEdit
    {

        public int ClassRoomId { get; set; }
        [Required]
        [Display(Name = "Classroom")]
        public string ClassRomName { get; set; }
    }
}
