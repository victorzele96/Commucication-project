using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.ViewModel
{
    public class OrderViewModel
    {
        public OrderModel orderModel { get; set; }

        public List<OrderModel> orderModelList { get; set; }
    }
}