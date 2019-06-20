using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektProgramowaniew59051.Klasy
{/// <summary>
/// Klasa DataGrids gromadzi metody odpowiedzialne za wypełnianie danymi elementów typu DataGrid
/// </summary>
    public class DataGrids
    {/// <summary>
     /// Metoda FillDataGridAllTasks wypełnia obiekt typu DataGrid wszystkimi zadaniami z bazy danych. 
     /// </summary>
     /// <param name="name">Nazwa obiektu, który ma być wypełniony danymi</param>
        static public void FillDataGridAllTasks(DataGrid name)
        {
            string query = "SELECT * FROM [Zadania]";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                name.ItemsSource = dt.DefaultView;
                name.AutoGenerateColumns = true;
                name.CanUserAddRows = false;
            }
        }
        /// <summary>
        /// Metoda FillDataGridTasksForUser wypełnia obiekt typu DataGrid wszystkimi zadaniami z bazy danych, które zostały przypiane do konkretnego użytkownika. 
        /// </summary>
        /// <param name="name">Nazwa obiektu, który ma być wypełniony danymi</param>
        /// <param name="id">Id pracownika, którego zadania mają być wyświetlone</param>
        static public void FillDataGridTasksForUser(DataGrid name, int id)
        {
            string query = "SELECT * FROM [Zadania] WHERE Id_pracownika='" + id + "';";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                name.ItemsSource = dt.DefaultView;
                name.AutoGenerateColumns = true;
                name.CanUserAddRows = false;
            }
        }
        /// <summary>
        /// Metoda FillDataGridTasksForDepartment wypełnia obiekt typu DataGrid wszystkimi zadaniami z bazy danych, które zostały przypiane do konkretnego działu. 
        /// </summary>
        /// <param name="name">Nazwa obiektu, który ma być wypełniony danymi</param>
        /// <param name="id">Id działu, którego zadania mają być wyświetlone</param>
        static public void FillDataGridTasksForDepartment(DataGrid name, int id)
        {
            string query = "SELECT * FROM [Zadania] WHERE Id_dzialu='" + id + "';";

            using (SqlConnection connection =
                           new SqlConnection(DatabaseConnection.connectionString))
            {
                connection.ConnectionString = DatabaseConnection.connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                name.ItemsSource = dt.DefaultView;
                name.AutoGenerateColumns = true;
                name.CanUserAddRows = false;
            }
        }
    }
}
