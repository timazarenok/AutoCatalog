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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public MainWindow mw;
        public int IDArticle { get; set; }
        public int UserID { get; set; }
        public Order()
        {
            InitializeComponent();
            mw = new MainWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(Price.Text);
                if (price > 0)
                {
                    MessageBox.Show($"{price}");
                    mw.Add($"insert into Orders values({UserID}, {IDArticle}, {price})");
                }
                else
                {
                    MessageBox.Show("Цена отрицательна");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
