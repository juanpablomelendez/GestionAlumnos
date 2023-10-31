using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for PaginaDocente.xaml
    /// </summary>
    public partial class PaginaDocente : Window
    {
        public PaginaDocente()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["GestionAlumnos.Properties.Settings.GestionAlumnosConnectionString1"].ConnectionString;
            MiConexionSql = new SqlConnection(miConexion);
            MuestraMaestros();
        }
        SqlConnection MiConexionSql;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana2 = new Window1();
            ventana2.Show();
            // Cierra la ventana actual si es necesario.
            this.Close();
        }
        private void MuestraMaestros()
        {
            string consulta = "SELECT MaestroID, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto,Telefono,CorreoElectronico FROM Maestros";
            ;
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, MiConexionSql);

            using (miAdaptadorSql)
            {
                DataTable alumnosTabla = new DataTable();
                miAdaptadorSql.Fill(alumnosTabla);

                // Configura la lista para mostrar el ID y la columna "Informacion"
                ListaMaestros.ItemsSource = alumnosTabla.DefaultView;
            }
        }

        private void ListaMaestros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
