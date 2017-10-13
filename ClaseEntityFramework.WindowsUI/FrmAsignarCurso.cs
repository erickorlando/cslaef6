using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClaseEntityFramework.Datos;
using ClaseEntityFramework.Entidades;

namespace ClaseEntityFramework.WindowsUI
{
    public partial class FrmAsignarCurso : Form
    {
        public List<CursoPorAlumno> CursosPorAlumno { get; set; }

        public FrmAsignarCurso()
        {
            InitializeComponent();

            CursosPorAlumno = new List<CursoPorAlumno>();
            cursoPorAlumnoBindingSource.DataSource = CursosPorAlumno;

            Shown += (s, e) =>
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    using (var ctx = new ColegioContainer())
                    {
                        alumnoBindingSource.DataSource = ctx.Alumno.ToList();
                        alumnoBindingSource.ResetBindings(false);
                        cursoBindingSource.DataSource = ctx.Curso.ToList();
                        cursoBindingSource.ResetBindings(false);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            };
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!(alumnoBindingSource.Current is Alumno alumnoSeleccionado)) return;
                if (!(cursoBindingSource.Current is Curso cursoSeleccionado)) return;

                CursosPorAlumno.Add(new CursoPorAlumno
                {
                    IdAlumno = alumnoSeleccionado.AlumnoId,
                    IdCurso = cursoSeleccionado.CursoId,
                    NombreAlumno = alumnoSeleccionado.Nombres,
                    NombreCurso = cursoSeleccionado.Nombre,
                    Creditos = cursoSeleccionado.NroCreditos
                });

                cursoPorAlumnoBindingSource.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var ctx = new ColegioContainer())
                {
                    foreach (var cursoPorAlumno in CursosPorAlumno)
                    {
                        var alumnoCurso = new AlumnoCurso
                        {
                            AlumnoId = cursoPorAlumno.IdAlumno,
                            CursoId = cursoPorAlumno.IdCurso
                        };
                        ctx.AlumnoCurso.Add(alumnoCurso); // Añade esta instancia al contexto.
                    }
                    ctx.SaveChanges();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
