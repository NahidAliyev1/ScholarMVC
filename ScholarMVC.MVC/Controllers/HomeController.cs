using Microsoft.AspNetCore.Mvc;
using ScholarMVC.BL.Services;
using ScholarMVC.DAL.Models;

namespace ScholarMVC.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ScholarService _scholarService;

        public HomeController(ScholarService scholarService)
        {
            _scholarService = scholarService;
        }

        public IActionResult Index()
        {
            List<Scholar> scholars = _scholarService.GetAllScholar();

            return View(scholars);
        }
    }
}
