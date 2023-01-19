using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPPortfolio.Data;
using ASPPortfolio.Models;

namespace ASPPortfolio.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ASPPortfolio.Data.ASPPortfolioContext _context;

        public IndexModel(ASPPortfolio.Data.ASPPortfolioContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Project != null)
            {
                Project = await _context.Project.ToListAsync();
            }
        }
    }
}
