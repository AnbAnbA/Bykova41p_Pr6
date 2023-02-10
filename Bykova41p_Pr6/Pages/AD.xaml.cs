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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AD.xaml
    /// </summary>
    public partial class AD : Page
    {
        public AD()
        {
            InitializeComponent();
            ThicknessAnimation MA = new ThicknessAnimation();
            DoubleAnimation FSl = new DoubleAnimation();
            FSl.From = 20;
            FSl.To = 31;
            FSl.Duration = TimeSpan.FromSeconds(3);
            FSl.RepeatBehavior = RepeatBehavior.Forever;
            FSl.AutoReverse = true;
            Lbuy.BeginAnimation(FontSizeProperty, FSl);

            MA.From = new Thickness(36, 0, 0, 0);
            MA.To = new Thickness(513, 288, 0, 112);
            MA.Duration = TimeSpan.FromSeconds(1);
            MA.RepeatBehavior = RepeatBehavior.Forever;
            MA.AutoReverse = true;
            btnsale.BeginAnimation(MarginProperty, MA);

            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = 50; // начальное значение свойства
            WA.To = 100; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(3); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            btnsale.BeginAnimation(WidthProperty, WA);

            DoubleAnimation HA = new DoubleAnimation();
            HA.From = 20;
            HA.To = 40;
            HA.Duration = TimeSpan.FromSeconds(3);
            HA.RepeatBehavior = RepeatBehavior.Forever;
            HA.AutoReverse = true; 
            btnsale.BeginAnimation(HeightProperty, HA);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += tim;
            timer.Start();

        }
        private void tim(object sender, EventArgs e) 
        {
            btnsale.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Pages.MainM());
        }

        private void btnsale_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
