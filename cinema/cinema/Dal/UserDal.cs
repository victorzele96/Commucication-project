using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.Dal
{
    public class UserDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RegistrationModel>().ToTable("tblUser");
        }
        public DbSet<RegistrationModel> Registration { get; set; }
    }
}