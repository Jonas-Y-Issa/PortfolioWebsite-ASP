using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPPortfolio.Data;
namespace ASPPortfolio.Models;

public class IndexModel : PageModel
{
    private ASPPortfolioContext Context { get; }
    public IndexModel(ASPPortfolioContext _context)
    {
        this.Context = _context;
    }

    public List<Project> objects { get; set; }
 
    public void OnGet()
    {
        this.objects = (from project in this.Context.Project.Take(10)
                          select project).ToList();
    }
    
}
