using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using ClaseEntityFramework.Datos;
using ClaseEntityFramework.Entidades;

namespace ClaseEntityFramework.WindowsUI
{
    public partial class FrmListaCursos : Form
    {
        public FrmListaCursos()
        {
            InitializeComponent();

            Shown += (s, e) =>
            {
                btnMostrar.PerformClick();
            };
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ColegioContainer())
                {
                    cursoBindingSource.DataSource = ctx.Curso.ToList();
                    cursoBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var curso = new Curso();

                using (var frm = new FrmMntCurso(curso))
                {
                    var result = frm.ShowDialog(this);
                    if (result == DialogResult.OK)
                        using (var ctx = new ColegioContainer())
                        {
                            ctx.Curso.Add(curso);
                            ctx.SaveChanges();
                            btnMostrar.PerformClick();
                        }
                    else btnMostrar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cursoBindingSource.Current is Curso seleccionado)) return;

                using (var frm = new FrmMntCurso(seleccionado))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        using (var ctx = new ColegioContainer())
                        {
                            ctx.Set<Curso>().Attach(seleccionado); // Añadiendo la instancia de Alumno modificado al Context.
                            ctx.Entry(seleccionado).State = EntityState.Modified; // El registro esta modificado.
                            ctx.SaveChanges(); // UPDATE a la BD.

                            btnMostrar.PerformClick();
                        }
                    }
                    else btnMostrar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cursoBindingSource.Current is Curso seleccionado)) return;

                if (MessageBox.Show(@"Desea eliminar el registro seleccionado?", Text, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                using (var ctx = new ColegioContainer())
                {
                    ctx.Set<Curso>().Attach(seleccionado); // Añadiendo la instancia de Alumno modificado al Context.
                    ctx.Entry(seleccionado).State = EntityState.Deleted; // El registro esta modificado.
                    ctx.SaveChanges(); // UPDATE a la BD.

                    btnMostrar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
