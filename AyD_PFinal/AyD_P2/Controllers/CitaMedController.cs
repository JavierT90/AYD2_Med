using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AyD_P2.Controllers
{
    public class CitaMedController : Controller
    {
        PROYECTOEntities _db = new PROYECTOEntities();
        private IEnumerable<SelectListItem> GetPersonal()
        {

            IEnumerable<SelectListItem> slItem = from s in _db.PERSONAL
                                                 select new SelectListItem
                                                 {

                                                     Text = s.nombre,
                                                     Value = s.id_personal.ToString()
                                                 };
            return slItem;
        }
        private IEnumerable<SelectListItem> GetSala()
        {

            IEnumerable<SelectListItem> slItem = from s in _db.SALA
                                                 select new SelectListItem
                                                 {

                                                     Text = s.nombre,
                                                     Value = s.id_sala.ToString()
                                                 };
            return slItem;
        }

        private IEnumerable<SelectListItem> GetPaciente()
        {

            IEnumerable<SelectListItem> slItem = from s in _db.PACIENTE
                                                 select new SelectListItem
                                                 {

                                                     Text = s.Nombre,
                                                     Value = s.id_paciente.ToString()
                                                 };
            return slItem;
        }

        // GET: Cita
        public ActionResult Index()
        {
            IEnumerable<CITA> Lista = _db.CITA.ToList<CITA>();
            return View(Lista);
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var modelo = _db.CITA.Find(id);
                return View(modelo);
            }
            else {
                return RedirectToAction("Index");
            }

        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            CITA modelo = new CITA();
            modelo.ListaPersonal = this.GetPersonal();
            modelo.ListaSala = this.GetSala();
            modelo.ListaPaciente = this.GetPaciente();
            return View(modelo);
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(CITA cita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.CITA.Add(cita);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("fallo", "Registro realizado");
                return RedirectToAction("Create");
            }
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var modelo = _db.CITA.Single(e => e.id_cita == id);
                modelo.ListaPersonal = this.GetPersonal();
                modelo.ListaSala = this.GetSala();
                modelo.ListaPaciente = this.GetPaciente();
                return View(modelo);
            }

            else
            {
                return RedirectToAction("Index");
            }
        }
    
            

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CITA cita)
        {
            var modeloAnterior = _db.CITA.Find(id);
            if (TryUpdateModel(modeloAnterior, "",
               new string[] { "fecha", "hora", "paciente", "personal", "sola" }))
            {
                try
                {
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch 
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "No se pudo realizar la actualización");
                }
            }
            
            return View(modeloAnterior);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cita/Delete/5
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
