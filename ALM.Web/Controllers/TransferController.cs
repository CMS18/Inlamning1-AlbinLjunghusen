using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM.Web.Exceptions;
using ALM.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALM.Web.Controllers
{
    public class TransferController : Controller
    {
        private ITransactioner _transactioner;

        public TransferController(ITransactioner transactioner)
        {
            _transactioner = transactioner;
        }

        public IActionResult Index()
        {
            return View(new TransferViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Amount <= 0)
                {
                    ViewBag.Message = "Amount must be greater than 0.";
                    return View(model);
                }

                try
                {
                    var res = _transactioner.Transfer(model.FromAccountId, model.ToAccountId, model.Amount);
                    ViewBag.Message = res;
                    return View(model);
                }
                catch (InvalidTransferException ex)
                {
                    ModelState.AddModelError("transfer", ex.Message);
                    return View(model);
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
            }
            return View();
        }
    }
}