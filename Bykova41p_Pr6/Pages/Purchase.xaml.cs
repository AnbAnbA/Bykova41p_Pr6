using System;
using System.Collections.Generic;
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

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для Purchase.xaml
    /// </summary>
    public partial class Purchase : Page
    {
        private Table_Users _user;
        public Purchase(Table_Users User)
        {
            InitializeComponent();
            LVPur.ItemsSource = Base.ES.Table_Purchase.ToList();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Pages.MenuA(_user));
        }

        private void tbMean_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdProducts == index).ToList();
            List<Table_Meaning> TM = Base.ES.Table_Meaning.Where(x => x.IdNom == index).ToList();
            string str = "";

            foreach (Table_Products tp in TP) 
            {
                str+=tp.Table_Nomenclature.NameNom+", ";
                foreach (Table_Meaning tm in TM)
                {
                    str += tm.Table_Characteristic.Characteristic + ": " + tm.Meaning + ", ";
                }
            }
            tb.Text = str.Substring(0, str.Length );
        }
        private void tbPriceCl_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdProducts == index).ToList();
            string str = "";
            foreach (Table_Products tp in TP) 
            {
                str += tp.Table_Nomenclature.PriceNom;
            }
            tb.Text = "Цена: "+str.Substring(0, str.Length);
        }

        private void tbMeansh_Loaded(object sender, RoutedEventArgs e)
        {
            //TextBlock tb = (TextBlock)sender;
            //int index = Convert.ToInt32(tb.Uid);
            //List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdProducts == index).ToList();
            //List<Table_Meaning> TM = Base.ES.Table_Meaning.Where(x => x.IdClothes == index).ToList();
            //string str = "";

            //foreach (Table_Products tp in TP)
            //{
            //    str += tp.Table_Shoes.NameShoes + ", ";
            //    foreach (Table_Meaning tm in TM)
            //    {
            //        str += tm.Table_Characteristic.Characteristic + ": " + tm.Meaning + ", ";
            //    }
            //}
            //tb.Text = str.Substring(0, str.Length);
        }

        private void tbPriceSh_Loaded(object sender, RoutedEventArgs e)
        {
            //TextBlock tb = (TextBlock)sender;
            //int index = Convert.ToInt32(tb.Uid);
            //List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdProducts == index).ToList();

            //string str = "";

            //foreach (Table_Products tp in TP)
            //{
            //    str += tp.Table_Shoes.PriceShoes;
            //}
            //tb.Text = "Цена: " + str.Substring(0, str.Length);
        }

        private void tbtotalPur_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdProducts == index).ToList();
            double total = 0;
            foreach (Table_Products tp in TP) 
            {
                total += Convert.ToDouble((tp.Table_Nomenclature.PriceNom * tp.Amount) );
            }
            tb.Text = "Итог: " + total.ToString() + " руб.";
        }

        private void btdel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Table_Purchase Pur = Base.ES.Table_Purchase.FirstOrDefault(x => x.IdPurchase == index);
            Base.ES.Table_Purchase.Remove(Pur);
            Base.ES.SaveChanges();
            FrameC.frameM.Navigate(new Purchase(_user));
        }

        private void btnupd_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Table_Purchase Pur = Base.ES.Table_Purchase.FirstOrDefault(x => x.IdPurchase == index);
            FrameC.frameM.Navigate(new AddP(Pur));
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new AddP());
        }
    }
}
