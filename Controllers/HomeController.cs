using ContactManager.Data;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly CsvService _csvService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, CsvService csvService)
        {
            _logger = logger;
            _context = context;
            _csvService = csvService;
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

        [HttpPost]
        public IActionResult Upload(IFormFile csvFile)
        {
            if (csvFile != null && csvFile.Length > 0)
            {
                using (var stream = csvFile.OpenReadStream())
                {
                    try
                    {
                        var contacts = _csvService.ReadCsvFile(stream);

                        _context.Contacts.AddRange(contacts);
                        _context.SaveChanges();
                    }
                    catch (ApplicationException ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        _logger.Log(LogLevel.Debug, ex.Message);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        _logger.Log(LogLevel.Debug, ex.Message);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please select a valid CSV file.");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Invalid ID" });
            }

            Contact contactToDelete = _context.Contacts.Find(id);
            if (contactToDelete == null)
            {
                return Json(new { success = false, message = "Contact not found" });
            }

            _context.Contacts.Remove(contactToDelete);
            _context.SaveChanges();

            return Json(new { success = true, message = "Contact deleted successfully", contactId = id });
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
