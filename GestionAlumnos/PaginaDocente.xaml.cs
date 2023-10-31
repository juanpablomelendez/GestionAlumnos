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
    /// Interaction logic for PaginaDocente.xaml
    /// </summary>
    public partial class PaginaDocente : Window
    {
        public PaginaDocente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana2 = new Window1();
            ventana2.Show();
            // Cierra la ventana actual si es necesario.
            this.Close();
        }
    }
}
