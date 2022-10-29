using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonQuangHuy.Models;
namespace SonQuangHuy.Pages;

public class NewsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly but73756_butterflycarairContext _context;

    public NewsModel(ILogger<IndexModel> logger,but73756_butterflycarairContext context)
    {
        _logger = logger;
        _context = context;
    }
    public List<Blog> blogs {get;set;}
    public void OnGet()
    {
        blogs = _context.Blogs.ToList();
    }
}
