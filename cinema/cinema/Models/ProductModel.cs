using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class ProductModel
    {
        [Key]
        [RegularExpression("^[0-9]+$", ErrorMessage = "The Product Id contain only digits.")]
        public String ProductId { get; set; }

        /*
            [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The Username contain only digits and letters.")]
            public String AdminName { get; set; }
         */
    }
}