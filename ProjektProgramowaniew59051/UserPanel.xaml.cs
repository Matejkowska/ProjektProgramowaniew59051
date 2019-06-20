using ProjektProgramowaniew59051.Klasy;
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

namespace ProjektProgramowaniew59051
{
    /// <summary>
    /// Logika interakcji dla klasy Panel_uzytkownika.xaml
    /// </summary>
    public partial class Panel_uzytkownika : Window
    {
       /// <summary>
       /// Int id przekazywana jest do Panelu_uzytkownika z MainWindow (panelu logowania) i przekazuje informację o id użytkownika, który się zalogował.
       /// </summary>
        public static int id;
        /// <summary>
        /// Panel_uzytkownika jest inicjalizowany z elemntem DataGrid wypełnionym zadaniami przypisanymi zalogowanemu użytkownikowi.
        /// Podczas inicjalizacji element typu ComboBox wypełniany jest Opisami zadań dla danego użytkownika. 
        /// </summary>
        public Panel_uzytkownika()
        {
            
            InitializeComponent();
            DataGrids.FillDataGridTasksForUser(Zadania, id);
            Dropdown.FillDropdownTask(Opis_zadania, id);
        }
        /// <summary>
        /// Wciśnięcie przycisku powoduje pobrania numeru id zadania wybranego przy pomocy elementu ComboBox.
        /// Id zadania wykorzystywane jest przez Metodę ZamknijZadanie, parametr Data_zakonczenia pobierany jest z pola wprowadzania tekstu.
        /// Element DataGrid jest ponownie wypełniany zadaniami użytkownika, tak by wyświetlić wprowadzoną zmianę. 
        /// </summary>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idZadania = GetId.GetIdTask(Opis_zadania.Text);
            InsertUpdate.ZamknijZadanie(idZadania, Data_zakon.Text);
            DataGrids.FillDataGridTasksForUser(Zadania, id);
        }
    }
}

