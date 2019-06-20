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
    /// Logika interakcji dla klasy AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        /// <summary>
        /// Element admin panel jest inicjalizowany następującymi elementami:
        /// <list type="bullet">
        /// <item>
        /// <term>DataGrid Zadania</term>
        /// <description>jest wypełniany wszystkimi zadaniami z bazy danych</description>
        /// </item>
        /// <item>
        /// <term>ComboBox ComboPracownik</term>
        /// <description>jest wypłniany nazwiskami wszystkich pracowników</description>
        /// </item>
        /// <item>
        /// <term>ComboBox dropdown_nazwiska</term>
        /// <description>jest wypłniany nazwiskami wszystkich pracowników</description>
        /// </item>
        /// <item>
        /// <term>ComboBox ComboDzial</term>
        /// <description>jest wypłniany nazwami wszystkich działów</description>
        /// </item>
        /// <item>
        /// <term>ComboBox dropdown_dzialy</term>
        /// <description>jest wypłniany nazwami wszystkich działów</description>
        /// </item>
        /// </list>
        /// </summary>
        public AdminPanel()
        {
            InitializeComponent();
            DataGrids.FillDataGridAllTasks(Zadania);
            Dropdown.FillDropdownUsers(ComboPracownik);
            Dropdown.FillDropdownUsers(dropdown_nazwiska);
            Dropdown.FillDropdownDepartments(dropdown_dzialy);
            Dropdown.FillDropdownDepartments(ComboDzial);
            
        }
        /// <summary>
        /// Przyciśnięcie przycisku powoduje wyświetlnie zadań pracownika, którego nazwisko zostało wybrane przy użyciu elementu dropdown_nazwiska.
        /// </summary>
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string uzytkownik = dropdown_nazwiska.Text;
            int id = GetId.GetIdUser(uzytkownik);
            DataGrids.FillDataGridTasksForUser(Zadania,  id);
        }
        /// <summary>
        /// Przyciśnięcie tego przycisku powoduje wypełnienie obiektu DataGrid zadaniami przypisanymi działowi wybranemu przy użyciu elementu dropdown_działy.
        /// </summary>
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string dzialy = dropdown_dzialy.Text;
            int id = GetId.GetIdDepartment(dzialy);
            DataGrids.FillDataGridTasksForDepartment(Zadania, id);
        }
        /// <summary>
        /// Przyciśnięcie przycisku powoduje pobranie wartości z pól ComboPracownik i ComboDzial i przy użyciu funkcji klasy GetId przekształcenie ich do wartości id.
        /// Wartości uzyskane w ten sposób i wartości pobierane wprost z pól wprowadzania tekstu używane są do wywołania funkcji InsertZadania.
        /// Następnie aktualizowana jest zawartość elementu DataGrid Zadania, tak by pokazać również dodane zadanie. 
        /// </summary>
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string IdValue = Id.Text;
            int Id_dzialuValue = GetId.GetIdDepartment(ComboDzial.Text);
            int Id_pracownikaValue = GetId.GetIdUser(ComboPracownik.Text);
            string OpisValue = Opis.Text;
            string Czas_na_wykoValue = Czas_na_wyko.Text;
            string DeadlineValue = Deadline.Text;
            InsertUpdate.InsertZadania(IdValue, Id_dzialuValue, Id_pracownikaValue, OpisValue, Czas_na_wykoValue, DeadlineValue);
            DataGrids.FillDataGridAllTasks(Zadania);
        }
    }
}
