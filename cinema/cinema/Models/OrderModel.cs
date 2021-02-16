using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class OrderModel
    {
        [Key, Column(Order = 1)]
        [RegularExpression("^[1-9]+$", ErrorMessage = "The Hall contain only digits.")]
        public int Hall { get; set; }

        [Key, Column(Order = 2)]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z][0-9](,[a-zA-Z][0-9])*$", ErrorMessage = "The Seats contain only letter and numbers.")]
        public String Seat { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public String MovieName { get; set; }

        [Key, Column(Order = 4)]
        [Display(Name = "Show Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MovieDatePlay { get; set; }

        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "The First Name contain only letters.")]
        public String FirstName { get; set; }


        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "The Last Name contain only letters.")]
        public String LastName { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "The Movie Price contain only digits.")]
        public int Price { get; set; }
    }
}