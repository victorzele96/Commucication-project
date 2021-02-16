using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.ViewModel
{
    public class ProductViewModel
    {
        public ProductModel productModel { get; set; }

        public List<ProductModel> productModelList { get; set; }
    }
}