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
    /// Логика взаимодействия для MenuA.xaml
    /// </summary>
    public partial class MenuA : Page
    {
        private Table_Users _user;
        public MenuA(Table_Users User)
        {
            InitializeComponent();
            _user = User;
        }

        private void BTTabUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new AdminM(_user));
        }

        private void BTTabOsn_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Purchase(_user));
        }

        private void btuserarea_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Pages.PersonalArea(_user));
        }
    }
}
