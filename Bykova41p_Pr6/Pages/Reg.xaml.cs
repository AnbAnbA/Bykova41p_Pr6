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
            CbRole.SelectedIndex = 1;
            
        }

        private void BTregister_Click(object sender, RoutedEventArgs e)
        {
            Regex B = new Regex("(?=.*[A-Z])");
            Regex b = new Regex("([a-z].*[a-z].*[a-z])");
            Regex ch = new Regex("(\\d.*\\d)");
            Regex cs = new Regex("([!@#$%^&*()_+=])");
            Regex os = new Regex("(.+){8,}");

            if (TbSurn.Text != "")
            {
                if (TbName.Text != "")
                {
                    if (TbPatr.Text != "")
                    {
                        if (DPBirth.Text != "")
                        {
                            if (CbGender.Text!= "")
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
                                                    Table_Users User = Base.ES.Table_Users.FirstOrDefault(z => z.Login == TbLog.Text);
                                                    if (User == null)
                                                    {
                                                        Table_Users UserRez = new Table_Users() { Name = TbName.Text, Surname = TbSurn.Text, Patronymic = TbPatr.Text, DateBirthday = (DateTime)DPBirth.SelectedDate, IdGender = CbGender.SelectedIndex + 1, Login = TbLog.Text, Pssword = pasGegCode, IdRole = 2 };
                                                        Base.ES.Table_Users.Add(UserRez);
                                                        Base.ES.SaveChanges();
                                                        MessageBox.Show("Вы зарегистрированы");
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
                                MessageBox.Show("Пол не должен быть пустым!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("День рождения не должен быть пустым!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Отчество не должено быть пустым!");
                    }
                }
                else
                {
                    MessageBox.Show("Имя не должена быть пустой!");
                }
            }
            else
            {
                MessageBox.Show("Фамилия не должено быть пустым!");
            }
        }
    }
}
