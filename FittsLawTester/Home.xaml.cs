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

namespace FittsLawTester
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Part1 part1 = new Part1();
            this.NavigationService.Navigate(part1);
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Part3 part3 = new Part3();
            this.NavigationService.Navigate(part3);
        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
