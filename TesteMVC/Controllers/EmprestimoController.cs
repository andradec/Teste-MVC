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
    public class EmprestimoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Emprestimo
        public ActionResult Index()
        {
            if (true)
            {
                var emprestimos = db.Emprestimos.Include(e => e.Amigo).Include(e => e.Jogo);

                var Jogolivre = db.Jogos.Where(g => !db.Emprestimos.Any(e => e.JogoID == g.Id));


                if (Jogolivre.ToList().Count() == 0)
                {

                    ViewBag.Message = "Não há mais Jogos para emprestar, resgate algum!";
                    return View(emprestimos.ToList());
                }
                else
                {
                    return View(emprestimos.ToList());
                }
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
          
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        public ActionResult Create()
        {
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome");

            var Jogolivre = db.Jogos.Where(g => !db.Emprestimos.Any(e => e.JogoID == g.Id));                            

           if (Jogolivre.ToList().Count() == 0)
           {
                ViewBag.Message = "Não há mais Jogos para emprestar!";
                return RedirectToAction("Index", "Emprestimo");
           }

            ViewBag.JogoID = new SelectList(Jogolivre, "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmprestimoID,AmigoID,JogoID,Data")] Emprestimo emprestimo)
        {//TODO:ModelState
            if (ModelState.IsValid)
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmprestimoID,AmigoID,JogoID,Data")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            db.Emprestimos.Remove(emprestimo);
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
