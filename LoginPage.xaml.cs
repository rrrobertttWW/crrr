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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LgnBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = (LoginTB.Text).Trim();
            var user = чудкоботкоEntities.GetContext().Users.FirstOrDefault( u => u.UserLogin == login);

            if (user != null)
            {
                Manager.CurrentUsers = user;
                Manager.MainFrame.Navigate(new ProductPage());
            }
            else MessageBox.Show("пользователь не найден");
        }

        private void LgnHowGuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrentUsers = null;
            Manager.MainFrame.Navigate(new ProductPage());
        }
    }
}
