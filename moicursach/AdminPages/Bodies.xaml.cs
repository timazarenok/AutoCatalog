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
    /// Логика взаимодействия для Bodies.xaml
    /// </summary>
    public partial class Bodies : Window
    {
        MainWindow mw = new MainWindow();
        public Bodies()
        {
            InitializeComponent();
            Table.ItemsSource = GetBodies();
        }

        private List<TypeBodies> GetBodies()
        {
            DataTable dt = mw.Select("select [name] from TypeBodies");
            List<TypeBodies> bodies = new List<TypeBodies>();
            foreach (DataRow dr in dt.Rows)
            {
                bodies.Add(new TypeBodies { Name = dr["name"].ToString() });
            }
            return bodies;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into TypeBodies values('{Content.Text}')";
                    command.ExecuteNonQuery();
                }
                Table.ItemsSource = GetBodies();
                MessageBox.Show("Успешно добавлено");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            mw.Add($"delete from TypeBodies where [name] = '{Content.Text}'");
            Table.ItemsSource = GetBodies();
        }
    }
}
