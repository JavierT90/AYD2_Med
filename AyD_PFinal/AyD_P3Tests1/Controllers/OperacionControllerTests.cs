using Microsoft.VisualStudio.TestTools.UnitTesting;
using AyD_P2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyD_P2.Controllers.Tests
{
    [TestClass()]
    public class OperacionControllerTests
    {
        PROYECTOEntities db = new PROYECTOEntities();
        
        [TestMethod()]
        public void ingresoValorReporteTest()
        {
            DateTime fecha = DateTime.Parse("05/05/2017");

            ReportesController o = new ReportesController();
            bool esperado = true;
            var resultado = o.comprobarFechaIngreso(fecha);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void encuentraCitaTest()
        {
            int id = 7;

            CitaController o = new CitaController();
            bool esperado = true;
            var resultado = o.encuentraCita(id);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void encuentraPacienteTest()
        {
            int id = 1;

            PacienteController o = new PacienteController();
            bool esperado = true;
            var resultado = o.encuentraPaciente(id);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void encuentraPersonalTest()
        {
            int id = 1;

            PersonalController o = new PersonalController();
            bool esperado = true;
            var resultado = o.encuentraPersonal(id);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void sesionActivaTest()
        {
            int sesion = 1;

            AccountController o = new AccountController();
            bool esperado = true;
            var resultado = o.sesionActiva(sesion);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void existeUsuarioIngresoTest()
        {
            string us = "nat";
            string pass = "123123";

            AccountController o = new AccountController();
            bool esperado = true;
            var resultado = o.existeUsuario(us, pass);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void creaUsuarioTest()
        {
            string us = "prueba";
            string pass = "123123";
            int tipo = 1;

            AccountController o = new AccountController();
            bool esperado = true;
            var resultado = o.creaUsuario(us, pass, tipo);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void usuarioNoDuplicadoTest()
        {
            string us = "otro";
            int tipo = 1;

            AccountController o = new AccountController();
            bool esperado = true;
            var resultado = o.usuarioNoDuplicado(us, tipo);

            Assert.AreEqual(esperado, resultado);
        }
    }
}