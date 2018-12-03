using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class EstiloController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Estilo
        public ActionResult Index()
        {
            return View(db.Estilo.ToList());
        }

        // GET: Estilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilo.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // GET: Estilo/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Create([Bind(Include = "Id, Descricao")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Estilo.Add(estilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);
        }

        //GET: Estilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilo.Find(id);
            if(estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        [HttpPost]       
        public ActionResult Edit([Bind(Include = "Id, Descricao")] Estilo estilo)
        {
            if(ModelState.IsValid)
            {
                db.Entry(estilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);     
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilo.Find(id);
            if(estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        [HttpPost, ActionName("Delete")]       
        public ActionResult DeleteConfirmed(int id)
        {
            Estilo estilo = db.Estilo.Find(id);
            db.Estilo.Remove(estilo);
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