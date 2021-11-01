using GestionPersonas.UI.Registros;
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

namespace GestionPersonas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PersonaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPersonas registro = new rPersonas();
            registro.Show();
        }

        private void RolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles rol = new rRoles();
            rol.Show();
        }

        private void GrupoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rGrupos grupo = new rGrupos();
            grupo.Show();
        }

        private void AportesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAportes aporte = new rAportes();
            aporte.Show();
        }
    }
}
