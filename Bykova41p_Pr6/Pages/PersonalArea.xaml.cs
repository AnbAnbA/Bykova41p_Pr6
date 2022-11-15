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
    /// Логика взаимодействия для PersonalArea.xaml
    /// </summary>
    public partial class PersonalArea : Page
    {
        private Table_Users _user;
        public PersonalArea(Table_Users User)
        {
            InitializeComponent();
            this._user = User;
            tbName.Text = _user.Name;
            tbSurname.Text = _user.Surname;

        }

        private void redaUserData_Click(object sender, RoutedEventArgs e)
        {
            WinPerArea winPerArea = new WinPerArea(_user);
            winPerArea.ShowDialog();
            FrameC.frameM.Navigate(new PersonalArea(_user));
        }
    }
}
