using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SonQuangHuy.Admin.BlogManager
{
    public class IndexModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public IndexModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }
        public List<Blog> blogs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            blogs = await _context.Blogs.ToListAsync();
        }
    }
}
