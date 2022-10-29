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
    public class DeleteModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public DeleteModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ColorTable ColorTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ColorTables == null)
            {
                return NotFound();
            }

            var colortable = await _context.ColorTables.FirstOrDefaultAsync(m => m.Id == id);

            if (colortable == null)
            {
                return NotFound();
            }
            else 
            {
                ColorTable = colortable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ColorTables == null)
            {
                return NotFound();
            }
            var colortable = await _context.ColorTables.FindAsync(id);

            if (colortable != null)
            {
                ColorTable = colortable;
                _context.ColorTables.Remove(ColorTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
