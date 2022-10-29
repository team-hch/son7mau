using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SonQuangHuy.Admin.ProductManager
{
    public class IndexModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public IndexModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string productType { get; set; }	
   		public List<SelectListItem> productTypes { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "", Text = "Tất cả" },
        new SelectListItem { Value = "Sơn Dulux", Text = "Sơn Dulux" },
        new SelectListItem { Value = "Sơn Jotun", Text = "Sơn Jotun" },
        new SelectListItem { Value = "Sơn Maxilite", Text = "Sơn Maxilite" },
        new SelectListItem { Value = "Sơn Expo", Text = "Sơn Expo" },
        new SelectListItem { Value = "Sơn Nippon", Text = "Sơn Nippon" },
        new SelectListItem { Value = "Sơn Mykolor", Text = "Sơn Mykolor" },
        new SelectListItem { Value = "Sơn Kova", Text = "Sơn Kova" },
        new SelectListItem { Value = "Sơn Bạch Tuyết", Text = "Sơn Bạch Tuyết" },
        new SelectListItem { Value = "Sơn Toa", Text = "Sơn Toa" },
        new SelectListItem { Value = "Sơn International", Text = "Sơn International" },
    };
        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync(string? productType)
        {
            if(productType is not null){
                Product = await _context.Products.Where(p=>p.ProductType==productType).ToListAsync();
            }
            else
                if (_context.Products != null)
                {
                    Product = await _context.Products.ToListAsync();
                }
        }
    }
}
