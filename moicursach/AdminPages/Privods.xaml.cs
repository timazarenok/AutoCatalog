using moicursach.Models;
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
    /// Логика взаимодействия для addPrice.xaml
    /// </summary>
    public partial class Privods : Window
    {
        MainWindow mw = new MainWindow();
        public Privods()
        {
            InitializeComponent();
            Table.ItemsSource = GetPrivods();
        }
        private List<AutoPrivods> GetPrivods()
        {
            DataTable dt = mw.Select("select [name] from AutoPrivods");
            List<AutoPrivods> privods = new List<AutoPrivods>();
            foreach (DataRow dr in dt.Rows)
            {
                privods.Add(new AutoPrivods { Name = dr["name"].ToString() });
            }
            return privods;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into AutoPrivods values ('{Name.Text}')";
                    command.ExecuteNonQuery();
                }
                Table.ItemsSource = GetPrivods();
                MessageBox.Show("Успешно добавлено");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            mw.Add($"delete from AutoPrivods where [name] = '{Name.Text}'");
            Table.ItemsSource = GetPrivods();
        }
    }
}
