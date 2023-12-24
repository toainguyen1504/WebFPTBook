using BookFPTStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookFPTStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AuthorController : Controller
	{
		public readonly FptbookstoreContext _dataContext;

		public AuthorController(FptbookstoreContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index()
		{
			var authors = _dataContext.TbAuthors.ToList();
			return View(authors);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public IActionResult Create(TbAuthor author)
		{
			if (ModelState.IsValid)
			{
				_dataContext.TbAuthors.Add(author);
				TempData["success"] = "Add Author Sucessfully!";
				_dataContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(author);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			TbAuthor author = await _dataContext.TbAuthors.FindAsync(Id);
			_dataContext.TbAuthors.Remove(author);
			await _dataContext.SaveChangesAsync();
			TempData["success"] = "Delete Successful!";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Edit(int Id)
		{
			TbAuthor author = await _dataContext.TbAuthors.FindAsync(Id);
			return View(author);
		}

		[HttpPost]

		public IActionResult Edit(TbAuthor author)
		{
			if (ModelState.IsValid)
			{
				_dataContext.TbAuthors.Update(author);
				TempData["success"] = "Update author Sucessfully!";
				_dataContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(author);
		}
	}
}
