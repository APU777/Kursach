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

namespace Kursach
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Two_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow MW = new MainWindow(2);
            MW.Show();
            Close();
        }

        private void Three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow MW = new MainWindow(3);
            MW.Show();
            Close();
        }

        private void Four_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow MW = new MainWindow(4);
            MW.Show();
            Close();
        }
    }
}
