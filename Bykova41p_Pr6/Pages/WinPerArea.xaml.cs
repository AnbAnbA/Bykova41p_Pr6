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
using System.Windows.Shapes;

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для WinPerArea.xaml
    /// </summary>
    public partial class WinPerArea : Window
    {
        private Table_Users _user;
        public WinPerArea(Table_Users User)
        {
            InitializeComponent();
            _user = User;
            tbName.Text = _user.Name;
            tbSurname.Text = _user.Surname;
            tbPatr.Text = _user.Patronymic;
            DPBirth.Text = _user.DateBirthday.ToString();
        }

        private void redPerdata_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text!="") 
            {
                if (tbSurname.Text != "") 
                {
                    if (tbPatr.Text != "")
                    {
                        if (DPBirth.Text != "")
                        {
                            _user.Name = tbName.Text;
                            _user.Surname = tbSurname.Text;
                            _user.Patronymic = tbPatr.Text;
                            _user.DateBirthday = (DateTime)DPBirth.SelectedDate;
                            Base.ES.SaveChanges();
                            this.Close();
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
                    MessageBox.Show("Фамилия не должена быть пустой!");
                }
            }
            else
            {
                MessageBox.Show("Имя не должено быть пустым!");
            }
        }
    }
}
