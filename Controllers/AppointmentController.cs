using Microsoft.AspNetCore.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class AppointmentController : Controller
    {
        static List<Appointment> appointments = new();

        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(Appointment a)
        {
            a.Id = appointments.Count + 1;
            appointments.Add(a);

            // alert doctor (simple ViewBag message)
            ViewBag.Alert = $"Doctor {a.DoctorName} has been alerted about this appointment!";

            return View();
        }
    }
}
