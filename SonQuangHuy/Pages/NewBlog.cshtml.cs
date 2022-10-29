using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonQuangHuy.Models;
namespace SonQuangHuy.Pages;

public class NewBlogModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly but73756_butterflycarairContext _context;

    public NewBlogModel(ILogger<IndexModel> logger,but73756_butterflycarairContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Blog blog {get;set;}
    public IActionResult OnGet(int? id)
    {
        if(id is not null){
            blog = _context.Blogs.Where(b=>b.Id==id).FirstOrDefault();
            return Page();
        }
            return NotFound();
    }
}
