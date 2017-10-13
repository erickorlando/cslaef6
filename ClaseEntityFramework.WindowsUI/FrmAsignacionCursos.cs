using System;
using System.Windows.Forms;
using ClaseEntityFramework.Datos;

namespace ClaseEntityFramework.WindowsUI
{
    public partial class FrmAsignacionCursos : Form
    {
        public FrmAsignacionCursos()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var ctx = new Colegio())
                {
                    alumnosPorCursoBindingSource.DataSource = ctx.ListarCursosPorAlumno();
                    alumnosPorCursoBindingSource.ResetBindings(false);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAsignarCurso())
            {
                frm.ShowDialog();
                btnMostrar.PerformClick();
            }
        }
    }
}
