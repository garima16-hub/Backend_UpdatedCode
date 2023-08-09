
using System;
using System.Collections.Generic;
using _3DModels.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using _3DModels.Models;

namespace _3DModels.Models

{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
        {
        }








        public virtual DbSet<Orders> Orders { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public DbSet<Users> users { get; set; }

        //public DbSet<Users> Users { get; set; }

        public async Task<IEnumerable<string>> GetDistinctRolesAsync()
        {
            return await users.Select(u => u.Role).Distinct().ToListAsync();
        }




        public DbSet<ModelCoordinator> ModelCoordinators { get; set; }


        public DbSet<ModelDesigner> ModelDesigners { get; set; }
        public DbSet<ThreeDModel> ThreeDModels { get; set; }

        public DbSet<InventoryItem> InventoryItems { get; set; }


        public ModelDbContext(DbContextOptions<ModelDbContext> options)
                : base(options)
        {
        }

    }
}











