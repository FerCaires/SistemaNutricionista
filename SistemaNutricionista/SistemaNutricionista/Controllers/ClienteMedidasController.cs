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
    public class ClienteMedidasController : Controller
    {
        private SNDataContext db = new SNDataContext();

        // GET: ClienteMedidas
        public ActionResult Index()
        {
            var daoMedidas = db.daoMedidas.Include(c => c.Cliente);
            return View(daoMedidas.ToList());
        }

        // GET: ClienteMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMedidas clienteMedidas = db.daoMedidas.Find(id);
            if (clienteMedidas == null)
            {
                return HttpNotFound();
            }
            return View(clienteMedidas);
        }

        // GET: ClienteMedidas/Create
        public ActionResult Create(Cliente c)
        {
            ViewBag.MedidasId = new SelectList(db.daoMedidas.Where(x => x.MedidasId == c.ID), "ID", "Nome");
            return View();
        }

        // POST: ClienteMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedidasId,Altura,Peso,IMC,Cintura,Abdomen,PorcentagemGordura,PorcentagemGorduraViceral,Coxa")] ClienteMedidas clienteMedidas)
        {
            if (ModelState.IsValid)
            {
                db.daoMedidas.Add(clienteMedidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedidasId = new SelectList(db.daoCliente, "ID", "Nome", clienteMedidas.MedidasId);
            return View(clienteMedidas);
        }

        // GET: ClienteMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMedidas clienteMedidas = db.daoMedidas.Find(id);
            if (clienteMedidas == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedidasId = new SelectList(db.daoCliente, "ID", "Nome", clienteMedidas.MedidasId);
            return View(clienteMedidas);
        }

        // POST: ClienteMedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedidasId,Altura,Peso,IMC,Cintura,Abdomen,PorcentagemGordura,PorcentagemGorduraViceral,Coxa")] ClienteMedidas clienteMedidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteMedidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedidasId = new SelectList(db.daoCliente, "ID", "Nome", clienteMedidas.MedidasId);
            return View(clienteMedidas);
        }

        // GET: ClienteMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMedidas clienteMedidas = db.daoMedidas.Find(id);
            if (clienteMedidas == null)
            {
                return HttpNotFound();
            }
            return View(clienteMedidas);
        }

        // POST: ClienteMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteMedidas clienteMedidas = db.daoMedidas.Find(id);
            db.daoMedidas.Remove(clienteMedidas);
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
