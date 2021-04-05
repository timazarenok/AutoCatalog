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
    }
}
