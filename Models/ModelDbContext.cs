
using System;
using System.Collections.Generic;
using _3DModels.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
        {
        }

        public ModelDbContext(DbContextOptions<ModelDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Orders> Orders { get; set; } = null!;
        public virtual DbSet<Model> Models{ get; set; } = null!;
        public virtual DbSet<Users> users { get; set; } = null!;
        

        
        public  DbSet<ModelCoordinator> ModelCoordinators { get; set; }


        public DbSet<ModelDesigner> ModelDesigners { get; set; }
        public DbSet<ThreeDModel> ThreeDModels { get; set; }


    }

    
    }










