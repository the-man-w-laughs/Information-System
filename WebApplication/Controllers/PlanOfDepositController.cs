using AutoMapper;
using Microsoft.Practices.Unity;
using Services.Deposit;
using Services.Deposit.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class PlanOfDepositController : Controller
    {
        [Dependency]
        public IPlanOfDepositService PlanService { get; set; }
        [Dependency]

        public ORMLibrary.AppContext AppContext { get; set; }


        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var plans = PlanService.GetAll();
            return View(plans.Select(Mapper.Map<PlanOfDepositModel, PlanOfDeposit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var currencies = AppContext.Currencies.ToList();
            return View(new PlanOfDeposit() { Currencies = currencies });
        }

        [HttpPost]
        public ActionResult Create(PlanOfDeposit plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanService.Create(Mapper.Map<PlanOfDeposit, PlanOfDepositModel>(plan));
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