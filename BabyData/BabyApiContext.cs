using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BabyData
{
    public class BabyApiContext : DbContext
    {
        public BabyApiContext(DbContextOptions<BabyApiContext> options)
            : base(options)
        {

        }
        
        public DbSet<BabyApi> BabyApis { get; set; }
    }
}
