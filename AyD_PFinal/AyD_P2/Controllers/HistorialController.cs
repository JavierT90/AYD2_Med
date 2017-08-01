﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AyD_P2.Controllers
{
    public class HistorialController : Controller
    {
        PROYECTOEntities _db = new PROYECTOEntities();
        // GET: Historial
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Historial/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<HISTORIAL> Lista = _db.HISTORIAL.ToList().Where(m => m.CITA1.paciente == id);
            return View(Lista);
        }

        // GET: Historial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historial/Create
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

        // GET: Historial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Historial/Edit/5
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

        // GET: Historial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Historial/Delete/5
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
