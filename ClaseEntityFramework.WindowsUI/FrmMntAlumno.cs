using System;
using System.Windows.Forms;
using ClaseEntityFramework.Entidades;

namespace ClaseEntityFramework.WindowsUI
{
    public partial class FrmMntAlumno : Form
    {
        private readonly Alumno _alumno;

        public FrmMntAlumno(Alumno alumno)
        {
            InitializeComponent();
            _alumno = alumno;
            alumnoBindingSource.DataSource = _alumno;
            alumnoBindingSource.ResetBindings(false);
        }

        private void FrmMntAlumno_Load(object sender, EventArgs e)
        {
            nombresTextBox.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.EndEdit();
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            alumnoBindingSource.CancelEdit();
            DialogResult = DialogResult.Cancel;
        }
    }
}
