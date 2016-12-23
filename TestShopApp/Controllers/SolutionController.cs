using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestShopApp.Models;
using System.Threading;

namespace TestShopApp.Controllers
{
    public class SolutionController : Controller
    {
        _dbContext ic = new _dbContext();
        // GET: Solution
        public string Index()
        {
            return "If u see me, u do something wrong";
        }
        public ActionResult ItemsShow()
        {
            return View("ItemsShow",(object)ic.ItemsContext);
        }
        public ActionResult MembersShow()
        {
            return View("MembersShow",(object)ic.MembersContext);
        }
        public PartialViewResult ItemsSort(string SearchingName)
        {
            var product = ic.ItemsContext.Where(p => p.name.Contains(SearchingName)
            || string.IsNullOrEmpty(SearchingName)).Take(10);
            Thread.Sleep(3000);
            if (product.Count() == 0)
            {
                return PartialView("EmptyResult");
            }
            else
            {
                return PartialView("ItemsSortView", (object)product);
            }
        }
        //public string Test(string SearchingName)
        //{
        //    return SearchingName;
        //}
        protected override void Dispose(bool disposing)
        {
            ic.Dispose();
            base.Dispose(disposing);
        }
    }
}