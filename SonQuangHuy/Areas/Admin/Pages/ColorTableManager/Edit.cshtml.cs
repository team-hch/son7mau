using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;

namespace SonQuangHuy.Pages_ColorTableManager
{
    public class EditModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public EditModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ColorTable ColorTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ColorTables == null)
            {
                return NotFound();
            }

            var colortable =  await _context.ColorTables.FirstOrDefaultAsync(m => m.Id == id);
            if (colortable == null)
            {
                return NotFound();
            }
            ColorTable = colortable;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ColorTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorTableExists(ColorTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColorTableExists(int id)
        {
          return _context.ColorTables.Any(e => e.Id == id);
        }
    }
}
