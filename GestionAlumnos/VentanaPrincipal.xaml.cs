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
using System.Windows.Shapes;

namespace GestionAlumnos
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void Button_Estudiante(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Button_Docentes(object sender, RoutedEventArgs e)
        {
            PaginaDocente paginaDocente  = new PaginaDocente();
            paginaDocente.Show();
            this.Close();
        }

        private void Button_Aulas(object sender, RoutedEventArgs e)
        {
            PaginaAula ventanaa = new PaginaAula();
            ventanaa.Show();
            this.Close();
        }

        private void Button_Inicio(object sender, RoutedEventArgs e)
        {
            Window1 ventana2 = new Window1();
            ventana2.Show();
            this.Close();
        }
    }
}
