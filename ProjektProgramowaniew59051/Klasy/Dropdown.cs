using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektProgramowaniew59051.Klasy
{/// <summary>
/// Klasa Dropdown skupia w sobie metody odpowiedzialne za obsługę elementów typu ComboBox.
/// </summary>
    public class Dropdown 
    {/// <summary>
     /// Metoda FillDropdownUsers wypełnia nazwiskami pracowników element typu ComboBox. 
     /// </summary>
     /// <param name="combobox_name">Nazwa elementu, który ma być wypełniony danymi</param>
        static public void FillDropdownUsers(ComboBox combobox_name)
        {
            SqlDataReader sqlDataReader;
            string query = "SELECT Nazwisko FROM [Pracownicy]";
            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                sqlDataReader = command.ExecuteReader();
                combobox_name.Items.Clear();
                while (sqlDataReader.Read())
                {
                    combobox_name.Items.Add(sqlDataReader.GetString(0));

                }
                connection.Close();
                combobox_name.SelectedIndex = 1;

            }

        }
        /// <summary>
        /// Metoda FillDropdownDepartments wypełnia nazwami działów element typu ComboBox. 
        /// </summary>
        /// <param name="combobox_name">Nazwa elementu, który ma być wypełniony danymi</param>
        static public void FillDropdownDepartments(ComboBox combobox_name)
        {
            SqlDataReader sqlDataReader;
            string query = "SELECT Nazwa_dzialu FROM [Dzialy]";
            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                sqlDataReader = command.ExecuteReader();
                combobox_name.Items.Clear();
                while (sqlDataReader.Read())
                {
                    combobox_name.Items.Add(sqlDataReader.GetString(0));

                }
                connection.Close();
                combobox_name.SelectedIndex = 1;

            }
        }
        /// <summary>
        /// Metoda FillDropdownUsers wypełnia opis zadań przydzielonych konkretnemu pracownikami element typu ComboBox. 
        /// </summary>
        /// <param name="combobox_name">Nazwa elementu, który ma być wypełniony danymi</param>
        /// <param name="user_id">Id pracownika, dla którego będą wyświetlone zadania</param>
        static public void FillDropdownTask(ComboBox combobox_name, int user_id)
        {
            SqlDataReader sqlDataReader;
            string query = "SELECT Opis FROM [Zadania] WHERE Id_pracownika='"+user_id+"';";
            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                sqlDataReader = command.ExecuteReader();
                combobox_name.Items.Clear();
                while (sqlDataReader.Read())
                {
                    combobox_name.Items.Add(sqlDataReader.GetString(0));

                }
                connection.Close();
                combobox_name.SelectedIndex = 1;

            }
        }
    }
}
