using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для WinPerAreaLogPas.xaml
    /// </summary>
    public partial class WinPerAreaLogPas : Window
    {
        private Table_Users _user;
        public WinPerAreaLogPas(Table_Users User)
        {
            InitializeComponent();
            _user = User;
            tbLog.Text = _user.Login;
            //TbPasw.Password = Convert.ToString(_user.Pssword.GetHashCode());
        }

        private void redPerdata_Click(object sender, RoutedEventArgs e)
        {
          
            Regex B = new Regex("(?=.*[A-Z])");
            Regex b = new Regex("([a-z].*[a-z].*[a-z])");
            Regex ch = new Regex("(\\d.*\\d)");
            Regex cs = new Regex("([!@#$%^&*()_+=])");
            Regex os = new Regex("(.+){8,}");

            if (tbLog.Text != "")
            {
                if (TbPasw.Password != "")
                {
                    if (B.IsMatch(TbPasw.Password) == true)
                    {
                        if (b.IsMatch(TbPasw.Password) == true)
                        {
                            if (ch.IsMatch(TbPasw.Password) == true)
                            {
                                if (cs.IsMatch(TbPasw.Password) == true)
                                {
                                    if (os.IsMatch(TbPasw.Password) == true)
                                    {
                                        int pasGegCode = TbPasw.Password.GetHashCode();
                                        Table_Users User = Base.ES.Table_Users.FirstOrDefault(z => z.Login == tbLog.Text);
                                        if (User == null || tbLog.Text == _user.Login)
                                        {
                                            _user.Login = tbLog.Text;
                                            _user.Pssword = pasGegCode;
                                            Base.ES.SaveChanges();
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Такой логин уже существует! Придумайте другой логин!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Длина пароля должна быть не менее 8 символов");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("В пароле должен быть хотя бы один специальный символ (!@#$%^&*()_+=)");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пароль должен иметь хотя бы 2 цифры");
                            }
                        }
                        else
                        {
                            MessageBox.Show("В пароле должно быть не менее 3 строчных латинских символов");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен иметь хотя бы 1 заглавную латинскую букву");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не может быть пустым!");
                }
            }
            else 
            {
                MessageBox.Show("Логин не может быть пустым!");
            }
        }
    }
}
