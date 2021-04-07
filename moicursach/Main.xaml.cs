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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public int Id { get; set; }
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            InputListBox();
        }

        private void InputListBox()
        {
            DataTable articles = mainWindow.Select("select id, Articles.[name], [description], [price] from Articles");
            List<Article> items = new List<Article>();
            foreach(DataRow dr in articles.Rows)
            {
                items.Add(new Article() { ID = Convert.ToInt32(dr["id"]), Name = dr["name"].ToString(), Description = dr["description"].ToString(), Price = dr["price"].ToString() });
            }
            Items.ItemsSource = items;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.login);
        }

        private void CreateArticle(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.article);
        }  

        private void Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Items.SelectedItem = sender;
            int id = (Items.SelectedItem as Article).ID;
            Id = id;
            try
            {
                Article article = GetInfo(id);
                Name.Content = article.Name;
                Description.Text = article.Description;
                Price.Content = article.Price;
                Type.Content = article.Type;
                Oil.Content = article.Oil;
                Brand.Content = article.Brand;
                Privod.Content = article.Privod;
                Kpp.Content = article.Kpp;
                Body.Content = article.Body;
            }
            catch
            {
                MessageBox.Show("Выбирете продукт");
            }
        }

        private Article GetInfo(int id)
        {
            Article article = new Article();
            DataTable articles = mainWindow.Select($"select Articles.id, Articles.[name], [description], [price], [year], " +
                $"AutoTypes.[name] as [type], AutoOils.[name] as [oil], AutoBrands.[name] as [brand], " +
                $"AutoPrivods.[name] as [privod], KPPTypes.[name] as [kpp], TypeBodies.[name] as [body] from Articles " +
                $"join AutoTypes on AutoTypes.id = idtype " +
                $"join AutoOils on AutoOils.id = idoiltype " +
                $"join AutoBrands on AutoBrands.id = idbrand " +
                $"join AutoPrivods on AutoPrivods.id = idprivod " +
                $"join KPPTypes on KPPTypes.id = idkpp " +
                $"join TypeBodies on TypeBodies.id = idbody where Articles.id={id}");
            foreach (DataRow dr in articles.Rows)
            {
                article = new Article() { ID = Convert.ToInt32(dr["id"]), Name = dr["name"].ToString(), 
                    Description = dr["description"].ToString(), Price = dr["price"].ToString(), Year = Convert.ToInt32(dr["year"]),
                    Type = dr["type"].ToString(), Oil = dr["oil"].ToString(), Brand = dr["brand"].ToString(), 
                    Privod = dr["privod"].ToString(), Kpp = dr["kpp"].ToString(), Body = dr["body"].ToString()
                };
            }
            return article;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.IDArticle = Id;
            order.UserID = mainWindow.GetUserId();
            order.Show();
        }
    }
}
