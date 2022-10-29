using System;
using System.IO;
using System.Threading.Tasks;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace elFinder.NetCore.Web.Controllers
{
    // [Authorize] - bỏ comment user phải đăng nhập mới dùng được
   [Route("/file-manager")]
public class FileManagerController : Controller
    {
    public IActionResult Index()
    {
        return View();
    }
    }
}