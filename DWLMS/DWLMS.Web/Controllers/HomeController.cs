using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DWLMS.Web.Models;
using DLWMS.Services;
using DLWMS.Core;

namespace DWLMS.Web.Controllers
{
    public class HomeController : Controller
    {
        /*
         ukoliko želite rad sa bazom podataka, prije pokretanja aplikacije 
         potrebno je da izvršite migracijen a DLWMS.Repository projektu             
         */

        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            List<Student> studenti = _studentService.GetStudents().ToList();
            return View(studenti);
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
