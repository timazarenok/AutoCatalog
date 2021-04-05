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

namespace moicursach.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для Brands.xaml
    /// </summary>
    public partial class Brands : Window
    {
        MainWindow mw = new MainWindow();
        public Brands()
        {
            InitializeComponent();
            Table.ItemsSource = GetBrands();
        }
        private List<AutoBrands> GetBrands()
        {
            DataTable dt = mw.Select("select [name] from AutoBrands");
            List<AutoBrands> brands = new List<AutoBrands>();
            foreach (DataRow dr in dt.Rows)
            {
                brands.Add(new AutoBrands { Name = dr["name"].ToString() });
            }
            return brands;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into AutoBrands values('{Content.Text}')";
                    command.ExecuteNonQuery();
                }
                Table.ItemsSource = GetBrands();
                MessageBox.Show("Успешно добавлено");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
