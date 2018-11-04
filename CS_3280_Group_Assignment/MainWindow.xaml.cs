using CS_3280_Group_Assignment.Main;
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

namespace CS_3280_Group_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This will accually be the main window of this program
        /// </summary>
        wndMain main;

        public MainWindow()
        {
            InitializeComponent();

            //create the new main window
            main = new wndMain();
            this.Hide();
            main.Show();
        }
    }
}
