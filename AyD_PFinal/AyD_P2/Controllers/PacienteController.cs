using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AyD_P2.Controllers
{
    public class PacienteController : Controller
    {
        PROYECTOEntities _db = new PROYECTOEntities();
        // GET: Paciente
        public ActionResult Index()
        {
            IEnumerable<PACIENTE> Lista = _db.PACIENTE.ToList<PACIENTE>();
            return View(Lista);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var modelo = _db.PACIENTE.Find(id);
            if (encuentraPaciente(id))
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        public bool encuentraPaciente(int? id)
        {
            var modelo = _db.PACIENTE.Find(id);
            if (modelo == null)
            {
                return false;
            }
            else
                return true;
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
