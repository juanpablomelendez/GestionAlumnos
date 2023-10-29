using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;

namespace GestionAlumnos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /// GestionAlumnosConnectionString
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["GestionAlumnos.Properties.Settings.GestionAlumnosConnectionString"].ConnectionString;
            //miConexionSql = new SqlConnection(miConexion);
        }

        private void contraseña_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string correoIngresado = correo.Text; // Supongamos que 'correo' es el TextBox para el correo.
            string contraseñaIngresada = contrasena.Text; // Supongamos que 'contraseña' es el TextBox para la contraseña.

            if (ValidarCredenciales(correoIngresado, contraseñaIngresada))
            {
                // Credenciales válidas, abre la segunda ventana.
                Window1 ventana2 = new Window1();
                ventana2.Show();
                // Cierra la ventana actual si es necesario.
                this.Close();
            }
            else
            {
                // Credenciales incorrectas, muestra un mensaje de error.
                MessageBox.Show("Credenciales incorrectas. Por favor, verifica tu correo y contraseña.");
            }
        }
        private bool ValidarCredenciales(string correo, string contraseña)
        {
            // Define las credenciales válidas
            string correoValido = "juanpabloxz@outlook.com";
            string contraseñaValida = "12345";

            // Compara las credenciales ingresadas con las credenciales válidas
            return correo == correoValido && contraseña == contraseñaValida;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Obtiene la contraseña ingresada por el usuario
            string contraseñaIngresada = contrasena.Text;

            // Verifica si la contraseña ingresada es la correcta (en este caso, "1234")
            if (ValidarCredenciales(contraseñaIngresada))
            {
                // Contraseña correcta, abre la ventana "Informacion"
                Informacion info = new Informacion();
                info.Show();
            }
            else
            {
                // Contraseña incorrecta, muestra un mensaje
                MessageBox.Show("Contraseña incorrecta. Inténtelo de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCredenciales(string contraseñaIngresada)
        {
            // Aquí puedes implementar la lógica de verificación de la contraseña
            // Por ejemplo, puedes comparar la contraseña ingresada con la contraseña correcta
            return contraseñaIngresada == "1234";
        }


        private void correo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
             this.Close();
        }
    }
}
