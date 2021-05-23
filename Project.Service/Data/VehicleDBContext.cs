using System;
using System.Collections.Generic;
using System.Text;
using Cars.Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars.Service.Data
{
    public class VehicleDBContext : IdentityDbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options)
            : base(options)
        {
        }
    }
}
