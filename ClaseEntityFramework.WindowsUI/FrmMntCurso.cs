using System;
using System.Windows.Forms;
using ClaseEntityFramework.Entidades;

namespace ClaseEntityFramework.WindowsUI
{
    public partial class FrmMntCurso : Form
    {
        private readonly Curso _curso;

        public FrmMntCurso(Curso curso)
        {
            InitializeComponent();
            _curso = curso;
            cursoBindingSource.DataSource = _curso;
            cursoBindingSource.ResetBindings(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            cursoBindingSource.EndEdit();
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cursoBindingSource.CancelEdit();
            DialogResult = DialogResult.Cancel;
        }
    }
}
