using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace caseEngSoftApi.Models
{
    public class hashtagContext : DbContext
    {
        public hashtagContext(DbContextOptions<hashtagContext> options)
            : base(options)
        {
        }

        public DbSet<hashtagDTO> hashtagItems { get; set; }
    }
}
