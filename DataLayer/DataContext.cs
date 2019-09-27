using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBUilder)
     => optionsBUilder.UseSqlite("Filename=./cardenquiries.db");

        public DbSet<CardEnquiry> CardEnquiries { get; set; }

    }
}

