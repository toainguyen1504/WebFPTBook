using BookFPTStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookFPTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookController : Controller
    {
        public readonly FptbookstoreContext _dataContext;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(FptbookstoreContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.TbBooks.OrderByDescending(p => p.Id)
                                                    .Include(p => p.Category).Include(p => p.Author).ToListAsync());
        }

        /*     public IActionResult Index()
             {
                 var books = _dataContext.TbBooks.ToList();
                 return View(books);
             }*/

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.TbCategories, "Id", "Title");
            ViewBag.Authors = new SelectList(_dataContext.TbAuthors, "Id", "Name");
            return View();
        }
        [HttpPost]
        /*    [ValidateAntiForgeryToken]*/

        public async Task<IActionResult> Create(TbBook book)
        {

            ViewBag.Categories = new SelectList(_dataContext.TbCategories, "Id", "Title", book.CategoryId);
            ViewBag.Authors = new SelectList(_dataContext.TbAuthors, "Id", "Name", book.AuthorId);

            if (ModelState.IsValid)
            {
                /* TempData["success"] = "Model Successfully!";*/
                if (book.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/books");
                    string imageName = Guid.NewGuid().ToString() + "_" + book.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await book.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    book.Image = imageName;

                }
                _dataContext.Add(book);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Create Book Successfully!";
                return RedirectToAction("Index");

            }
            else
            {

                TempData["error_ad"] = "Model has a error! Can Check your file upload (jpg or png or jpeg)";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)

                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

            return View(book);
        }


        public async Task<IActionResult> Edit(int id)
        {
            // Lấy thông tin cuốn sách cần chỉnh sửa từ cơ sở dữ liệu
            var book = await _dataContext.TbBooks.Include(p => p.Category).Include(p => p.Author).FirstOrDefaultAsync(p => p.Id == id);

            if (book == null)
            {
                return NotFound("Cuốn sách không tồn tại.");
            }

            // Khởi tạo ViewBag.Categories và ViewBag.Authors
            ViewBag.Categories = new SelectList(_dataContext.TbCategories, "Id", "Title", book.CategoryId);
            ViewBag.Authors = new SelectList(_dataContext.TbAuthors, "Id", "Name", book.AuthorId);

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbBook book)
        {
            var existingBook = await _dataContext.TbBooks.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound("Cuốn sách không tồn tại.");
            }

            // Tắt validation mặc định
            ModelState.Clear();

            if (book.ImageUpload == null)
            {
                // Nếu không có ảnh mới được chọn, giữ nguyên ảnh cũ
                book.Image = existingBook.Image;
            }

            // Cập nhật các thông tin sách từ form chỉnh sửa
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Price = book.Price;
            existingBook.PriceSale = book.PriceSale;
            existingBook.Quantity = book.Quantity;
            existingBook.CategoryId = book.CategoryId;
            existingBook.AuthorId = book.AuthorId;

            


            // Kiểm tra xem có ảnh mới được chọn hay không
            if (book.ImageUpload != null)
            {
                // Xóa ảnh cũ
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "media/books", existingBook.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                // Lưu ảnh mới
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/books");
                string imageName = Guid.NewGuid().ToString() + "_" + book.ImageUpload.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                await book.ImageUpload.CopyToAsync(fs);
                fs.Close();

                // Cập nhật tên ảnh trong cơ sở dữ liệu
                existingBook.Image = imageName;
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Chỉnh sửa sách thành công!";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            TbBook book = await _dataContext.TbBooks.FindAsync(Id);

            if (book == null)
            {
                return NotFound("Cuốn sách không tồn tại.");
            }

            // Lấy đường dẫn tới hình ảnh
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "media/books", book.Image);

            try
            {
                // Kiểm tra xem hình ảnh có tồn tại hay không
                if (System.IO.File.Exists(imagePath))
                {
                    // Nếu tồn tại, xóa hình ảnh
                    System.IO.File.Delete(imagePath);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(500, $"Lỗi khi xóa hình ảnh: {ex.Message}");
            }

            _dataContext.TbBooks.Remove(book);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Xóa sách thành công!";

            return RedirectToAction("Index");
        }
    }
}
