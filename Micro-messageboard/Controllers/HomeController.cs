using Micro_messageboard.Models.BoardViewModels;
using Micro_messageboard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Micro_messageboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MicroMessageBoardContext _context;

        public HomeController(ILogger<HomeController> logger,MicroMessageBoardContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
            IQueryable<UserPostGroup> data = from user in _context.Posts
                               group user by user.UserId into userGroup
                               select new UserPostGroup()
                               {
                                   UserName = userGroup.First().User.UserName,
                                   UserPostCount = userGroup.Count()
                               };
            return View(await data.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}