//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AyD_P2
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORIAL
    {
        public int id_historial { get; set; }
        public string observaciones { get; set; }
        public int cita { get; set; }
        public int receta { get; set; }
        public int enfermedad { get; set; }
    
        public virtual CITA CITA1 { get; set; }
        public virtual ENFERMEDAD ENFERMEDAD1 { get; set; }
        public virtual RECETA RECETA1 { get; set; }
    }
}
