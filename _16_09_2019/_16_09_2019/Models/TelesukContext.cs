using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_09_2019.Models
{
    public class TelesukContext:DbContext
    {
        public DbSet<Telesuk> Telesuky { get; set; }
        public TelesukContext(DbContextOptions<TelesukContext> options) :
            base(options)
        {
                
        }
    }
}
