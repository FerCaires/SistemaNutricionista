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
    public class ClientesController : Controller
    {
        private SNDataContext db = new SNDataContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var daoCliente = db.daoCliente.Include(c => c.Medidas);
            return View(daoCliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.daoCliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.daoMedidas, "MedidasId", "MedidasId");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Idade,Email,Endereco,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.daoCliente.Add(cliente);
                db.SaveChanges();
                ViewBag.ID = new SelectList(db.daoMedidas, "MedidasId", "MedidasId", cliente.ID);
                return RedirectToAction("Create", "ClienteMedidas",cliente);
            }

            ViewBag.ID = new SelectList(db.daoMedidas, "MedidasId", "MedidasId", cliente.ID);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.daoCliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.daoMedidas, "MedidasId", "MedidasId", cliente.ID);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Idade,Email,Endereco,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.daoMedidas, "MedidasId", "MedidasId", cliente.ID);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.daoCliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.daoCliente.Find(id);
            db.daoCliente.Remove(cliente);
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
