using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace caseEngSoftApi.Models
{
    public class caseEngSoftContext : DbContext
    {
        public caseEngSoftContext(DbContextOptions<caseEngSoftContext> options)
            : base(options)
        {
        }

        public DbSet<caseEngSoftItem> caseEngSoftItems { get; set; }
    }
}
