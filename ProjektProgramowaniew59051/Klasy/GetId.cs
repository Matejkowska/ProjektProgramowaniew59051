using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowaniew59051.Klasy
{/// <summary>
///Klasa GetId skupia w sobie metody pobierające Id z bazy danych dla określonych parametrów
/// </summary>
    public class GetId
    {/// <summary>
    /// GetIdDepartment - wyszukuje Id działu używając jego nazwy.
    /// </summary>
    /// <param name="dzial">Nazwa Działu</param>
    /// <returns>Zwraca id działu</returns>
       static public int GetIdDepartment(string dzial)
        {
            int departmentId;
            string query = "SELECT Id FROM [Dzialy] WHERE Nazwa_dzialu='" + dzial + "';";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                departmentId = (int)command.ExecuteScalar();
                connection.Close();
            }
            return departmentId;
        }
        /// <summary>
        /// GetIdUser - wyszukuje Id pracownika używając jego nazwiska.
        /// </summary>
        /// <param name="uzytkownik">Nazwisko pracownika</param>
        /// <returns>Zwraca id pracownika</returns>

        static public int GetIdUser(string uzytkownik)
        {
            int userId;
            string query = "SELECT Id FROM [Pracownicy] WHERE Nazwisko='" + uzytkownik + "';";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                userId = (int)command.ExecuteScalar();
                connection.Close();
            }
            return userId;
        }
        /// <summary>
        /// GetIdTask - wyszukuje Id zadania używając jego opisu.
        /// </summary>
        /// <param name="opis">Opis zadania</param>
        /// <returns>Zwraca id zadania</returns>
        static public int GetIdTask(string opis)
        {
            int userId;
            string query = "SELECT Id FROM [Zadania] WHERE Opis='" + opis + "';";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                userId = (int)command.ExecuteScalar();
                connection.Close();
            }
            return userId;
        }
    }
}
