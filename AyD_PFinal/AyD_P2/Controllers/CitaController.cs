using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AyD_P2;

namespace AyD_P2.Controllers
{
    public class CitaController : Controller
    {
        private PROYECTOEntities db = new PROYECTOEntities();

        // GET: Cita
        public ActionResult Index()
        {
            var cITA = db.CITA.Include(c => c.PACIENTE1).Include(c => c.PERSONAL1).Include(c => c.SALA1);
            return View(cITA.ToList());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (!encuentraCita(id))
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        public bool encuentraCita(int? id)
        {
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return false;
            }
            else
                return true;
        }



        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.paciente = new SelectList(db.PACIENTE, "id_paciente", "Nombre");
            ViewBag.personal = new SelectList(db.PERSONAL, "id_personal", "nombre");
            ViewBag.sala = new SelectList(db.SALA, "id_sala", "nombre");
            return View();
        }

        // POST: Cita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cita,fecha,hora,paciente,personal,sala")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.CITA.Add(cITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente = new SelectList(db.PACIENTE, "id_paciente", "Nombre", cITA.paciente);
            ViewBag.personal = new SelectList(db.PERSONAL, "id_personal", "nombre", cITA.personal);
            ViewBag.sala = new SelectList(db.SALA, "id_sala", "nombre", cITA.sala);
            return View(cITA);
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.paciente = new SelectList(db.PACIENTE, "id_paciente", "Nombre", cITA.paciente);
            ViewBag.personal = new SelectList(db.PERSONAL, "id_personal", "nombre", cITA.personal);
            ViewBag.sala = new SelectList(db.SALA, "id_sala", "nombre", cITA.sala);
            return View(cITA);
        }

        // POST: Cita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cita,fecha,hora,paciente,personal,sala")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paciente = new SelectList(db.PACIENTE, "id_paciente", "Nombre", cITA.paciente);
            ViewBag.personal = new SelectList(db.PERSONAL, "id_personal", "nombre", cITA.personal);
            ViewBag.sala = new SelectList(db.SALA, "id_sala", "nombre", cITA.sala);
            return View(cITA);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CITA cITA = db.CITA.Find(id);
            db.CITA.Remove(cITA);
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
