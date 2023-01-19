using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPPortfolio.Models;

namespace ASPPortfolio.Data
{
    public class ASPPortfolioContext : DbContext
    {
        public ASPPortfolioContext (DbContextOptions<ASPPortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<ASPPortfolio.Models.Project> Project { get; set; } = default!;
    }
}
