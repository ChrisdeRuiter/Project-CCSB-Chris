using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_CCSB.Services;

namespace Project_CCSB.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentsService; 

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentsService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.AdminList = _appointmentsService.GetAdminList();

            ViewBag.CustomerList = _appointmentsService.GetCustomerList();
            return View();
        }
    }
}
