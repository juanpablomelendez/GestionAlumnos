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
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, MiConexionSql);

            using (miAdaptadorSql)
            {
                DataTable alumnosTabla = new DataTable();
                miAdaptadorSql.Fill(alumnosTabla);

                // Configura la lista para mostrar el ID y la columna "Informacion"
                ListaAlumnos.DisplayMemberPath = "Informacion";
                ListaAlumnos.SelectedValuePath = "Matricula";
                ListaAlumnos.ItemsSource = alumnosTabla.DefaultView;
            }
        }

    }
}
