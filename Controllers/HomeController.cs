using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IQueryable<Contact> contacts = _context.Contacts.AsQueryable();
            return View(contacts);
        }

        [HttpPost]
        public IActionResult Edit([FromBody] Contact updatedContact)
        {
            if (ModelState.IsValid)
            {
                // Update the contact in the database
                var contact = _context.Contacts.Find(updatedContact.Id);
                if (contact != null)
                {
                    contact.Name = updatedContact.Name;
                    contact.DateOfBirth = updatedContact.DateOfBirth;
                    contact.Married = updatedContact.Married;
                    contact.Phone = updatedContact.Phone;
                    contact.Salary = updatedContact.Salary;
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
