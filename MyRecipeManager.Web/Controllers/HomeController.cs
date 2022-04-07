using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipeManager.Web.Data;
using MyRecipeManager.Web.Models;
using System.Diagnostics;

namespace MyRecipeManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRoleService _userRoleService;

        public HomeController(ILogger<HomeController> logger, IUserRoleService userRoleService)
        {
            _logger = logger;
            _userRoleService = userRoleService;
        }

        public IActionResult Index()
        {
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
        [Authorize(Roles = UserRoleService.ADMIN_ROLE_NAME)]
        public async Task<IActionResult> EnsureRolesAndUsers()
        {
            await _userRoleService.EnsureAdminUserRole();
            return RedirectToAction("Index");
        }
    }
}