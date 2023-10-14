using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.Http;

namespace crud1_human
{
    public class db:DbContext
    {
        public db():base("rt")
        {
            
        }
        public DbSet<human> humans { get; set; }
    }
}
