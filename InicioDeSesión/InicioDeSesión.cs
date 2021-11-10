using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InicioDeSesión.Clases;

namespace InicioDeSesión
{
    public partial class InicioDeSesión : Form
    {
        Registro registrar = new Registro();
        public ListaRegistro Lista { get; set; } = new ListaRegistro();

        public InicioDeSesión()
        {
            InitializeComponent();
            DgPersistencia.DataSource = Lista.TabladeDatos;

        }

        private void InicioDeSesión_Load(object sender, EventArgs e)
        {



        }

        private void BtBorrar_Click(object sender, EventArgs e)
        {


            Registro registrar = new Registro();

            registrar.Usuario = txtUsuario.Text;

            registrar.Contraseña = txtContraseña.Text;

            //Lista.BorrarFila(registrar);

            if (DgPersistencia.CurrentRow.Index != -1)
            {
                DgPersistencia.Rows.Remove(DgPersistencia.CurrentRow);
                DgPersistencia.Rows.RemoveAt(DgPersistencia.CurrentRow.Index);


            }

            txtUsuario.Focus();
            txtContraseña.SelectAll();
            

        }

        private void BtSalir_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtCargar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();

            registro.Usuario = txtUsuario.Text;

            registro.Contraseña = txtContraseña.Text;

            txtUsuario.Focus();
            txtContraseña.SelectAll();

            Lista.CargadeDatos(registro);
            



        }

        private void DgPersistencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            

            var i = e.RowIndex;

        }


        public void Limpiar()
        {

            txtUsuario.Clear();
            txtContraseña.Clear();
            txtOperaciones.Clear();
            lblMostrar.Text = "";
            

        }

        private void BtLimpiar_Click(object sender, EventArgs e)
        {

            Limpiar();

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            registrar = Lista.BuscarRegistro(Convert.ToInt32(txtOperaciones.Text));



            Registro registro = new Registro();

            registro.Usuario = txtUsuario.Text;

            registro.Contraseña = txtContraseña.Text;

            

            if (registrar.Id > 0 )
            {
                txtUsuario.Text = registrar.Usuario;

                txtContraseña.Text = registrar.Contraseña;


            }
            else
            {
                lblMostrar.Text = "El registro no existe";

            }
            
        }
    }
}
