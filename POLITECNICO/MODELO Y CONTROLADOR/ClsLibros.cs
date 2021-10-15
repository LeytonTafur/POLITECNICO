using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POLITECNICO.DATOS
{
    class ClsLibros
    {

        private ConexionDB Conexion = new ConexionDB();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        //ATRIBUTOS
        private int id_libro;
        private string nombre_libro;
        private int id_autor;
        private DateTime fecha_creacion;

        //METODOS GET Y SET
        public int _Id_libro
        {
            get { return id_libro; }
            set { id_libro = value; }
        }
        public string _Nombre_libro
        {
            get { return nombre_libro; }
            set { nombre_libro = value; }
        }
        public int _Id_autor
        {
            get { return id_autor; }
            set { id_autor = value; }
        }
        public DateTime _Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        //METODOS Y FUNCIONES
        public DataTable ListarAutor()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAutores";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarLibro()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarLibros()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NOMBRE_LIBRO", nombre_libro);
            Comando.Parameters.AddWithValue("@ID_AUTOR", id_autor);
            Comando.Parameters.AddWithValue("@FECHA_CREACION", fecha_creacion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        public void EditarLibros()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditarLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@ID_LIBRO", id_libro);
            Comando.Parameters.AddWithValue("@NOMBRE_LIBRO", nombre_libro);
            Comando.Parameters.AddWithValue("@ID_AUTOR", id_autor);
            Comando.Parameters.AddWithValue("@FECHA_CREACION", fecha_creacion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

        }

        public void EliminarLibros()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarLibros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@ID_LIBRO", id_libro);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();

        }

    }
}
