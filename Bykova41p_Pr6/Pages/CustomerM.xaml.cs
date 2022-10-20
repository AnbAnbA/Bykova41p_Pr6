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
    /// Логика взаимодействия для CustomerM.xaml
    /// </summary>
    public partial class CustomerM : Page
    {
        private Table_Users _user;
        public CustomerM(Table_Users User)
        {
            InitializeComponent();
        }
    }
}
