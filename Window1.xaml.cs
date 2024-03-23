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

namespace PracticaBACHKOVApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var email = emailBox.Text;
            var pass = passBox.Text;
            var context = new AppDbContext();
            var user_exists =context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists != null)
            {
                MessageBox.Show("Такой пользователь уже в клубе крутышек");
                return;
            }
            var user = new User { Login = login, Email = email, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club, buddy");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
        MainWindow aut = new MainWindow();
            aut.Show();
            this.Close();
        }
    }
}
