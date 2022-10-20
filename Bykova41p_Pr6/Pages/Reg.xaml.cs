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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
            CbGender.ItemsSource = Base.ES.Table_Gender.ToList();
            CbGender.SelectedValuePath = "idGender";
            CbGender.DisplayMemberPath = "gender";

            CbRole.ItemsSource = Base.ES.Table_Role.ToList();
            CbRole.SelectedValuePath = "idRole";
            CbRole.DisplayMemberPath = "Role";
            
        }

        private void BTregister_Click(object sender, RoutedEventArgs e)
        {
            int pasGegCode = TbPasw.Password.GetHashCode();
            Table_Users User = Base.ES.Table_Users.FirstOrDefault(z => z.Login == TbLog.Text);
            if (User == null)
            {
                Table_Users UserRez = new Table_Users() { Name = TbName.Text, Surname = TbSurn.Text, Patronymic = TbPatr.Text, DateBirthday = (DateTime)DPBirth.SelectedDate, IdGender = CbGender.SelectedIndex + 1, Login = TbLog.Text, Pssword = pasGegCode, IdRole = CbRole.SelectedIndex + 1 };
                Base.ES.Table_Users.Add(UserRez);
                Base.ES.SaveChanges();
                MessageBox.Show("Вы зарегистрированы");
            }
            else
            {
                MessageBox.Show("Такой логин уже существует! Придумайте другой логин!");
            }
             
        }
    }
}
