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
    public partial class Libros : Form
    {
        ClsLibros objProducto = new ClsLibros();
        string Operacion = "Insertar";
        string ID_LIBRO;
        DateTime fecha_creacion = DateTime.Now;
        public Libros()
        {
            InitializeComponent();
        }


        private void Libros_Load(object sender, EventArgs e)
        {
            ListarLibros();

        }

        private void ListarLibros()
        {
            ClsLibros objProd = new ClsLibros();
            dataGridView1.DataSource = objProd.ListarLibro();

        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormularioLibro frm = new FormularioLibro();
                frm.Operacion = "Editar";
                frm.ListarAutores();
                frm.ID_LIBRO = dataGridView1.CurrentRow.Cells["ID_LIBRO"].Value.ToString();
                frm.txtnombreLibro.Text = dataGridView1.CurrentRow.Cells["NOMBRE_LIBRO"].Value.ToString();
                frm.cmbAutor.Text = dataGridView1.CurrentRow.Cells["NOMBRE_AUTOR"].Value.ToString();
                frm.ShowDialog();
                ListarLibros();
            }

            else
            {
                MessageBox.Show("Por favor seleccione el libro a editar");
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FormularioLibro frm = new FormularioLibro();
            frm.Operacion = "Insertar";
            frm.ListarAutores();
            frm.ShowDialog();
            ListarLibros();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objProducto._Id_libro = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objProducto.EliminarLibros();
                MessageBox.Show("Eliminado Correctamente");
                ListarLibros();
            }
            else
            {
                MessageBox.Show("Por favor seleccione el libro a eliminar");
            }
        }

    }


    }    

