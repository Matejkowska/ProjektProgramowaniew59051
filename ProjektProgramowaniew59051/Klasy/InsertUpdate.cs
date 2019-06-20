using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowaniew59051.Klasy
{/// <summary>
/// Klasa InsertUpdate zawiera metody zmieniające zawartość bazy danych. 
/// </summary>
    public class InsertUpdate
    {/// <summary>
    /// Metoda Insert Zadania pozwala na dodanie zadania do bazy danych. 
    /// </summary>
    /// <param name="IdValue"> Id zadania </param>
    /// <param name="Id_dzialuValue">Id działu, do którego ma być przypisane zadanie</param>
    /// <param name="Id_pracownikaValue">Id pracownika, któremu jest zlecone zadanie</param>
    /// <param name="OpisValue">Opis zadania</param>
    /// <param name="Czas_na_wykoValue"> Czas na wykonanie zadania w [h]</param>
    /// <param name="DeadlineValue">Data zakończenia w fromacie YYYY-MM-DD</param>
        public static void InsertZadania(string IdValue, int Id_dzialuValue, int Id_pracownikaValue, string OpisValue, string Czas_na_wykoValue, string DeadlineValue)
        {
            string query = "INSERT INTO [Zadania](Id, Id_dzialu, Id_pracownika, Opis, Czas_na_wyko, Deadline) VALUES('"
                           + IdValue + "','" + Id_dzialuValue + "','" + Id_pracownikaValue + "','" + OpisValue + "','" + Czas_na_wykoValue + "','" + DeadlineValue + "');";

              using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
        /// <summary>
        /// Metoda ZamknijZadanie wyszukuje rekord w tabeli Zadania, zmienia wartość pola "Zakonczone" na "TAK" i wypełnia pole "Data_zakonczenia" 
        /// </summary>
        /// <param name="idZadania"> Id zadania, które ma zostać oznaczone jako zakończone</param>
        /// <param name="data_zakonczenia">Data pokazująca kiedy zadanie zostało zakończone w formacie YYYY-MM-DD</param>
        public static void ZamknijZadanie(int idZadania, string data_zakonczenia )
        {
            string query = "UPDATE [Zadania] SET Data_zakonczenia = '" + data_zakonczenia + "', Zakonczone = 'TAK' WHERE Id='" + idZadania+"';";
            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
