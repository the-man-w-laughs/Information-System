using AutoMapper;
using Microsoft.Practices.Unity;
using Services.ATM;
using Services.Common;
using Services.Common.Model;
using Services.Credit;
using System;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class AtmController : Controller
    {
        [Dependency]
        public IAtmService AtmService { get; set; }

        [Dependency]
        public ICreditService CreditService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        // GET: Atm
        public ActionResult Index()
        {
            return View("ATMCardInsert");
        }

        [HttpPost]
        public ActionResult Login(AtmLoginModel model)
        {
            try
            {
                var cardNumber = (string)Session["CardNumber"];
                var credit = AtmService.LoginUser(cardNumber, model.PinCode);
                if (credit != null)
                {
                    Session["CreditId"] = credit.Id;
                    return RedirectToAction("WorkPage");
                }
                else
                {
                    var numberOfTries = (int)Session["NumberOfTries"] + 1;
                    Session["NumberOfTries"] = numberOfTries;
                    model.NumberOfTries = numberOfTries;
                    if (numberOfTries >= 3)
                    {
                        Session["NumberOfTries"] = 0;
                        return View("ATMCardInsert");
                    }
                    throw new ArgumentNullException("Ошибка. Неверный пин-код.");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("EnterPIN", model);
            }
        }

        public ActionResult WorkPage()
        {
            var creditId = (int)Session["CreditId"];
            var credit = CreditService.Get(creditId);

            var state = Session["State"];
            switch (state)
            {
                case "ViewTotal":
                    {
                        ReceiptModel receiptModel = new ReceiptModel()
                        {
                            CreditId = credit.Id,
                            CardNumber = credit.CreditCardNumber,
                            Amount = credit.MainAccount.Balance,
                            Date = SystemInformationService.CurrentBankDay,
                            Operation = $"Просмотр остатка"
                        };
                        Session["State"] = null;

                        return View("Receipt", receiptModel);
                    }
                case "WithdrawMoney":
                    {

                        Session["State"] = null;
                        return View("AmountToWithdraw");
                        return RedirectToAction("WithdrawMoney");
                    }
                default:
                    {
                        return View(new AtmAccountModel() { CreditId = credit.Id, Amount = credit.MainAccount.Balance });
                    }
            }
        }

        [HttpPost]
        public ActionResult WithdrawMoneyEnter(AtmLoginModel atmLoginModel)
        {
            Session["State"] = "WithdrawMoney";
            Session["AmountToWithdraw"] = atmLoginModel.AmountToWithdraw;
            return RedirectToAction("EnterPIN");
        }

        public ActionResult WithdrawMoney(AtmLoginModel atmLoginModel)
        {
            var creditId = (int)Session["CreditId"];
            var credit = CreditService.Get(creditId);
            var amountToWithdraw = atmLoginModel.AmountToWithdraw;
            try
            {

                AtmService.WithDrawMoney(creditId, amountToWithdraw);
                ReceiptModel receiptModel = new ReceiptModel()
                {
                    CreditId = credit.Id,
                    CardNumber = credit.CreditCardNumber,
                    Amount = amountToWithdraw,
                    Date = SystemInformationService.CurrentBankDay,
                    Operation = $"Снятие наличных"
                };

                return View("Receipt", receiptModel);
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", ex.Message);
                //var credit = CreditService.Get(creditId);
                //return View("WorkPage", new AtmAccountModel() { CreditId = credit.Id, Amount = credit.MainAccount.Balance });

                ReceiptModel receiptModel = new ReceiptModel()
                {
                    CreditId = credit.Id,
                    CardNumber = credit.CreditCardNumber,
                    Amount = amountToWithdraw,
                    Date = SystemInformationService.CurrentBankDay,
                    Operation = $"Ошибка при снятии наличных"
                };

                return View("Receipt", receiptModel);
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

        [HttpPost]
        public ActionResult ViewTotal()
        {
            Session["State"] = "ViewTotal";
            return RedirectToAction("EnterPIN");
        }

        [HttpPost]
        public ActionResult TakeCardBack()
        {
            Session["State"] = null;
            Session["CardNumber"] = null;
            Session["CreditId"] = null;
            Session["NumberOfTries"] = 0;
            return View("ATMCardInsert");
        }


        [HttpPost]
        public ActionResult EnterCardNumber(AtmLoginModel model)
        {
            if (AtmService.IsCardExist(model.CreditCardNumber))
            {
                Session["CardNumber"] = model.CreditCardNumber;
                return RedirectToAction("EnterPIN");
            }
            else
            {
                ViewBag.ErrorMessage = "Карта не существует. Повторите попытку.";
                return View("ATMCardInsert", model);
            }
        }

        public ActionResult EnterPIN()
        {
            Session["NumberOfTries"] = 0;
            return View("EnterPIN", new AtmLoginModel() { NumberOfTries = 0 });
        }

    }
}