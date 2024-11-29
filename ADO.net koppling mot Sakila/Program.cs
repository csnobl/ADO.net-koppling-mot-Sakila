using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.Data.SqlClient;
namespace ADO.net_koppling_mot_Sakila

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write the actor first name!");
            string actorFirstName = Console.ReadLine();
            Console.WriteLine("Please write the actor last name!");
            string actorLastName = Console.ReadLine();
            
            var connection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            string sqlQuery = "Select title, first_name, last_name " +
                "From film " +
                "Inner join film_actor on film.film_id=film_actor.film_id " +
                "Inner join actor on film_actor.actor_id=actor.actor_id " +
                "Where actor.first_name=" + $"'{actorFirstName}'" +
                " and actor.last_name=" + $"'{actorLastName}'";

            var command1 = new SqlCommand(sqlQuery, connection);
            connection.Open();

            var rec = command1.ExecuteReader();

            if (rec.HasRows)
            {
                while (rec.Read())
                {
                    Console.Write(rec["title"]);
                    Console.Write("\t" + rec["first_name"]);
                    Console.Write("\t" + rec["last_name"] + "\n");
                }
            }

            connection.Close();
        }
    }
}
