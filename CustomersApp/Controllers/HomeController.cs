using CustomersApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Demo1Context _context;
        private readonly db _dbop;
        

        public HomeController(ILogger<HomeController> logger, Demo1Context context)
        {
            _logger = logger;
            _context = context;
            _dbop = new db();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login login)
        {
            int res = _dbop.LoginCheck(login);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Section";
                return Redirect("Customers");
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
            }
            return View();
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