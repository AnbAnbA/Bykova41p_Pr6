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
        PartialPurchasee pc = new PartialPurchasee();
        private Table_Users _user;
        List<Table_Purchase> listFilter = new List<Table_Purchase>();
        public Purchase(Table_Users User)
        {
            InitializeComponent();
            LVPur.ItemsSource = Base.ES.Table_Purchase.ToList();
            _user = User;

            List<Table_Customer> customers = Base.ES.Table_Customer.ToList();
            cmbFilt.Items.Add("Любые пользователи");
            for (int i = 0; i < customers.Count; i++)
            {
                cmbFilt.Items.Add(customers[i].NameCustomer);
            }
            cmbFilt.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            pc.CountPage = Base.ES.Table_Purchase.ToList().Count;
            DataContext = pc;
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

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = 4; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = listFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            LVPur.ItemsSource = listFilter.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                case "firstPage":
                    pc.CurrentPage = 1;
                    break;
                case "lastPage":
                    pc.CurrentPage = pc.CountPages;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            LVPur.ItemsSource = listFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbFilterT_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbKol0_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        
        void Filter()
        {
            List<Table_Purchase> list1 = Base.ES.Table_Purchase.ToList();
            string provider = cmbFilt.SelectedValue.ToString();
            int index = cmbFilt.SelectedIndex;
            List<Table_Customer> customers = Base.ES.Table_Customer.Where(z => z.NameCustomer == provider).ToList();
            if (index != 0)
            {
                listFilter = new List<Table_Purchase>();
                foreach (Table_Customer tp in customers)
                {
                    foreach (Table_Purchase tovar in list1)
                    {
                        if (tovar.IdCustomer == tp.IdCustomer)
                        {
                            listFilter.Add(tovar);
                        }
                    }
                }
            }
            else
            {
                listFilter = Base.ES.Table_Purchase.ToList();
            }

            if (!string.IsNullOrWhiteSpace(tbFilterT.Text))
            {
                listFilter = listFilter.Where(z => z.Table_Customer.NameCustomer.ToLower().Contains(tbFilterT.Text.ToLower())).ToList();
            }

            if (cbKol0.IsChecked == true)
            {
                listFilter = listFilter.Where(z => z.Table_Products.Amount != 0).ToList();
            }

            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    listFilter.Sort((x, y) => x.Table_Customer.NameCustomer.CompareTo(y.Table_Customer.NameCustomer));
                    break;
                case 2:
                    listFilter.Sort((x, y) => x.Table_Customer.NameCustomer.CompareTo(y.Table_Customer.NameCustomer));
                    listFilter.Reverse();
                    break;
                case 3:
                    listFilter.Sort((x, y) => Convert.ToDouble(x.TotalPurchase).CompareTo(y.TotalPurchase));
                    break;
                case 4:
                    listFilter.Sort((x, y) => Convert.ToDouble(x.TotalPurchase).CompareTo(y.TotalPurchase));
                    listFilter.Reverse();
                    break;
                case 5:
                    listFilter.Sort((x, y) => Convert.ToInt32(x.Table_Products.Amount).CompareTo(y.Table_Products.Amount));
                    break;
                case 6:
                    listFilter.Sort((x, y) => Convert.ToInt32(x.Table_Products.Amount).CompareTo(y.Table_Products.Amount));
                    listFilter.Reverse();
                    break;
            }

            LVPur.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }
    }
}
