using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaNutricionista.DataContext;
using SistemaNutricionista.Models;

namespace SistemaNutricionista.Controllers
{
    public class PlanoAlimentarsController : Controller
    {
        private SNDataContext db = new SNDataContext();

        // GET: PlanoAlimentars
        public ActionResult Index()
        {
            
            return View(db.daoPlanoAlimentar.ToList());
        }

        // GET: PlanoAlimentars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar planoAlimentar = db.daoPlanoAlimentar.Find(id);
            if (planoAlimentar == null)
            {
                return HttpNotFound();
            }
            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = new SelectList(db.daoCliente, "ID", "Nome");
            return View();
        }

        // POST: PlanoAlimentars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClienteID,Desjejum,Colacao,Almoco,LancheTarde,LancheTardeDois,Jantar,Ceia,CeiaDois,DataRegistro")] PlanoAlimentar planoAlimentar)
        {
            if (ModelState.IsValid)
            {
                db.daoPlanoAlimentar.Add(planoAlimentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar planoAlimentar = db.daoPlanoAlimentar.Find(id);
            if (planoAlimentar == null)
            {
                return HttpNotFound();
            }
            return View(planoAlimentar);
        }

        // POST: PlanoAlimentars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClienteID,Desjejum,Colacao,Almoco,LancheTarde,LancheTardeDois,Jantar,Ceia,CeiaDois,DataRegistro")] PlanoAlimentar planoAlimentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planoAlimentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar planoAlimentar = db.daoPlanoAlimentar.Find(id);
            if (planoAlimentar == null)
            {
                return HttpNotFound();
            }
            return View(planoAlimentar);
        }

        // POST: PlanoAlimentars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanoAlimentar planoAlimentar = db.daoPlanoAlimentar.Find(id);
            db.daoPlanoAlimentar.Remove(planoAlimentar);
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
