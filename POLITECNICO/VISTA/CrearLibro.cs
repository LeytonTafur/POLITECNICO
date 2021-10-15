using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POLITECNICO.DATOS;
namespace POLITECNICO.PRESENTACION
{
    public partial class FormularioLibro : Form
    {
        public FormularioLibro()
        {
            InitializeComponent();
        }
        ClsLibros objProducto = new ClsLibros();
        public string Operacion = "";
        public string ID_LIBRO;
        DateTime fecha_creacion = DateTime.Now;

        public void ListarAutores()
        {
            ClsLibros objProd = new ClsLibros();
            cmbAutor.DataSource = objProd.ListarAutor();
            cmbAutor.DisplayMember = "NOMBRE_AUTOR";
            cmbAutor.ValueMember = "ID_AUTOR";
        }

        private void LimpiarFormulario()
        {
            txtnombreLibro.Clear();
        }

       
        private void FormularioLibro_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objProducto._Nombre_libro = txtnombreLibro.Text;
                objProducto._Id_autor = Convert.ToInt32(cmbAutor.SelectedValue);
                objProducto._Fecha_creacion= DateTime.Now;
                objProducto.InsertarLibros();
                MessageBox.Show("Creado Correctamente");
                LimpiarFormulario();
                this.Close();

            }
            else if (Operacion == "Editar")
            {
                objProducto._Id_libro = Convert.ToInt32(ID_LIBRO);
                objProducto._Nombre_libro = txtnombreLibro.Text;
                objProducto._Id_autor = Convert.ToInt32(cmbAutor.SelectedValue);
                objProducto._Fecha_creacion= DateTime.Now;
                objProducto.EditarLibros();
                Operacion = "Insertar";
                MessageBox.Show("Editado Correctamente");
                LimpiarFormulario();
                this.Close();
            }

            

        }
    }
}
