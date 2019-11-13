using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM.Web.Models;
using Microsoft.AspNetCore.Mvc;

//DETTA E ETT FULHAX!   
namespace ALM.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly Transactioner _transactioner;
        private readonly BankRepository _repository;

        public TransactionController(Transactioner transactioner, BankRepository repository)
        {
            _transactioner = transactioner;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Transact");
        }

        [HttpGet]
        public IActionResult Transact()
        {
            var model = new TransactionViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Transact(TransactionViewModel model, TransactionType type)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var account = _repository.GetAccount(model.AccountId);
                model.Account = account;
                switch (type)
                {
                    case TransactionType.Deposit:
                        _transactioner.Deposit(account, model.Amount);
                        break;
                    case TransactionType.Withdrawal:
                        _transactioner.Withdraw(account, model.Amount);
                        break;
                    default:
                        break;
                }
            }
            catch (AccountNotFoundException ex)
            {
                ModelState.AddModelError("account", ex.Message);
                return View(model);
            }
            catch (InvalidTransactionException ex)
            {
                ModelState.AddModelError("balance", ex.Message);
                return View(model);
            }

            return View(model);
        }

    }
}