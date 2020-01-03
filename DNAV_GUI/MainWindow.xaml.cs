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

namespace DNAV_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Clients_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Baukasten_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Remover_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
