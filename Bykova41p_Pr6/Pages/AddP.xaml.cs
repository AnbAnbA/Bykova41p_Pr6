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

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        Table_Purchase Pur;
        bool flagUpdate = false;
        string path;

        public void uploadFields()  
        {
            cmbClothes.ItemsSource = Base.ES.Table_Clothes.ToList();
            cmbClothes.SelectedValuePath = "idClothes";
            cmbClothes.DisplayMemberPath = "NameClothes";

            //lbTraits.ItemsSource = BaseClass.tBE.TraitTable.ToList();
            //lbTraits.SelectedValuePath = "idTrait";
            //lbTraits.DisplayMemberPath = "Trait";

            //lbFeed.ItemsSource = BaseClass.tBE.FeedTable.ToList();
        }


        public AddP()
        {
            InitializeComponent();
            uploadFields();
            flagUpdate = true;

        }
    }
}
