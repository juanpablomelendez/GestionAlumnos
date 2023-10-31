using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace GestionAlumnos
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["GestionAlumnos.Properties.Settings.GestionAlumnosConnectionString1"].ConnectionString;
            MiConexionSql = new SqlConnection(miConexion);
            MuestraAlumnos();
        }
        SqlConnection MiConexionSql;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana2 = new Window1();
            ventana2.Show();
            // Cierra la ventana actual si es necesario.
            this.Close();
        }
        private void MuestraAlumnos()
        {
            string consulta = "SELECT Matricula, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto, Genero, Direccion, Telefono FROM Alumnos";
;
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, MiConexionSql);

            using (miAdaptadorSql)
            {
                DataTable alumnosTabla = new DataTable();
                miAdaptadorSql.Fill(alumnosTabla);

                // Configura la lista para mostrar el ID y la columna "Informacion"
                ListaAlumnos.ItemsSource = alumnosTabla.DefaultView;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();    
            window3.Show();

        }

        private void EliminarAlumno_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM Alumnos WHERE Matricula = @Matricula";
            SqlCommand sqlCommand = new SqlCommand(consulta,MiConexionSql);
            MiConexionSql.Open();
            sqlCommand.Parameters.AddWithValue("@Matricula", ListaAlumnos.SelectedValue);
            sqlCommand.ExecuteNonQuery();
            MiConexionSql.Close();
            MuestraAlumnos();
        }

        
    }
}
