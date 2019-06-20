using ProjektProgramowaniew59051.Klasy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ProjektProgramowaniew59051
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/// <summary>
    /// Okno MainWindow jest ekranem logowania. 
    /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        AdminPanel adminpanel = new AdminPanel();
        Panel_uzytkownika userpanel = new Panel_uzytkownika();
        /// <summary>
        /// Przycisk logowania do Panelu_uzytkownika, wciśnięcie może dać 3 rezultaty:
        /// - jeśli nazwisko nie zostało wprowadzone, zostanie wyświetlony komunikat "Wprowadz nazwisko"
        /// - jeśli dane logowania są niepoprawne zostanie wyswielony komunikat "Bledna nazwa uzytkownika lub haslo"
        /// - jesli dane sa poprawne, okno MainWindow zostaie zamkniete i zostanie wywołany Panel_uzytkownika.
        /// </summary>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Nazwisko_login.Text.Length == 0)
            {
                errormessage.Text = "Wprowadz nazwisko";
                Nazwisko_login.Focus();
            }
            else
            {
                string login = Nazwisko_login.Text;
                string haslo = Haslo_login.Password;
                if (Authentication.Login(login, haslo))
                {
                    Panel_uzytkownika.id = GetId.GetIdUser(Nazwisko_login.Text);
                    userpanel.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Bledna nazwa uzytkownika lub haslo";
                }
            }
        }
        /// <summary>
        /// Przycisk logowania do AdminPanel, wciśnięcie może dać 3 rezultaty:
        /// - jeśli nazwisko nie zostało wprowadzone, zostanie wyświetlony komunikat "Wprowadz nazwisko"
        /// - jeśli dane logowania są niepoprawne zostanie wyswielony komunikat "Bledna nazwa uzytkownika lub haslo"
        /// - jesli dane sa poprawne, okno MainWindow zostaie zamkniete i zostanie wywołany AdminPanel.
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Nazwisko_login.Text.Length == 0)
            {
                errormessage.Text = "Wprowadz nazwisko";
                Nazwisko_login.Focus();
            }
            else
            {
                string login = Nazwisko_login.Text;
                string haslo = Haslo_login.Password;
                if (Authentication.LoginAdmin(login, haslo))
                {
                    adminpanel.Show();
                    Close();
                }
                else
                {
                   errormessage.Text = "Bledna nazwa uzytkownika lub haslo";
                }
            }
        }
        }
    }


