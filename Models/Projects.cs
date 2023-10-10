using System.ComponentModel.DataAnnotations;

namespace ASPPortfolio.Models;

public class Project
{
    [Key]
    public int Inc { get; set; }
    public string? Preface { get; set; }
    public string? Title { get; set; }
    public string? ExtLink { get; set; }
    public string? Description { get; set; }

}
