using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03_Transactions.Helper;
using _03_Transactions.Models;

namespace _03_Transactions.Controllers
{
    public class HomeController : BaseController
    {
        Lunes _dbTransaction = new Lunes();
        public ActionResult Index()
        {
            List<UserTransactions> transactionList = _dbTransaction.UserTransactions.ToList();
            return View(transactionList);
        }

        public ActionResult ChangeCurrentCulture(int id)
        {
            //  
            // Change the current culture for this user.  
            //  
            CultureHelper.CurrentCulture = id;
            //  
            // Cache the new current culture into the user HTTP session.   
            //  
            Session["CurrentCulture"] = id;
            //  
            // Redirect to the same page from where the request was made!   
            //  
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserTransactions transaction)
        {
            UserTransactions newTransaction = new UserTransactions();
            newTransaction.TransactionName = transaction.TransactionName;
            newTransaction.Amount = transaction.Amount;
            _dbTransaction.UserTransactions.Add(newTransaction);
            _dbTransaction.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            UserTransactions editedTransaction = _dbTransaction.UserTransactions.Find(id);
            return View(editedTransaction);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "TransactionId,TransactionName,Amount")] UserTransactions transaction)
        {
            int a = transaction.TransactionId;
            UserTransactions editedTransaction = _dbTransaction.UserTransactions.Find(transaction.TransactionId);
           
            editedTransaction.TransactionName = transaction.TransactionName;
            editedTransaction.Amount = transaction.Amount;
            if (editedTransaction.TransactionName != null & editedTransaction.Amount.ToString()!= null)
            { _dbTransaction.SaveChanges(); }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            UserTransactions deletedTransaction = _dbTransaction.UserTransactions.Find(id);

            _dbTransaction.UserTransactions.Remove(deletedTransaction);
            _dbTransaction.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}