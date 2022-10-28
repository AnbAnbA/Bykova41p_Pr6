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
    }
}