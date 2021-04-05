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
    /// Логика взаимодействия для KPP.xaml
    /// </summary>
    public partial class KPP : Window
    {
        MainWindow mw = new MainWindow();
        public KPP()
        {
            InitializeComponent();
            Table.ItemsSource = GetKPP();
        }

        private List<KPPTypes> GetKPP()
        {
            DataTable dt = mw.Select("select [name] from KPPTypes");
            List<KPPTypes> kpp = new List<KPPTypes>();
            foreach (DataRow dr in dt.Rows)
            {
                kpp.Add(new KPPTypes { Name = dr["name"].ToString() });
            }
            return kpp;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into KPPTypes values('{Content.Text}')";
                    command.ExecuteNonQuery();
                }
                Table.ItemsSource = GetKPP();
                MessageBox.Show("Успешно добавлено");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
