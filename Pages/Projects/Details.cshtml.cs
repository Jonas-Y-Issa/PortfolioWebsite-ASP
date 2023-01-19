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
    public class DetailsModel : PageModel
    {
        private readonly ASPPortfolio.Data.ASPPortfolioContext _context;

        public DetailsModel(ASPPortfolio.Data.ASPPortfolioContext context)
        {
            _context = context;
        }

      public Project Project { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.Inc == id);
            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
            }
            return Page();
        }
    }
}
