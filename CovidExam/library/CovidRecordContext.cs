using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace library
{
    public class CovidRecordContext: DbContext
    {
        public CovidRecordContext(DbContextOptions<CovidRecordContext> options)
            : base(options)
        {

        }

        public DbSet<CovidRecord> CovidRecords { get; set; }
    }
}
