using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SonQuangHuy.Models;

namespace SonQuangHuy.Admin.ProductManager
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
        public Product Product { get; set; }
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
    public IFormFile UploadAvatar {get;set;}
    [BindProperty]
    public IFormFile UploadImage1 {get;set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            var IsExits = _context.Products.Where(p=>p.ProductName==Product.ProductName).Any();
            if(!IsExits){
                if(Product.ProductType is null){
                    ModelState.AddModelError(string.Empty, "Bạn chưa chọn loại sơn");
                    return Page();
                }
                if(UploadAvatar!=null){
                    Product.Avatar = Path.Combine("images","product",Product.ProductName.Replace(" ","-")+"Avatar"+ UploadAvatar.ContentType.Replace("image/","."));
                    UploadFile(UploadAvatar, Product.Avatar);
                }
                if(UploadImage1!=null){
                    Product.DetailsImage =  Path.Combine("images","product",Product.ProductName.Replace(" ","-")+"1"+ UploadImage1.ContentType.Replace("image/","."));
                    UploadFile(UploadImage1,Product.DetailsImage);
                }
                Product.Details2 = null;
                Product.Details3 = null;
                Product.Details4 = null;
                Product.Details5 = null;
                Product.Details6 = null;
                Product.Details7 = null;
                Product.Details8 = null;
                if(Details is not null){
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
                                                    ModelState.AddModelError(string.Empty, "Mô tả sản phẩm quá dài, vui lòng viết ngắn gọn hoặc liên hệ quản trị viên tăng giới hạn");
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
                Product.CreateDate = DateTime.Now;
                Product.ModifiedDate = DateTime.Now;
                // Product.Sold = 0;
                _context.Products.Add(Product);
                await _context.SaveChangesAsync();
                return Page();
            }
            else{
                ModelState.AddModelError(string.Empty, "Tên sản phẩm đã tồn tại");
                return Page();
            }
        }
        void UploadFile(IFormFile file,string ImageName){
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",ImageName);
            using(var fileStream = new FileStream(path, FileMode.Create)){
                file.CopyTo(fileStream);
            }
        }
    }
}
