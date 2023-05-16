using EmployeeDetail.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetail.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
