using Controlador.EntidadesDTO;
using System;
using System.Windows.Forms;

namespace Presentación
{
    public partial class Form1 : Form
    {
        //inicializamos el formulario
        public Form1()
        {
            InitializeComponent();
            actualizarLista();
        }

        /// <summary>
        /// Listener del boton de insertar, si algun campo está relleno insertará datos en la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ContactoDTO contacto = new ContactoDTO();

            contacto.Nombre = txtboxNombre.Text;
            contacto.Apellido = txtboxApellido.Text;
            contacto.Telefono = txtboxTelefono.Text;
            contacto.Direccion = txtboxDireccion.Text;
            contacto.Email = txtboxEmail.Text;
            contacto.Empresa = txtboxCompany.Text;
            if (txtboxNombre.Text == "" && txtboxApellido.Text == "" && txtboxTelefono.Text == "" &&
                txtboxDireccion.Text == "" && txtboxEmail.Text == "" && txtboxCompany.Text == "")
            {
                string mensaje = "Introduzca los datos";
                string titulo = "Error";
                MessageBoxButtons botones = MessageBoxButtons.YesNo;
                MessageBox.Show(mensaje, titulo, botones, MessageBoxIcon.Error);
            }
            else
            {
                string mensaje = "Datos insertado correctamente";
                string titulo = "Inserción correcta";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, titulo, botones, MessageBoxIcon.Information);
                new Controlador.Controladores.ControladorLibreta().InsertarContacto(contacto);
                actualizarLista();
            }
        }

        /// <summary>
        /// Listener del boton de actualizar, si has seleccionado algun campo de la tabla puedes actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ContactoDTO contacto = new ContactoDTO();
            contacto.ID = int.Parse(gridContactos.CurrentRow.Cells[0].Value.ToString());
            contacto.Nombre = txtboxNombre.Text;
            contacto.Apellido = txtboxApellido.Text;
            contacto.Telefono = txtboxTelefono.Text;
            contacto.Direccion = txtboxDireccion.Text;
            contacto.Email = txtboxEmail.Text;
            contacto.Empresa = txtboxCompany.Text;
            new Controlador.Controladores.ControladorLibreta().ModificarContacto(contacto);
            string mensaje = "Actualización completa";
            string titulo = "Actualización correcta";
            MessageBoxButtons botones = MessageBoxButtons.OK;
            MessageBox.Show(mensaje, titulo, botones, MessageBoxIcon.Information);
            actualizarLista();
        }

        /// <summary>
        /// Listener del boton de actualizar, si has seleccionado algun campo de la tabla puedes eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguro de que desea eliminar este elemento?";
            string titulo = "¡Atención!";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, botones, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                mensaje = "Datos eliminados correctamente";
                titulo = "Eliminación correcta";
                botones = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, titulo, botones, MessageBoxIcon.Information);
                new Controlador.Controladores.ControladorLibreta().EliminarContacto(int.Parse(gridContactos.CurrentRow.Cells[0].Value.ToString()));
                actualizarLista();
            }
        }

        /// <summary>
        /// Actualiza la lista de contactos, ademas inhabilita los botones de actualizar y eliminar, pone todos los textos en
        /// blanco
        /// </summary>
        public void actualizarLista()
        {
            gridContactos.DataSource = new Controlador.Controladores.ControladorLibreta().ObtenerListadoContactos();
            gridContactos.Columns["ID"].Visible = false;
            txtboxNombre.Text = "";
            txtboxApellido.Text = "";
            txtboxTelefono.Text = "";
            txtboxEmail.Text = "";
            txtboxDireccion.Text = "";
            txtboxCompany.Text = "";
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        /// <summary>
        /// Al clicar en una fila pone todos los campos de la tabla en sus textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEliminar.Enabled = true;
                btnActualizar.Enabled = true;

                txtboxNombre.Text = gridContactos.CurrentRow.Cells[1].Value.ToString();
                txtboxApellido.Text = gridContactos.CurrentRow.Cells[2].Value.ToString();
                txtboxTelefono.Text = gridContactos.CurrentRow.Cells[3].Value.ToString();
                txtboxEmail.Text = gridContactos.CurrentRow.Cells[4].Value.ToString();
                txtboxDireccion.Text = gridContactos.CurrentRow.Cells[5].Value.ToString();
                txtboxCompany.Text = gridContactos.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
            }
        }
    }
}