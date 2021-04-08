using System;
using System.Collections.Generic;
using System.Data;
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
                string number = Number.Text;
                if(number.Length == 16)
                {
                    if (price > 0)
                    {
                        mw.Add($"insert into Orders values({UserID}, {IDArticle}, '{number}', {price})");
                        MessageBox.Show("Заказ успешно Отправлен");
                    }
                    else
                    {
                        MessageBox.Show("Цена отрицательна");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный номер карты");
                    Number.Text = "";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
