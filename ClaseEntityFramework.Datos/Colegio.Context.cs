﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClaseEntityFramework.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ClaseEntityFramework.Entidades;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ColegioContainer : DbContext
    {
        public ColegioContainer()
            : base("name=ColegioContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<AlumnoCurso> AlumnoCurso { get; set; }
    
        public virtual ObjectResult<AlumnosPorCurso> ListarCursosPorAlumno()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnosPorCurso>("ListarCursosPorAlumno");
        }
    }
}
