using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AyD_P2.Models
{
    public class Reportes
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM}")]
        public Nullable<System.DateTime> mesIngreso { get; set; }
        public int id_cita { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> fecha { get; set; }
        public string hora { get; set; }
        public int paciente { get; set; }
        public int personal { get; set; }
        public int sala { get; set; }
    }

    public class Reporte1
    {
        [Required]
        [Key]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> fecha { get; set; }
    

    }

    public class Reporte3
    {
        public int id_enfermedad { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
    }
}