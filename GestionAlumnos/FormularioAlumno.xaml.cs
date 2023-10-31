using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionAlumnos
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["GestionAlumnos.Properties.Settings.GestionAlumnosConnectionString1"].ConnectionString;
            MiConexionSql = new SqlConnection(miConexion);
        }
        SqlConnection MiConexionSql;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombre = TxtNombre.Text;
            string apellido = TxtApellido.Text;
            string genero = TxtGenero.Text;
            string direccion = TxtDireccion.Text;
            string telefono = TxtTelefono.Text;
            string correoElectronico = TxtCorreoElectronico.Text;
            string consulta = "INSERT INTO Alumnos (Nombre, Apellido, Genero, Direccion, Telefono, CorreoElectronico) VALUES (@Nombre, @Apellido, @Genero, @Direccion, @Telefono, @CorreoElectronico)";
            SqlCommand miSqlCommand = new SqlCommand(consulta, MiConexionSql);
            MiConexionSql.Open();
            miSqlCommand.Parameters.AddWithValue("@Nombre", nombre);
            miSqlCommand.Parameters.AddWithValue("@Apellido", apellido);
            miSqlCommand.Parameters.AddWithValue("@Genero", genero);
            miSqlCommand.Parameters.AddWithValue("@Direccion", direccion);
            miSqlCommand.Parameters.AddWithValue("@Telefono", telefono);
            miSqlCommand.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
            miSqlCommand.ExecuteNonQuery();
            MiConexionSql.Close();
            this.Close();

        }

        private void Buttonsalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
