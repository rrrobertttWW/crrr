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

namespace _4
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            FiltCB.SelectedIndex = 0;
            SortCB.SelectedIndex = 0;
            UpdateProducts();
            
            if(Manager.CurrentUsers != null)
            {
                UserTB.Text = $"{Manager.CurrentUsers.UserName} {Manager.CurrentUsers.UserSurname} ({Manager.CurrentUsers.Roles?.RoleName})";
            }
            else
            {
                FilerGrid.Visibility = Visibility.Collapsed;
            }
        }
        private void UpdateProducts()
        {
            var current = чудкоботкоEntities.GetContext().Products.ToList();
            if (SortCB.SelectedIndex == 1) current = current.OrderByDescending(x => x.ProductCost).ToList();
            if (SortCB.SelectedIndex == 2) current = current.OrderBy(x => x.ProductCost).ToList();

            if(FiltCB.SelectedIndex == 1) current = current.Where(x => x.CategoryID == 1).ToList();
            if (FiltCB.SelectedIndex == 2) current = current.Where(x => x.CategoryID == 2).ToList();
            if (FiltCB.SelectedIndex == 3) current = current.Where(x => x.CategoryID == 3).ToList();

            string search = (SearchTB.Text ?? "").ToLower();

            if (search != "") current = current.Where(p => (p.ProductName ?? "").ToLower().Contains(search)).ToList();
            ProductListView.ItemsSource = current;
        }

        private void SearchTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void FiltCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
