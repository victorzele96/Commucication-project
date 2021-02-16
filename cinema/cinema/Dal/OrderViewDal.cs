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
            modelBuilder.Entity<OrderViewModels>().ToTable("tblOrderView");
        }
        public DbSet<OrderViewModels> Registration { get; set; }
    }
}