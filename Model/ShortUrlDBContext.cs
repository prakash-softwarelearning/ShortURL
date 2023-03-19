using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShortUrlDBContext : DbContext
    {
        public ShortUrlDBContext(DbContextOptions option) : base(option) { }

        public DbSet<ShortUrl> ShortUrl { get; set; }

    }
}
