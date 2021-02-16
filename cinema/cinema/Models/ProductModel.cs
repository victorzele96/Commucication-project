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

        [StringLength(30, MinimumLength = 2)]
        public String MovieName { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public String MovieDescription { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The  Movie Genre contain only letters.")]
        [StringLength(40, MinimumLength = 1)]
        public String MovieGenre { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "The Movie Age Limit contain only digits.")]
        public int MovieAgeLimit { get; set; }

        [RegularExpression("^[1-3][0-9][0-9][0-9]$", ErrorMessage = "The Relase Year contain only digits.")]
        public int RelaseYear { get; set; }

        // chack validazia for img
        [RegularExpression("[^\\s]+(\\.(?i)(jpe?g|png))$", ErrorMessage = "The Movie Image must be correct type(jpe|jpg|png).")]
        [StringLength(100, MinimumLength = 1)]
        public String MovieImg { get; set; }


        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "The Movie Price contain only digits.")]
        public int MoviePrice { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "The Hall Number contain only digits.")]
        public int HallNum { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "The Seats Number contain only digits.")]
        public int SeatsNum { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MovieDayPlay { get; set; }
    }
}