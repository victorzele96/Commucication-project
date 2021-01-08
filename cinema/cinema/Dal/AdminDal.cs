using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.Dal
{
    public class AdminDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AdminModel>().ToTable("tblAdmin");
        }
        public DbSet<AdminModel> adminLogin { get; set; }
    }
}