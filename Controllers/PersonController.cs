using DeMoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using DeMoMVC.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;
    public PersonController(ApplicationDbContext context)
    { 
        _context = context;
    }

    private string GenerateNewPersonID()
    {
        var lastPerson = _context.Person
            .OrderByDescending(p => p.PersonID)
            .FirstOrDefault();

        if (lastPerson == null)
        {
            return "PS001";
        }

        string lastId = lastPerson.PersonID;
        int number = int.Parse(lastId.Substring(2));
        number++;
        return "PS" + number.ToString("D3");
    }

    public async Task<IActionResult> Index()
    {
        var model = await _context.Person.ToListAsync();
        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.NewPersonID = GenerateNewPersonID();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PersonID,FullName,Address")] Person person)
    {
         if (ModelState.IsValid)
         {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(person);
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Address")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
        
    }
}
 //Xây dựng chức năng sinh mã (PersonID) tự động đối với chức năng thêm mới dữ liệu cho Person
//Ví dụ: bản ghi đầu tiên có PersonID là PS001 => các bản ghi tiếp theo sẽ có mã PS002, PS003...
//Yêu cầu:
//Khi Bấm vào nút lệnh "Create" để điều hướng sang trang thêm mới dữ liệu Person.
//PersonID sẽ được sinh tự động và hiển thi giá trị ở ô nhập liệu PersonID (chuyển sang chỉ xem không được sửa)