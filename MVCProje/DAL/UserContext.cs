using MVCProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProje.DAL
{
    public class UserContext: DbContext
    {
        public UserContext():base("cstr"){
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tblUser");
            modelBuilder.Entity<User>().Property(user => user.Name).HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<User>().Property(user => user.Username).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<User>().Property(user => user.role).HasColumnType("int");



            modelBuilder.Entity<Serie>().ToTable("tblSerie");
            modelBuilder.Entity<Serie>().Property(tv => tv.title).IsRequired().HasColumnType("varchar").HasMaxLength(70);
            modelBuilder.Entity<Serie>().Property(tv => tv.rating).IsRequired().HasColumnType("varchar").HasMaxLength(3);
            modelBuilder.Entity<Serie>().Property(tv => tv.category).HasColumnType("varchar").HasMaxLength(30);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}