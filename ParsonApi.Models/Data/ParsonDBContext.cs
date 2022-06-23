using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsonApi.Models.Data
{
    public class ParsonDBContext : DbContext
    {
        public ParsonDBContext(DbContextOptions<ParsonDBContext> options) : base(options)
        {

        }

        public DbSet<Parson> Parson { get; set; }
    }
}
