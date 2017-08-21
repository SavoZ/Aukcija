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

namespace Aukcija
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            using (ProdajaEntities context = new ProdajaEntities())
            {
                tblLogin login = new tblLogin();
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string role=string.Empty;

                string person = string.Empty;
                bool isValid = false;
                foreach (var l in context.tblLogins)
                {
                    if (l.username == username && l.password == password)
                    {
                        
                        person = l.username;
                        role = l.role.Trim();
                        isValid = true;
                        break;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    MessageBox.Show("Username or password is not correct","Warning");
                }


                if (role == "admin")
                {
                    MainWindow main = new MainWindow("admin");
                    main.Show();
                    this.Hide();
                }
                else if (role == "user")
                {
                    MainWindow main = new MainWindow(person);
                    main.Show();
                    this.Hide();
                }
              
            }
        }
    }
}
