using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseEntityFramework.Entidades
{
    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        public int AlumnoCursoId { get; set; }

        public int AlumnoId { get; set; }

        public int CursoId { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
