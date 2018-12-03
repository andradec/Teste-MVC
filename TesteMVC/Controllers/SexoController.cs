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
            return View(db.Sexos.ToList());
        }

        //GET: Sexo/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult Create ([Bind(Include = "Id, Descricao")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                db.Sexos.Add(sexo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sexo);            
        }

        // GET: Sexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexo sexo = db.Sexos.Find(id);
            if(sexo == null)
            {
                return HttpNotFound();
            }
            return View(sexo);
        }

        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(int id)
        {
            Sexo sexo = db.Sexos.Find(id);
            db.Sexos.Remove(sexo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}