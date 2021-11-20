using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankingSystem.Models;                                                                                                                                                                                                                          

namespace BankingSystem.Controllers
{
    public class Home1Controller : Controller
    {
        db_accountsEntities db = new db_accountsEntities();
        // GET: Home1
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_accounts obj, string btn)
        {
            if (btn== "Withdraw")
            {
                var data = db.tbl_accounts.Where(obj1 => obj1.acc_no == obj.acc_no).FirstOrDefault();

                if (obj.amt <= obj.amt)
                {
                    data.amt -= obj.amt;
                    int mess = db.SaveChanges();

                    if (mess == 1)
                    {
                        ViewBag.data = "Withdraw Done";
                    }
                    else
                    {
                        ViewBag.data = "Withdraw Not Done";
                    }
                }
                else
                {
                    ViewBag.data = "Insufficient Balance";
                }
            }
            else if (btn== "Deposite")
            {
                var data = db.tbl_accounts.Where(obj1 => obj1.acc_no == obj.acc_no).FirstOrDefault();
                data.amt += obj.amt;
               int mess = db.SaveChanges();
                if (mess == 1)
                {
                    ViewBag.data = "Deposite Done";
                }
                else
                {
                    ViewBag.data = "Deposite Not Done";
                }
            }
            else if (btn== "Check Balance")
            {
                var data = db.tbl_accounts.Where(obj1 => obj1.acc_no == obj.acc_no).FirstOrDefault();
                ViewBag.show = data.amt;
            }
            return View();
        }
    }
}