using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonQuangHuy.Models;
namespace SonQuangHuy.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly but73756_butterflycarairContext _context;

    public IndexModel(ILogger<IndexModel> logger,but73756_butterflycarairContext context)
    {
        _logger = logger;
        _context = context;
    }
    public List<Product> products {get;set;}
    public HashSet<string> productType {get;set;}
    public void OnGet()
    {
        products = _context.Products.ToList();
        if(products.Count()>0){
            productType = products.Select(x=>x.ProductType).ToHashSet<string>();
        }
    }
}
