using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.Dal
{
    public class OrderDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderModel>().ToTable("tblOrder");
        }
        public DbSet<OrderModel> OrderData { get; set; }
    }
}