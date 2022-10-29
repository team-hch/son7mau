using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonQuangHuy.Models;

namespace SonQuangHuy.Pages;

public class DetailsModel : PageModel
{
    private readonly ILogger<DetailsModel> _logger;
    private readonly but73756_butterflycarairContext _context;

    public DetailsModel(ILogger<DetailsModel> logger,but73756_butterflycarairContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Product product {get;set;}

    public void OnGet(int? id)
    {
        if(id!=null){
            product = _context.Products.Where(x => x.Id==id).FirstOrDefault();
        }
    }
}

