using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace ConnectedLevelPartOne
{
    class Program
    {
        static void Main(string[] args)
        {           
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                //string isTest = ConfigurationManager.AppSettings["isTest"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["UsserConnectionString"].ConnectionString;
                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from users";
                //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader= sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string login = reader["login"].ToString();
                    string password = reader["password"].ToString();
                   // DateTime? upDate = null;
                   // if (reader["updateDateTime"] != null)
                   // {
                        //upDate = DateTime.Parse(reader["updateDateTime"].ToString());
                    //}
                }
                reader.Close();
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = sqlConnection;
                insertCommand.CommandText = "insert into users  values('4','asd','asd','2018-11-12 17:30:00.000')";
                //insertCommand.ExecuteNonQuery();


                IPHostEntry host1 = Dns.GetHostEntry("itstep.kz");
                Console.WriteLine(host1.HostName);
                foreach (IPAddress ip in host1.AddressList)
                    Console.WriteLine(ip.ToString());

                Console.WriteLine();

                IPHostEntry host2 = Dns.GetHostEntry("google.com");
                Console.WriteLine(host2.HostName);
                foreach (IPAddress ip in host2.AddressList)
                    Console.WriteLine(ip.ToString());

            }
            //  DownloadFileAsync().GetAwaiter();
            //
            //  Console.WriteLine("Файл загружен");
            //  Console.Read();
            WebRequest request = WebRequest.Create("http://somesite.com/myfile.txt");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();
        }
        //private static async Task DownloadFileAsync()
        //{
        //    WebClient client = new WebClient();
        //    await client.DownloadFileTaskAsync(new Uri("http://somesite.com/myfile.txt"), "mytxtFile.txt");
        //}
    }
}
