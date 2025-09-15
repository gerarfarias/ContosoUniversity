using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Features.Models;


namespace ContosoUniversity.Features.Controller
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();


        [HttpGet]
        public IActionResult Contact() => View(new ContactViewModel());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            // TODO: process message (save/send)
            TempData["Success"] = "Thanks — we received your message.";
            return RedirectToAction("Index");
        }
    }
}