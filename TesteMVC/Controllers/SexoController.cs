using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;
namespace TesteMVC.Controllers
{
    public class SexoController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index()
        {
            //db.Sexos.ToList()
            return View();
        }

    }
}