using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonQuangHuy.Models;

namespace SonQuangHuy.Admin.ProductManager
{
    public class EditModel : PageModel
    {
        private readonly SonQuangHuy.Models.but73756_butterflycarairContext _context;

        public EditModel(SonQuangHuy.Models.but73756_butterflycarairContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public string? Details { get; set; }
        public List<SelectListItem> Units { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Kg", Text = "Kg" },
            new SelectListItem { Value = "Lít", Text = "Lít" },
        };
         public List<SelectListItem> productTypes { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "", Text = "Chọn loại sơn" },
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
        [BindProperty]
        public IFormFile? UploadAvatar {get;set;}
        [BindProperty]
        public IFormFile? UploadImage1 {get;set;}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            Details = Product.Details1+Product.Details2+Product.Details3+Product.Details4+Product.Details5+Product.Details6+Product.Details7+Product.Details8;
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
                Product.Avatar = Path.Combine("images","product",Product.ProductName.Replace(" ","-")+"Avatar"+ UploadAvatar.ContentType.Replace("image/","."));
                UploadFile(UploadAvatar, Product.Avatar);
            }
            if(UploadImage1!=null){
                Product.DetailsImage=  Path.Combine("images","product",Product.ProductName.Replace(" ","-")+"1"+ UploadImage1.ContentType.Replace("image/","."));
                UploadFile(UploadImage1,Product.DetailsImage);
            }
            if(Details is not null){
                    Product.Details2 = null;
                    Product.Details3 = null;
                    Product.Details4 = null;
                    Product.Details5 = null;
                    Product.Details6 = null;
                    Product.Details7 = null;
                    Product.Details8 = null;
                    if(Details.Length<3800){
                        Product.Details1 = Details.Substring(0);
                    }
                    else {
                        Product.Details1 = Details.Substring(0,3800);
                        if(Details.Length>=3800 && Details.Length<7600){
                            Product.Details2 = Details.Substring(3800);
                        }
                        else {
                            Product.Details2 = Details.Substring(3800,3800);
                            if(Details.Length>=7600 && Details.Length<11400){
                                Product.Details3 = Details.Substring(7600);
                            }
                            else {
                                Product.Details3 = Details.Substring(7600,3800);
                                if(Details.Length>=11400 && Details.Length<15200){
                                    Product.Details4 = Details.Substring(11400);
                                }
                                else {
                                    Product.Details4 = Details.Substring(11400,3800);
                                    if(Details.Length>=15200 && Details.Length<19000){
                                        Product.Details5 = Details.Substring(15200);
                                    }
                                    else {
                                        Product.Details5 = Details.Substring(15200,3800);
                                        if(Details.Length>=19000 && Details.Length<22800){
                                            Product.Details6 = Details.Substring(19000);
                                        }
                                        else {
                                            Product.Details6 = Details.Substring(19000,3800);
                                            if(Details.Length>=22800 && Details.Length<26600){
                                                Product.Details7 = Details.Substring(22800);
                                            }
                                            else {
                                                Product.Details7 = Details.Substring(22800,3800);
                                                if(Details.Length>=26600 && Details.Length<30400){
                                                    Product.Details8 = Details.Substring(26600);
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
            _context.Attach(Product).State = EntityState.Modified;
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
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
          return _context.Products.Any(e => e.Id == id);
        }
        void UploadFile(IFormFile file,string ImageName){
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",ImageName);
            using(var fileStream = new FileStream(path, FileMode.Create)){
                file.CopyTo(fileStream);
            }
        }
    }
}
