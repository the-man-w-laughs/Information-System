using System;
using System.Web.Mvc;
using AutoMapper;
using Services.ATM;
using Services.Credit;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;
using Services.Common;
using Services.Common.Model;

namespace WebApplication.Controllers
{
    public class AtmController : Controller
    {
        [Dependency]
        public IAtmService AtmService{ get; set; }

        [Dependency]
        public ICreditService CreditService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        // GET: Atm
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(AtmLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var credit = AtmService.LoginUser(model.CreditCardNumber, model.PinCode);
                    if (credit != null)
                    {
                        return RedirectToAction("WorkPage", new { creditId = credit.Id, cardNumber = credit.CreditCardNumber });
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(credit), "Неверный номер карты или пин-код.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }

            return View(model);
        }

        public ActionResult WorkPage(int creditId, string cardNumber)
        {
            var credit = CreditService.Get(creditId);
            return View(new AtmAccountModel() {CreditId = credit.Id, Amount = credit.MainAccount.Balance});
        }

        public ActionResult WithdrawMoney(int creditId, string cardNumber, string pinCode, decimal amount)
        {
            try
            {
                var credit = AtmService.LoginUser(cardNumber, pinCode);
                if (credit is null)
                {
                    throw new ServiceException("Неверный пин-код.");
                }

                AtmService.WithDrawMoney(creditId, amount);
                ReceiptModel receiptModel = new ReceiptModel()
                {
                    CreditId = credit.Id,
                    CardNumber = cardNumber,
                    Amount = amount,
                    Date = SystemInformationService.CurrentBankDay,
                    Operation = $"Снятие денег с карты."
                };

                return View("Receipt", receiptModel);
            }
            catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
                var credit = CreditService.Get(creditId);
                return View("WorkPage", new AtmAccountModel() { CreditId = credit.Id, Amount = credit.MainAccount.Balance });
            }
        }

        public ActionResult TransferMoney(int creditId, string cardNumber, string pinCode, string accountNumber, decimal amount)
        {
            try
            {
                var credit = AtmService.LoginUser(cardNumber, pinCode);
                if (credit is null)
                {
                    throw new ServiceException("Неверный пин-код.");
                }

                AtmService.TransferMoney(creditId, accountNumber, amount);
                ReceiptModel receiptModel = new ReceiptModel()
                {
                    CreditId = credit.Id,
                    CardNumber = cardNumber,
                    Amount = amount,
                    Date = SystemInformationService.CurrentBankDay,
                    Operation = $"Перевод денег с карты на счёт {accountNumber}."
                };

                return View("Receipt", receiptModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var credit = CreditService.Get(creditId);
                return View("WorkPage", new AtmAccountModel() { CreditId = credit.Id, Amount = credit.MainAccount.Balance });
            }
        }
    }
}