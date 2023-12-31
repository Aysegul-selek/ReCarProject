﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        [Key]
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string File { get; set; }
        public DateTime ImageDate { get; set; }
    }
}
