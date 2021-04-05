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
            try
            {
                Article article = GetInfo(id);
                Name.Content = article.Name;
                Description.Text = article.Description;
                Price.Content = article.Price;
            }
            catch
            {
                MessageBox.Show("Выбирете продукт");
            }
        }

        private Article GetInfo(int id)
        {
            Article article = new Article();
            DataTable articles = mainWindow.Select($"select id, Articles.[name], [description], [price] from Articles where id={id}");
            foreach (DataRow dr in articles.Rows)
            {
                article = new Article() { ID = Convert.ToInt32(dr["id"]), Name = dr["name"].ToString(), Description = dr["description"].ToString(), Price = dr["price"].ToString() };
            }
            return article;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
