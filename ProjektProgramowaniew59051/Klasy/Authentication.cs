using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowaniew59051.Klasy
{/// <summary>
/// Klasa Authentication zawiera metody odpowiedzialne za uwierzytelnienie podczas procesu logowania. 
/// </summary>
    public class Authentication
    { /// <summary>
      /// Metoda Login odpowiada za logowanie użytkownika.
      /// </summary>
      /// <param name="login"> To login wprowadzany przez użytkownika, za login w systemie służy nazwisko</param>
      /// <param name="haslo">Hasło użytkownika, wymagany element logowania</param>
      /// <returns>True - jeśli uwierzytelnienie przebegło prawidłowo
      /// False - jeśli wproawdzone dane są błędne</returns>
        public static bool Login (string login, string haslo)
        { 
            string query = "SELECT * FROM Pracownicy where Nazwisko='" + login + "'  and haslo='" + haslo + "'";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    connection.Close();
                    return true;
                    
                }
                else
                {
                    connection.Close();
                    return false;
                }

                
            }
           
        }
        /// <summary>
        /// Metoda LoginAdmin odpowiada za logowanie do Panelu Administratora.   
        /// </summary>
        /// <param name="login"> To login wprowadzany przez użytkownika, za login w systemie służy nazwisko</param>
        /// <param name="haslo">Hasło użytkownika, wymagany element logowania</param>
        /// <returns>True - jeśli uwierzytelnienie przebegło prawidłowo
        /// False - jeśli wproawdzone dane są błędne lub gdy poziom uprawnień jest zbyt niski</returns>
        public static bool LoginAdmin(string login, string haslo)
        {
            string query = "SELECT * FROM Pracownicy where Nazwisko='" + login + "'  and haslo='" + haslo + "' and Rola='1'";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    connection.Close();
                    return true;

                }
                else
                {
                    connection.Close();
                    return false;
                }


            }

        }
    }
}
