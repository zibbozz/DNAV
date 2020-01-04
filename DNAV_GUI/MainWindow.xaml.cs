using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
        private string path = "dnav.exe";
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
            clientsGrid.Opacity = 1;
            clientsGrid.IsEnabled = true;
            baukastenGrid.Opacity = 0;
            baukastenGrid.IsEnabled = false;
            removerGrid.Opacity = 0;
            removerGrid.IsEnabled = false;
        }

        private void Baukasten_Click(object sender, MouseButtonEventArgs e)
        {
            clientsGrid.Opacity = 0;
            clientsGrid.IsEnabled = false;
            baukastenGrid.Opacity = 1;
            baukastenGrid.IsEnabled = true;
            removerGrid.Opacity = 0;
            removerGrid.IsEnabled = false;
        }

        private void Remover_Click(object sender, MouseButtonEventArgs e)
        {
            clientsGrid.Opacity = 0;
            clientsGrid.IsEnabled = false;
            baukastenGrid.Opacity = 0;
            baukastenGrid.IsEnabled = false;
            removerGrid.Opacity = 1;
            removerGrid.IsEnabled = true;
        }

        private void ChangePath_Click(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Exe Datei|*.exe";
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = sfd.FileName;
                pathTextBlock.Text = path;
            }
        }

        private void Allgemein_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Heimlich_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Aggressiv_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
