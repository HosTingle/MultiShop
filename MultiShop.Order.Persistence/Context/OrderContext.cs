﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=..;inital Catalog=MultiShopOrderDb;integrated Security=true");

        }
        public DbSet<Address> Adddresses {  get; set; }
        public DbSet<OrderDetail> OrderDetils { get; set; }
        public DbSet<Ordering> Orderings { get; set; } 

    }
}
