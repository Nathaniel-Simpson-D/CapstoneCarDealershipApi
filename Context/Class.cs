using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerCapstone.Context
{
    public class DealershipBdContext : DbContext
    {
        public DealershipBdContext(DbContextOptions options)
            :base (options)
        {

        }
        public DbSet<CarModel> CarModels { get; set; }
    }
}
