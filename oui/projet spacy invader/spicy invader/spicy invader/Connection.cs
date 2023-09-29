using System.Data;
using MySql;
using System;
using MySql.Data;

using MySql.Data.MySqlClient;
namespace enemie
{
  


    public class Connection
    {

        public static void Connect()
        {
            string server = "localhost";
            string database = "db_space_invaders";
            string user = "root";
            string password = "root";
            string port = "6033";

            Console.Clear();
            string connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", server, port, user, password, database);


            MySqlConnection conn = new(connString);
            try
            {
                conn.Open();

                Console.WriteLine("Connection Successful");

                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connString);
            }


            string createUserQuery = $"SELECT jouPseudo, jouNombrePoints FROM `t_joueur` order by jouNombrePoints desc limit 5;";

            // Assurez-vous que la connexion est ouverte.
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            MySqlCommand createUserCommand = new(createUserQuery, conn);
            MySqlDataReader reader = createUserCommand.ExecuteReader();
            Console.WriteLine("Pseudo: NB Point");
            while (reader.Read())
            {
                Console.WriteLine(reader["jouPseudo"].ToString() + " : " + reader["jouNombrePoints"].ToString());
            }

            reader.Close();
            // Fermez la connexion après avoir terminé.
            conn.Close();
            Console.Write("apuiller sur une touche");
            Console.ReadLine();
            GameEngine.ShowMainMenu();

        }
    }
}


