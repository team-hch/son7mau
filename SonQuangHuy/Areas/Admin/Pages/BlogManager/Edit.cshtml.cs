using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;

namespace SonQuangHuy.Admin.BlogManager
{
    public class EditModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public EditModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blog Blog { get; set; }
        [BindProperty]
        public string? Details { get; set; }
        [BindProperty]
        public IFormFile? UploadAvatar {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog =  await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
            Details = Blog.Details1+Blog.Details2+Blog.Details3+Blog.Details4+Blog.Details5+Blog.Details6+Blog.Details7+Blog.Details1+Blog.Details8;
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
            
            if(UploadAvatar!=null){
                Blog.Avatar = Path.Combine("images","product",Blog.BlogTitle.Replace(" ","-")+"Avatar"+ UploadAvatar.ContentType.Replace("image/","."));
                UploadFile(UploadAvatar, Blog.Avatar);
            }
            if(Details is not null){
                    if(Details.Length<3800){
                        Blog.Details1 = Details.Substring(0);
                    }
                    else {
                        Blog.Details1 = Details.Substring(0,3800);
                        if(Details.Length>=3800 && Details.Length<7600){
                            Blog.Details2 = Details.Substring(3800);
                        }
                        else {
                            Blog.Details2 = Details.Substring(3800,3800);
                            if(Details.Length>=7600 && Details.Length<11400){
                                Blog.Details3 = Details.Substring(7600);
                            }
                            else {
                                Blog.Details3 = Details.Substring(7600,3800);
                                if(Details.Length>=11400 && Details.Length<15200){
                                    Blog.Details4 = Details.Substring(11400);
                                }
                                else {
                                    Blog.Details4 = Details.Substring(11400,3800);
                                    if(Details.Length>=15200 && Details.Length<19000){
                                        Blog.Details5 = Details.Substring(15200);
                                    }
                                    else {
                                        Blog.Details5 = Details.Substring(15200,3800);
                                        if(Details.Length>=19000 && Details.Length<22800){
                                            Blog.Details6 = Details.Substring(19000);
                                        }
                                        else {
                                            Blog.Details6 = Details.Substring(19000,3800);
                                            if(Details.Length>=22800 && Details.Length<26600){
                                                Blog.Details7 = Details.Substring(22800);
                                            }
                                            else {
                                                Blog.Details7 = Details.Substring(22800,3800);
                                                if(Details.Length>=26600 && Details.Length<30400){
                                                    Blog.Details8 = Details.Substring(26600);
                                                }
                                                else {
                                                    ModelState.AddModelError(string.Empty, "Mô tả bài viết quá dài");
                                                    return Page();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            _context.Attach(Blog).State = EntityState.Modified;
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Blog.Id))
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

        private bool ProductExists(int id)
        {
          return _context.Blogs.Any(e => e.Id == id);
        }
        void UploadFile(IFormFile file,string ImageName){
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",ImageName);
            using(var fileStream = new FileStream(path, FileMode.Create)){
                file.CopyTo(fileStream);
            }
        }
    }
}
