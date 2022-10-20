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
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void BTAuto_Click(object sender, RoutedEventArgs e)
        {
            int pasGegCode = PBPasw.Password.GetHashCode();
            Table_Users User = Base.ES.Table_Users.FirstOrDefault(z => z.Login == TbLogin.Text && z.Pssword == pasGegCode);
            if (User == null)
            {
                MessageBox.Show("Вы не зарегистрированы");
            }
            else
            {
                switch (User.IdRole)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте, администратор " + User.Name);
                        FrameC.frameM.Navigate(new Pages.MenuA());  // переход в меню администратора
                        break;
                    case 2:
                        MessageBox.Show("Здравствуйте, пользователь " + User.Name);
                        FrameC.frameM.Navigate(new CustomerM(User));  // переход в личный кабинет
                        break;
                }
            }
        }
    }
}
