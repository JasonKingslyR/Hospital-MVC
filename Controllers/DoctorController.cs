using Microsoft.AspNetCore.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class DoctorController : Controller
    {
        static List<Doctor> doctors = new();

        public IActionResult Login() => View();
        public IActionResult Signup() => View();

        [HttpPost]
        public IActionResult Signup(Doctor d)
        {
            d.Id = doctors.Count + 1;
            doctors.Add(d);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var doc = doctors.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (doc == null)
            {
                ViewBag.Error = "Invalid login!";
                return View();
            }
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
