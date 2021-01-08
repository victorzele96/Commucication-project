using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.Dal
{
    public class OrderViewDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderViewModel>().ToTable("tblOrderView");
        }
        public DbSet<OrderViewModel> Registration { get; set; }
    }
}