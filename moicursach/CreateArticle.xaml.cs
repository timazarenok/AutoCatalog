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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для Article.xaml
    /// </summary>
    public partial class CreateArticle : Page
    {
        public MainWindow mw;
        public CreateArticle(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
            Types.ItemsSource = GetData("AutoTypes");
            Oils.ItemsSource = GetData("AutoOils");
            Brands.ItemsSource = GetData("AutoBrands");
            Privods.ItemsSource = GetData("AutoPrivods");
            Bodies.ItemsSource = GetData("TypeBodies");
            KPP.ItemsSource = GetData("KPPTypes");
        }

        private List<string> GetData(string entity)
        {
            DataTable dt = mw.Select($"select [name] from {entity}");
            List<string> data = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                data.Add(dr["name"].ToString());
            }
            return data;
        }
        private int GetId(string name, string entity)
        {
            DataTable dt = mw.Select($"select id from {entity} where [name]='{name}'");
            int id = -1;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id"]);
                }
                return id;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return id;
        }
        private string ChangeComa(string text) => text.Replace(',', '.');

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int type_id = GetId(Types.SelectedItem.ToString(), "AutoTypes");
            int oil_id = GetId(Oils.SelectedItem.ToString(), "AutoOils");
            int brand_id = GetId(Brands.SelectedItem.ToString(), "AutoBrands");
            int privod_id = GetId(Privods.SelectedItem.ToString(), "AutoPrivods");
            int body_id= GetId(Bodies.SelectedItem.ToString(), "TypeBodies");
            int kpp_id = GetId(KPP.SelectedItem.ToString(), "KPPTypes");

            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into Articles values({mw.GetUserId()},{type_id},{oil_id},{brand_id},{privod_id},{kpp_id},{body_id},{Convert.ToInt32(Year.Text)}, '{Name.Text}','{Description.Text}', {ChangeComa(Price.Text)})";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавлено");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mw.OpenPage(MainWindow.Pages.main);
            mw.login = mw.login;
        }
    }
}
