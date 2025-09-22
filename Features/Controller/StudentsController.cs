using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private static List<StudentViewModel> _students = new()
        {
            new StudentViewModel { Id = 1, FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2022-09-01") },
            new StudentViewModel { Id = 2, FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2023-09-01") },
            new StudentViewModel { Id = 3, FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2024-01-01") }
        };

        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            // --- 1. Sorting ---
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var students = _students.AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            // --- 2. Filtering ---
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s =>
                    s.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            // --- 3. Paging ---
            int pageSize = 2; // show 2 students per page for demo
            var pagedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Info for view
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(students.Count() / (double)pageSize);

            return View(pagedStudents);
        }
    }
}
