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
    /// Логика взаимодействия для CategoryAdd.xaml
    /// </summary>
    public partial class Oils : Window
    {
        MainWindow mw = new MainWindow();

        public Oils()
        {
            InitializeComponent();
            Table.ItemsSource = GetOils();
        }

        private List<AutoOils> GetOils()
        {
            DataTable dt = mw.Select("select [name] from AutoOils");
            List<AutoOils> oils = new List<AutoOils>();
            foreach (DataRow dr in dt.Rows)
            {
                oils.Add(new AutoOils { Name = dr["name"].ToString() });
            }
            return oils;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into AutoOils values('{Content.Text}')";
                    command.ExecuteNonQuery();
                    Table.ItemsSource = GetOils();
                }
                MessageBox.Show("Успешно добавлено");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            mw.Add($"delete from AutoOils where [name] = '{Content.Text}'");
            Table.ItemsSource = GetOils();
        }
    }
}
