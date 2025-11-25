using Microsoft.AspNetCore.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class PatientController : Controller
    {
        static List<Patient> patients = new();

        public IActionResult Login() => View();
        public IActionResult Signup() => View();

        [HttpPost]
        public IActionResult Signup(Patient p)
        {
            p.Id = patients.Count + 1;
            patients.Add(p);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var patient = patients.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (patient == null)
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
