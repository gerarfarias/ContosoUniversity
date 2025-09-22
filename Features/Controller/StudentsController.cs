using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Features.Controllers
{
    public class StudentsController : Controller
    {
        private static List<StudentViewModel> _students = new();

        public IActionResult Index()
        {
            return View(_students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // validation error: redisplay form
            }

            model.Id = _students.Count + 1;
            _students.Add(model);

            TempData["Success"] = "Student created successfully!";
            return RedirectToAction(nameof(Index)); // PRG pattern
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = _students.FirstOrDefault(s => s.Id == model.Id);
            if (existing == null) return NotFound();

            existing.FirstName = model.FirstName;
            existing.LastName = model.LastName;
            existing.EnrollmentDate = model.EnrollmentDate;

            TempData["Success"] = "Student updated successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
