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
using System.Windows.Shapes;

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public MainWindow mw;
        public int IDArticle { get; set; }
        public int UserID { get; set; }
        public Order()
        {
            InitializeComponent();
            mw = new MainWindow();
        }

        private Article GetArticle ()
        {
            Article article = new Article();
            DataTable articles = mw.Select($"select Articles.id, Articles.[name], [description], [price], [year], " +
                $"AutoTypes.[name] as [type], AutoOils.[name] as [oil], AutoBrands.[name] as [brand], " +
                $"AutoPrivods.[name] as [privod], KPPTypes.[name] as [kpp], TypeBodies.[name] as [body] from Articles " +
                $"join AutoTypes on AutoTypes.id = idtype " +
                $"join AutoOils on AutoOils.id = idoiltype " +
                $"join AutoBrands on AutoBrands.id = idbrand " +
                $"join AutoPrivods on AutoPrivods.id = idprivod " +
                $"join KPPTypes on KPPTypes.id = idkpp " +
                $"join TypeBodies on TypeBodies.id = idbody where Articles.id={IDArticle}");
            foreach (DataRow dr in articles.Rows)
            {
                article = new Article()
                {
                    ID = Convert.ToInt32(dr["id"]),
                    Name = dr["name"].ToString(),
                    Description = dr["description"].ToString(),
                    Price = dr["price"].ToString(),
                    Year = Convert.ToInt32(dr["year"]),
                    Type = dr["type"].ToString(),
                    Oil = dr["oil"].ToString(),
                    Brand = dr["brand"].ToString(),
                    Privod = dr["privod"].ToString(),
                    Kpp = dr["kpp"].ToString(),
                    Body = dr["body"].ToString()
                };
            }
            return article;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(Price.Text);
                string number = Number.Text;
                if(number.Length == 16)
                {
                    if (price > 0)
                    {
                        mw.Add($"insert into Orders values({UserID}, {IDArticle}, '{number}', {price})");
                        Article article = GetArticle();
                        MessageBox.Show($"Заказ успешно Отправлен \n {article.Name}, {article.Brand}, {article.Body}, {article.Price}, {article.Year}, {article.Kpp}, {article.Oil}, {article.Privod}, {article.Type}  ");
                    }
                    else
                    {
                        MessageBox.Show("Цена отрицательна");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный номер карты");
                    Number.Text = "";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
