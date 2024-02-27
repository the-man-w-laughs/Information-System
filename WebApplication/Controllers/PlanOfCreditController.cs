using AutoMapper;
using Microsoft.Practices.Unity;
using Services.Credit;
using Services.Credit.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class PlanOfCreditController : Controller
    {
        [Dependency]
        public IPlanOfCreditService PlanService { get; set; }
        [Dependency]

        public ORMLibrary.AppContext AppContext { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var plans = PlanService.GetAll().ToList().Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>).ToList();
            return View(plans);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var currencies = AppContext.Currencies.ToList();
            return View(new PlanOfCredit() { Currencies = currencies });
        }

        [HttpPost]
        public ActionResult Create(PlanOfCredit plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var planToInsert = Mapper.Map<PlanOfCredit, PlanOfCreditModel>(plan);
                    PlanService.Create(planToInsert);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(plan);
                }
            }
            return View(plan);
        }
    }
}
