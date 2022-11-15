﻿using System;
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
        }

        private void redPerdata_Click(object sender, RoutedEventArgs e)
        {
            _user.Name=tbName.Text;
            _user.Surname=tbSurname.Text;
            Base.ES.SaveChanges();
            this.Close();
        }
    }
}