using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;

namespace SonQuangHuy.Admin.BlogManager
{
    public class DetailsModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public DetailsModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

      public Blog Blog { get; set; }
      public string Details {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            else 
            {
                Blog = blog;
                Details = Blog.Details1+Blog.Details2+Blog.Details3+Blog.Details4+Blog.Details5+Blog.Details6+Blog.Details7+Blog.Details1+Blog.Details8;
            }
            return Page();
        }
    }
}
