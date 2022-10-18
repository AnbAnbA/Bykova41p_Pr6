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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Base.ES = new Entities();
            
        }

        private void BTReg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTSign_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Auto());
        }

        private void BTOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
