using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDemoMVC.Models;
using TestDemoMVC.UseCases;

namespace TestDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetEmployeesQuery());

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ImportFileAsync(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return Redirect("Index");
            }

            using(var stream = file.OpenReadStream())
            {
                var (rows, employees) = await _mediator.Send(new ImportEmployeesCommand(stream));
                TempData["Message"] = $"{rows} were successfully added!";
            }

            return RedirectToAction("Index");
        }

        
    }
}
