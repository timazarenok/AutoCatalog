using moicursach.AdminPages;
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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public MainWindow mainWindow;
        public AdminPage(MainWindow _mw)
        {
            InitializeComponent();
            mainWindow = _mw;
        }

        private void Privods_Click(object sender, RoutedEventArgs e)
        {
            Privods add = new Privods();
            add.Show();
        }

        private void Oils_Click(object sender, RoutedEventArgs e)
        {
            Oils add = new Oils();
            add.Show();
        }
        private void Brands_Click(object sender, RoutedEventArgs e)
        {
            Brands add = new Brands();
            add.Show();
        }
        private void KPP_Click(object sender, RoutedEventArgs e)
        {
            KPP add = new KPP();
            add.Show();
        }
        private void Bodies_Click(object sender, RoutedEventArgs e)
        {
            Bodies add = new Bodies();
            add.Show();
        }

        private void Types_Click(object sender, RoutedEventArgs e)
        {
            Types add = new Types();
            add.Show();
        }
    }
}
