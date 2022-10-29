using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SonQuangHuy.Models;

namespace SonQuangHuy.Pages_ColorTableManager
{
    public class CreateModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public CreateModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ColorTable ColorTable { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ColorTables.Add(ColorTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
