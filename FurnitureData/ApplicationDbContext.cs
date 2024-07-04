using FurnitureData.Furniture_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureData
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FurnitureTableEntity>Furniture { get; set; }
        public DbSet<RestaurantTableEntity> RestrauntTable { get; set; }
    }
}
