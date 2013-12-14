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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DALdbcomun.ObtenerConexion();
            MessageBox.Show("conectado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente pCliente = new Cliente();
            if (txtNombre.Text.Length != 0)
                pCliente.Nombre = txtNombre.Text.Trim();
            if (txtApellido.Text.Length != 0)
                pCliente.Apellido = txtApellido.Text.Trim();
            if (txtCedula.Text.Length != 0)
                pCliente.Cedula = txtCedula.Text.Trim();
            if (txtClave.Text.Length != 0)
                pCliente.Clave = txtClave.Text.Trim();

            int resultado = DALCliente.Agregar(pCliente);
            if (resultado > 0)
            {
                MessageBox.Show("Cliente Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UILBuscarCliente buscar = new UILBuscarCliente();
            buscar.ShowDialog();

            Cliente cliente = buscar.ClienteSelecionado;

            if (cliente != null)
            {
                ClienteActual = cliente;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtCedula.Text = cliente.Cedula;
                txtClave.Text = cliente.Clave;
            }
        }

        public Cliente ClienteActual { get; set; }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente pCliente = new Cliente();

            pCliente.Nombre = txtNombre.Text.Trim();
            pCliente.Apellido = txtApellido.Text.Trim();
            pCliente.Cedula = txtCedula.Text.Trim();
            pCliente.Clave = txtClave.Text.Trim();
            pCliente.Id = ClienteActual.Id;

            if (DALCliente.Actualizar(pCliente) > 0)
            {
                MessageBox.Show("Los datos del cliente se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UILClientes autocompletar = new UILClientes();
            autocompletar.ShowDialog();
        }

    }
}
