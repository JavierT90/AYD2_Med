using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AyD_P2;
using System.Data.SqlClient;

namespace AyD_P2.Controllers
{
    public class ReportesController : Controller
    {

        private PROYECTOEntities db = new PROYECTOEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AyD_P2.Models.Reporte1 model, string botonRep)
        {
            switch (botonRep)
            {
                case "Citas por Mes":
                    return RedirectToAction("Reporte1", "Reportes", new { fechaIngreso = model.fecha });
                
                case "Citas por Dia":
                    return RedirectToAction("Reporte2", "Reportes", new { fechaIngreso = model.fecha });

                case "Enfermedades más comunes":
                    return RedirectToAction("Reporte3", "Reportes");

            }
            
            return View();
        }

        // GET: Personal

        public ActionResult Reporte1(DateTime? fechaIngreso, AyD_P2.Models.Reportes model)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rogerConn"].ConnectionString;
            List<AyD_P2.Models.Reportes> ienum = new List<Models.Reportes>();
            if(comprobarFechaIngreso(fechaIngreso))
            {
                String querr = "SELECT fecha, hora, paciente, personal, sala FROM CITA  WHERE MONTH(fecha) = MONTH('" + fechaIngreso + "') AND YEAR(fecha) = YEAR('" + fechaIngreso + "') ORDER BY MONTH(fecha)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(querr, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Models.Reportes rep = new Models.Reportes();
                                rep.fecha = reader.GetDateTime(0);
                                rep.hora = reader.GetString(1);
                                rep.paciente = reader.GetInt32(2);
                                rep.personal = reader.GetInt32(3);
                                rep.sala = reader.GetInt32(4);
                                ienum.Add(rep);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            
            return View(ienum);
        }

        public bool comprobarFechaIngreso(DateTime? fechaIngreso)
        {
            if (fechaIngreso == null)
                return false;
            else
                return true;
        }

        public ActionResult Reporte2(DateTime? fechaIngreso, AyD_P2.Models.Reportes model)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rogerConn"].ConnectionString;
            List<AyD_P2.Models.Reportes> ienum = new List<Models.Reportes>();
            if (comprobarFechaIngreso(fechaIngreso))
            {
                String querr = "SELECT fecha, hora, paciente, personal, sala FROM CITA  WHERE fecha = '" + fechaIngreso + "' ORDER BY fecha";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(querr, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Models.Reportes rep = new Models.Reportes();
                                rep.fecha = reader.GetDateTime(0);
                                rep.hora = reader.GetString(1);
                                rep.paciente = reader.GetInt32(2);
                                rep.personal = reader.GetInt32(3);
                                rep.sala = reader.GetInt32(4);
                                ienum.Add(rep);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            
            return View(ienum);
        }

        public ActionResult Reporte3(AyD_P2.Models.Reporte3 model)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rogerConn"].ConnectionString;
            List<AyD_P2.Models.Reporte3> ienum = new List<Models.Reporte3>();
            String querr = "SELECT TOP 3 H.enfermedad, E.nombre ,Count(H.enfermedad) cantidad from HISTORIAL H INNER JOIN ENFERMEDAD E ON E.id_enfermedad = H.enfermedad GROUP BY H.enfermedad, E.nombre ORDER BY cantidad DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(querr, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Models.Reporte3 rep = new Models.Reporte3();
                            rep.id_enfermedad = reader.GetInt32(0);
                            rep.nombre = reader.GetString(1);
                            rep.cantidad = reader.GetInt32(2);
                            ienum.Add(rep);
                        }
                    }
                }
                connection.Close();
            }

            return View(ienum);
        }
    }
}
