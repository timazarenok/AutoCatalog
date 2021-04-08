using moicursach.AdminPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class Types : Window
    {
        MainWindow mw = new MainWindow();
        public Types()
        {
            InitializeComponent();
            Table.ItemsSource = GetTypes();
        }
        private List<AutoTypes> GetTypes()
        {
            DataTable dt = mw.Select("select [name] from AutoTypes");
            List<AutoTypes> types = new List<AutoTypes>();
            foreach(DataRow dr in dt.Rows)
            {
                types.Add(new AutoTypes { Name = dr["name"].ToString() });
            }
            return types;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)    
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into AutoTypes values('{Name.Text}')";
                    command.ExecuteNonQuery();
                    Table.ItemsSource = GetTypes();
                    MessageBox.Show("Успешно добавлено");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            mw.Add($"delete from AutoTypes where [name] = '{Name.Text}'");
            Table.ItemsSource = GetTypes();
        }
    }
}
