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

namespace Bykova41p_Pr6
{
    /// <summary>
    /// Логика взаимодействия для AdminM.xaml
    /// </summary>
    public partial class AdminM : Page
    {
        //private Table_Users _user;
        public AdminM()
        {
            InitializeComponent();
            //_user = User;
            DGUsers.ItemsSource = Base.ES.Table_Users.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Pages.MenuA());
        }

        private void btbackish_Click(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = Base.ES.Table_Users.ToList();
        }

        private void btAsc_Click(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = Base.ES.Table_Users.OrderBy(z => z.Surname).ToList();
        }

        private void btDesc_Click(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = Base.ES.Table_Users.OrderByDescending(z => z.Surname).ToList();
        }

        private void btfilM_Click(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = Base.ES.Table_Users.Where(z => z.IdGender == 1).ToList();
        }

        private void btfilW_Click(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = Base.ES.Table_Users.Where(z => z.IdGender == 2).ToList();
        }

        private void RBSurn_Click(object sender, RoutedEventArgs e)
        {
            spSurname.Visibility = Visibility.Visible;
            spName.Visibility = Visibility.Collapsed;
            btsearch.Visibility = Visibility.Visible;
        }

        private void RBName_Click(object sender, RoutedEventArgs e)
        {
            spSurname.Visibility = Visibility.Collapsed;
            spName.Visibility = Visibility.Visible;
            btsearch.Visibility = Visibility.Visible;
        }

        private void RBsbros_Click(object sender, RoutedEventArgs e)
        {
            spName.Visibility = Visibility.Collapsed;
            spSurname.Visibility = Visibility.Collapsed;
            btsearch.Visibility = Visibility.Collapsed;
        }

        private void btsearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSurname.Text != "")
            {
                DGUsers.ItemsSource = Base.ES.Table_Users.Where(z => z.Surname == tbSurname.Text).ToList();
            }
            if (tbName.Text != "")
            {
                DGUsers.ItemsSource = Base.ES.Table_Users.Where(z => z.Name == tbName.Text).ToList();
            }
        }
    }
}
