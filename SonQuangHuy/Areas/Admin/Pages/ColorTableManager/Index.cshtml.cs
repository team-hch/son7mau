using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;

namespace SonQuangHuy.Pages_ColorTableManager
{
    public class IndexModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public IndexModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        public IList<ColorTable> ColorTable { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ColorTables != null)
            {
                ColorTable = await _context.ColorTables.ToListAsync();
            }
        }
    }
}
