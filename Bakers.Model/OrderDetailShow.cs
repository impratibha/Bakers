﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public class OrderDetailShow
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Quantity { get; set; }


        

    }
  

}
