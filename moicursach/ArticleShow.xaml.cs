using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для CartAddWindow.xaml
    /// </summary>
    public partial class ArticleShow : Window
    {
        public MainWindow mainWindow;
        public int Id { get; set; }
        public ArticleShow()
        {
            InitializeComponent();
        }

        private string ChangeComa(string text) => text.Replace(',', '.');
    }
}
