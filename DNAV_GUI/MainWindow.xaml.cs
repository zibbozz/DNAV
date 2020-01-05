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
            baukastenGrid1.Opacity = 1;
            baukastenGrid1.IsEnabled = true;
            baukastenGrid1.IsHitTestVisible = true;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 1);
        }

        private void Heimlich_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 1;
            baukastenGrid2.IsEnabled = true;
            baukastenGrid2.IsHitTestVisible = true;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 3);
        }

        private void Aggressiv_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 1;
            baukastenGrid3.IsEnabled = true;
            baukastenGrid3.IsHitTestVisible = true;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 5);
        }

        private void Email_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 1;
            baukastenGrid4.IsEnabled = true;
            baukastenGrid4.IsHitTestVisible = true;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 7);
        }

        private void TCP_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 1;
            baukastenGrid5.IsEnabled = true;
            baukastenGrid5.IsHitTestVisible = true;
            baukastenGrid6.Opacity = 0;
            baukastenGrid6.IsEnabled = false;
            baukastenGrid6.IsHitTestVisible = false;
            activeTab.SetValue(Grid.RowProperty, 9);
        }

        private void Erstellen_Click(object sender, MouseButtonEventArgs e)
        {
            baukastenGrid1.Opacity = 0;
            baukastenGrid1.IsEnabled = false;
            baukastenGrid1.IsHitTestVisible = false;
            baukastenGrid2.Opacity = 0;
            baukastenGrid2.IsEnabled = false;
            baukastenGrid2.IsHitTestVisible = false;
            baukastenGrid3.Opacity = 0;
            baukastenGrid3.IsEnabled = false;
            baukastenGrid3.IsHitTestVisible = false;
            baukastenGrid4.Opacity = 0;
            baukastenGrid4.IsEnabled = false;
            baukastenGrid4.IsHitTestVisible = false;
            baukastenGrid5.Opacity = 0;
            baukastenGrid5.IsEnabled = false;
            baukastenGrid5.IsHitTestVisible = false;
            baukastenGrid6.Opacity = 1;
            baukastenGrid6.IsEnabled = true;
            baukastenGrid6.IsHitTestVisible = true;
            activeTab.SetValue(Grid.RowProperty, 11);
        }

        private void Compile_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void keyloggerCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCheckbox.IsEnabled = true;
            keyloggerEmailCheckbox.IsEnabled = true;
        }

        private void keyloggerCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCheckbox.IsEnabled = false;
            keyloggerEmailCheckbox.IsEnabled = false;
        }

        private void keyloggerLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCombobox.IsEnabled = true;
        }

        private void keyloggerLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            keyloggerLocalCombobox.IsEnabled = false;
        }

        private void autostartCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            autostartCopyCheckbox.IsEnabled = true;
        }

        private void autostartCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            autostartCopyCheckbox.IsEnabled = false;
        }

        private void autostartCopyCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            autostartCopyCombobox.IsEnabled = true;
        }

        private void autostartCopyCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            autostartCopyCombobox.IsEnabled = false;
        }

        private void microphoneCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCheckbox.IsEnabled = true;
            microphoneEmailCheckbox.IsEnabled = true;
        }

        private void microphoneCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCheckbox.IsEnabled = false;
            microphoneEmailCheckbox.IsEnabled = false;
        }

        private void microphoneLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCombobox.IsEnabled = true;
        }

        private void microphoneLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            microphoneLocalCombobox.IsEnabled = false;
        }

        private void screenshotCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCheckbox.IsEnabled = true;
            screenshotEmailCheckbox.IsEnabled = true;
        }

        private void screenshotCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCheckbox.IsEnabled = false;
            screenshotEmailCheckbox.IsEnabled = false;
        }

        private void screenshotLocalCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCombobox.IsEnabled = true;
        }

        private void screenshotLocalCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            screenshotLocalCombobox.IsEnabled = false;
        }
    }
}
