using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SonQuangHuy.Models;

namespace SonQuangHuy.Admin.BlogManager
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
        public Blog blog { get; set; }
        [BindProperty]
        public string? Details { get; set; }
        [BindProperty]
        public IFormFile UploadAvatar {get;set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            var IsExits = _context.Blogs.Where(p=>p.BlogTitle==blog.BlogTitle).Any();
            if(!IsExits){
                if(blog.BlogTitle is null){
                    ModelState.AddModelError(string.Empty, "Tiêu đề không được để trống");
                    return Page();
                }
                if(UploadAvatar!=null){
                    blog.Avatar = Path.Combine("images","blog",blog.BlogTitle.Replace(" ","-")+"Avatar"+ UploadAvatar.ContentType.Replace("image/","."));
                    UploadFile(UploadAvatar, blog.Avatar);
                }
                if(Details is not null){
                    if(Details.Length<3800){
                        blog.Details1 = Details.Substring(0);
                    }
                    else {
                        blog.Details1 = Details.Substring(0,3800);
                        if(Details.Length>=3800 && Details.Length<7600){
                            blog.Details2 = Details.Substring(3800);
                        }
                        else {
                            blog.Details2 = Details.Substring(3800,3800);
                            if(Details.Length>=7600 && Details.Length<11400){
                                blog.Details3 = Details.Substring(7600);
                            }
                            else {
                                blog.Details3 = Details.Substring(7600,3800);
                                if(Details.Length>=11400 && Details.Length<15200){
                                    blog.Details4 = Details.Substring(11400);
                                }
                                else {
                                    blog.Details4 = Details.Substring(11400,3800);
                                    if(Details.Length>=15200 && Details.Length<19000){
                                        blog.Details5 = Details.Substring(15200);
                                    }
                                    else {
                                        blog.Details5 = Details.Substring(15200,3800);
                                        if(Details.Length>=19000 && Details.Length<22800){
                                            blog.Details6 = Details.Substring(19000);
                                        }
                                        else {
                                            blog.Details6 = Details.Substring(19000,3800);
                                            if(Details.Length>=22800 && Details.Length<26600){
                                                blog.Details7 = Details.Substring(22800);
                                            }
                                            else {
                                                blog.Details7 = Details.Substring(22800,3800);
                                                if(Details.Length>=26600 && Details.Length<30400){
                                                    blog.Details8 = Details.Substring(26600);
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
                blog.CreateDate = DateTime.Now;
                blog.ModifiedDate = DateTime.Now;
                // blog.Sold = 0;
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else{
                ModelState.AddModelError(string.Empty, "Tên Blog Đã tồn tại");
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
