using AutoMapper;
using System.Web.Mvc;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();
        public ActionResult Index()
        {
            return View();
        }
    }
}
