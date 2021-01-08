using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class OrderModel
    {
        [Key]
        [RegularExpression("^[0-9]+$", ErrorMessage = "The Order Id contain only digits.")]
        public String OrderId { get; set; }

        /*
                [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The Username contain only digits and letters.")]
                public String AdminName { get; set; }
         */
    }
}