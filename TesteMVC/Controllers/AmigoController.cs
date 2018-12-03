﻿using System;
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
    public class AmigoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Amigo
        public ActionResult Index()
        {
                return View(db.Amigos.ToList());
        }
        
        // GET: Amigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            ViewBag.SexoId = new SelectList(db.Sexos.ToList(), "Id", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Celular,SexoId,Rua,Cep,Bairro,Numero,Cidade,Cpf")] Amigo amigo)
        {
            ViewBag.SexoId = new SelectList(db.Sexos.ToList(), "Id", "Descricao");
            if (ModelState.IsValid)
            {
                db.Amigos.Add(amigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.SexoId = new SelectList(db.Sexos.ToList(), "Id", "Descricao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Celular,SexoId,Rua,Cep,Bairro,Numero,Cidade,Cpf")] Amigo amigo)
        {
            ViewBag.SexoId = new SelectList(db.Sexos.ToList(), "Id", "Descricao");
            if (ModelState.IsValid)
            {
                db.Entry(amigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.SexoId = new SelectList(db.Sexos.ToList(), "Id", "Descricao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amigo amigo = db.Amigos.Find(id);
            db.Amigos.Remove(amigo);
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
