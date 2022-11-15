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
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        private Table_Users _user;
        Table_Purchase Pur;
        bool flagUpdate = false;
        string path;

        public void uploadFields()  
        {
            //cmbClothes.ItemsSource = Base.ES.Table_Clothes.ToList();
            //cmbClothes.SelectedValuePath = "idClothes";
            //cmbClothes.DisplayMemberPath = "NameClothes";

            lbClothes.ItemsSource = Base.ES.Table_Clothes.ToList();
            lbClothes.SelectedValuePath = "IdClothes";
            lbClothes.DisplayMemberPath = "NameClothes";

            //lbFeed.ItemsSource = BaseClass.tBE.FeedTable.ToList();
        }


        public AddP(Table_Purchase Pur)
        {
            InitializeComponent();
            uploadFields();
            this.Pur = Pur;
            flagUpdate = true;
            tbName.Text = Pur.Table_Customer.NameCustomer;
            //cmbClothes.SelectedIndex = (int)Pur.Table_Products.IdClothes - 1;
            dpDatePur.SelectedDate = Pur.DatePurchase;
            List<Table_Products> TP = Base.ES.Table_Products.Where(x => x.IdClothes == Pur.Table_Products.IdClothes).ToList();
            foreach (Table_Products tp in TP) 
            {
                if (TP.FirstOrDefault(x => x.IdClothes == tp.IdClothes) != null)
                {
                    lbClothes.SelectedItems.Add(tp);
                }
            }
        }
        public AddP()
        {
            InitializeComponent();
            uploadFields();
            flagUpdate = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Purchase(_user));
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (flagUpdate == false)
                {
                    Pur = new Table_Purchase();
                }
                Table_Customer customer = new Table_Customer()
                {
                    NameCustomer = tbName.Text,
                };
                Base.ES.Table_Customer.Add(customer);


                Pur.Table_Customer.IdCustomer = customer.IdCustomer;
                Pur.DatePurchase = Convert.ToDateTime(dpDatePur.SelectedDate);
               

                if (flagUpdate == false)
                {
                    Base.ES.Table_Purchase.Add(Pur);
                }
                // BaseClass.tBE.SaveChanges();

                List<Table_Products> TP = Base.ES.Table_Products.Where(x =>x.IdProducts==Pur.Table_Products.IdProducts ).ToList();

                  if (TP.Count > 0)
                  {
                    foreach (Table_Products tp in TP)
                    {
                        Base.ES.Table_Products.Remove(tp);
                    }
                  }

                   foreach (Table_Clothes t in lbClothes.SelectedItems)
                   {
                    Table_Products TPT = new Table_Products()  
                    {
                        IdProducts = Pur.IdProducts,
                        IdClothes = t.IdClothes
                    };
                    Base.ES.Table_Products.Add(TPT);
                   }
                //  BaseClass.tBE.SaveChanges();

              
                Base.ES.SaveChanges();
                MessageBox.Show("Информация добавлена");
            //}
            //catch
            //{
            //    MessageBox.Show("Что-то пошло не по плану");
        //}
    }
    }
}
