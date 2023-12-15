using BookFPTStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookFPTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public readonly FptbookstoreContext _dataContext;

        public CategoryController(FptbookstoreContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index()
        {
            var categories = _dataContext.TbCategories.ToList();
            return View(categories);
        }
        public IActionResult Create(TbCategory model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện lưu dữ liệu vào cơ sở dữ liệu
                _dataContext.TbCategories.Add(model);
                _dataContext.SaveChanges();
                return RedirectToAction("Index"); // Chuyển hướng sau khi lưu thành công
            }
            return View(model); // Hiển thị lại biểu mẫu nếu có lỗi
        }
     
    }
}
