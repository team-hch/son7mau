using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SonQuangHuy.Models;

namespace SonQuangHuy.Pages;

public class ColorTableModel : PageModel
{
    private readonly ILogger<DetailsModel> _logger;
    private readonly but73756_butterflycarairContext _context;

    public ColorTableModel(ILogger<DetailsModel> logger,but73756_butterflycarairContext context)
    {
        _logger = logger;
        _context = context;
    }
    public List<ColorTable> colorTables {get;set;}

    public void OnGet()
    {
        colorTables = _context.ColorTables.ToList();
    }
}

