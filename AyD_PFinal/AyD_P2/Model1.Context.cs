﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PROYECTOEntities : DbContext
    {
        public PROYECTOEntities()
            : base("name=PROYECTOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CITA> CITA { get; set; }
        public virtual DbSet<ENFERMEDAD> ENFERMEDAD { get; set; }
        public virtual DbSet<HISTORIAL> HISTORIAL { get; set; }
        public virtual DbSet<MEDICAMENTO> MEDICAMENTO { get; set; }
        public virtual DbSet<PACIENTE> PACIENTE { get; set; }
        public virtual DbSet<PERSONAL> PERSONAL { get; set; }
        public virtual DbSet<RECETA> RECETA { get; set; }
        public virtual DbSet<SALA> SALA { get; set; }
        public virtual DbSet<TIPO_PUESTO> TIPO_PUESTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        public System.Data.Entity.DbSet<AyD_P2.Models.Reporte1> Reporte1 { get; set; }
    }
}