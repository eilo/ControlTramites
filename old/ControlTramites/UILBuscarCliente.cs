using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlTramites
{
    public partial class UILBuscarCliente : Form
    {
        public UILBuscarCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = DALCliente.Buscar(txtNombre.Text, txtApellido.Text);
        }

        public Cliente ClienteSelecionado { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
                ClienteSelecionado = DALCliente.ObtenerCliente(id);

                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }
    }
}
