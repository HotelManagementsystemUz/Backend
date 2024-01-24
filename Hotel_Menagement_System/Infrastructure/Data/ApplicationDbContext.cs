﻿using Domain.Entities.HotelEntiries;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        // Your dbsets here
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Room> Rooms { get; set; }  
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Your configurations here

            base.OnModelCreating(builder);
        }
    }
}