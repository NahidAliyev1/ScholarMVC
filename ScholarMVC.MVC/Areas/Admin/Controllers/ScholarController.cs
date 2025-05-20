using Microsoft.AspNetCore.Mvc;
using ScholarMVC.BL.Services;
using ScholarMVC.BL.ViewModels;
using ScholarMVC.DAL.Models;
using System.Diagnostics.CodeAnalysis;

namespace ScholarMVC.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class ScholarController : Controller
{
    private readonly ScholarService _scholarService;

    public ScholarController(ScholarService scholarService)
    {
        _scholarService = scholarService;
    }

    public IActionResult Index()
    {
        List<Scholar> scholars = _scholarService.GetAllScholar();
        return View(scholars);
    }
    [HttpGet]
    public IActionResult Info(int id) 
    {
        Scholar scholar = _scholarService.GetScholarById(id);
        return View(scholar);
    }
    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(ScholarVM scholarVM) 
    {
        _scholarService.CreateScholar(scholarVM);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Update(int id) 
    {
        var model = _scholarService.GetScholarById(id);

        var viewModel = new ScholarVM
        {
            Name = model.Name,
            Category = model.Category,
            Price = model.Price
        };
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult Update(int id, ScholarVM scholarVM) 
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("error");
        }
        _scholarService.UpdateScholar(id,scholarVM);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id) 
    {
        _scholarService.DeleteScholar(id);
        return RedirectToAction(nameof(Index));
    }
}
