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
    public class PersonalController : Controller
    {
        private PROYECTOEntities db = new PROYECTOEntities();

        // GET: Personal
        public ActionResult Index()
        {
            var pERSONAL = db.PERSONAL.Include(p => p.TIPO_PUESTO1);
            return View(pERSONAL.ToList());
        }

        // GET: Personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAL pERSONAL = db.PERSONAL.Find(id);
            if (!encuentraPersonal(id))
            {
                return HttpNotFound();
            }
            return View(pERSONAL);
        }

        public bool encuentraPersonal(int? id)
        {
            PERSONAL pERSONAL = db.PERSONAL.Find(id);
            if (pERSONAL == null)
            {
                return false;
            }
            else
                return true;
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            ViewBag.tipo_puesto = new SelectList(db.TIPO_PUESTO, "id_tipo", "nombre");
            return View();
        }

        // POST: Personal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_personal,nombre,tipo_puesto")] PERSONAL pERSONAL)
        {
            if (ModelState.IsValid)
            {
                db.PERSONAL.Add(pERSONAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_puesto = new SelectList(db.TIPO_PUESTO, "id_tipo", "nombre", pERSONAL.tipo_puesto);
            return View(pERSONAL);
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAL pERSONAL = db.PERSONAL.Find(id);
            if (pERSONAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_puesto = new SelectList(db.TIPO_PUESTO, "id_tipo", "nombre", pERSONAL.tipo_puesto);
            return View(pERSONAL);
        }

        // POST: Personal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_personal,nombre,tipo_puesto")] PERSONAL pERSONAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_puesto = new SelectList(db.TIPO_PUESTO, "id_tipo", "nombre", pERSONAL.tipo_puesto);
            return View(pERSONAL);
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAL pERSONAL = db.PERSONAL.Find(id);
            if (pERSONAL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONAL);
        }

        // POST: Personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONAL pERSONAL = db.PERSONAL.Find(id);
            db.PERSONAL.Remove(pERSONAL);
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
