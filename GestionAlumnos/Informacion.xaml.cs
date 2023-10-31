using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data.SqlClient;
using System.Data;

namespace GestionAlumnos
{
    /// <summary>
    /// Lógica de interacción para Informacion.xaml
    /// </summary>
    public partial class Informacion : Window
    {
        private SqlConnection miConexionSql;

        public Informacion()
        {
            InitializeComponent();
            /// GestionAlumnosConnectionString
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["GestionAlumnos.Properties.Settings.GestionAlumnosConnectionString"].ConnectionString;
            miConexionSql = new SqlConnection(miConexion);

            MuestraAlumnos();
            MuestraMaestros();
            MuestraCursos();
            MuestraAulas();
            MuestraAsignaturas();
            MuestraAlumnosCursos();
            MuestraCursosAsignaturas();
        }

        private void MuestraAlumnos()
        {
            string consulta = "SELECT Matricula, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM Alumnos"; // Consulta para obtener Matricula e 'Nombre Apellido'
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable alumnosTabla = new DataTable();
                miAdaptadorSql.Fill(alumnosTabla);

                // Configura la lista para mostrar el ID y el nombre completo
                ListaAlumnos.DisplayMemberPath = "NombreCompleto";
                ListaAlumnos.SelectedValuePath = "Matricula";
                ListaAlumnos.ItemsSource = alumnosTabla.DefaultView;
            }
        }

        private void MuestraMaestros()
        {
            string consulta = "SELECT MaestroID, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM Maestros";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable maestrosTabla = new DataTable();
                miAdaptadorSql.Fill(maestrosTabla);

                listaMaestros.DisplayMemberPath = "NombreCompleto";
                listaMaestros.SelectedValuePath = "MaestroID";
                listaMaestros.ItemsSource = maestrosTabla.DefaultView;
            }
        }

        private void MuestraCursos()
        {
            string consulta = "SELECT CursoID, NombreCurso FROM Cursos";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable cursosTabla = new DataTable();
                miAdaptadorSql.Fill(cursosTabla);

                ListaCursos.DisplayMemberPath = "NombreCurso";
                ListaCursos.SelectedValuePath = "CursoID";
                ListaCursos.ItemsSource = cursosTabla.DefaultView;
            }
        }

        private void MuestraAulas()
        {
            string consulta = "SELECT AulaID, NombreAula FROM Aulas";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable aulasTabla = new DataTable();
                miAdaptadorSql.Fill(aulasTabla);

                ListaAulas.DisplayMemberPath = "NombreAula";
                ListaAulas.SelectedValuePath = "AulaID";
                ListaAulas.ItemsSource = aulasTabla.DefaultView;
            }
        }

        private void MuestraAsignaturas()
        {
            string consulta = "SELECT AsignaturaID, NombreAsignatura FROM Asignaturas";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable asignaturasTabla = new DataTable();
                miAdaptadorSql.Fill(asignaturasTabla);

                ListaAsignaturas.DisplayMemberPath = "NombreAsignatura";
                ListaAsignaturas.SelectedValuePath = "AsignaturaID";
                ListaAsignaturas.ItemsSource = asignaturasTabla.DefaultView;
            }
        }

        private void MuestraAlumnosCursos()
        {
            string consulta = "SELECT Matricula, CursoID FROM AlumnosCursos";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable alumnosCursosTabla = new DataTable();
                miAdaptadorSql.Fill(alumnosCursosTabla);

                ListaAlumnosCursos.DisplayMemberPath = "CursoID"; // Puedes mostrar la información que desees aquí
                ListaAlumnosCursos.SelectedValuePath = "Matricula"; // Puedes configurar esto según tus necesidades
                ListaAlumnosCursos.ItemsSource = alumnosCursosTabla.DefaultView;
            }
        }

        private void MuestraCursosAsignaturas()
        {
            string consulta = "SELECT CursoID, AsignaturaID FROM CursosAsignaturas";
            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                DataTable cursosAsignaturasTabla = new DataTable();
                miAdaptadorSql.Fill(cursosAsignaturasTabla);

                ListaCursosAsignaturas.DisplayMemberPath = "AsignaturaID"; // Puedes mostrar la información que desees aquí
                ListaCursosAsignaturas.SelectedValuePath = "CursoID"; // Puedes configurar esto según tus necesidades
                ListaCursosAsignaturas.ItemsSource = cursosAsignaturasTabla.DefaultView;
            }
        }




    }
}
