using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(LocalDb)\sunnydb;Initial Catalog=AddressBookService;Integrated Security=True";
        //  public SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// UC16 to retrieve all contacts
        /// </summary>
        /// <returns></returns>
        public static ContactDatabase GetAllContacts()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                ContactDatabase cdb = new ContactDatabase();

                string query = @"select c.first_name, c.last_name, c.city, c.phone_no, b.bk_name, b.bk_type 
                                 from contact c inner join booknametype b on c.book_id = b.book_id WHERE LOWER(c.first_name)='shakira';";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cdb.firstname = reader.GetString(0);
                        cdb.lastname = reader.GetString(1);
                        cdb.city = reader.GetString(2);
                        cdb.phone = reader.GetString(3);
                        cdb.B_Name = reader.GetString(4);
                        cdb.B_Type = reader.GetString(5);
                    }
                }
                else
                {
                    Console.WriteLine("Rows doesn't exist!");
                }
                reader.Close();
                return cdb;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Close();
            }
        }
        /// <summary>
        /// UC17 to retrieve details by city or state
        /// </summary>
        /// <returns></returns>
        public static string UpdateDatabase()
        {
            string state = "";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "update contact set State='California' where LOWER(first_name)='rosa';" +
                                "select* from contact c where LOWER(c.first_name)= 'rosa';";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        state = reader.GetString(4);
                    }
                }
                else
                {
                    Console.WriteLine("Updated rows doesn't exist!");
                }
                reader.Close();
                return state;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return state;
            }
            finally
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Close();
            }
        }

    }
}
