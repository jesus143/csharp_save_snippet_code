using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace save_snippet_code.mysql
{
    class Mysql_Query
    { 
        private bool mysql_status = false;
         
        public bool insert_data(int user_id, string title, string description, string snippet_code)
        {
             
            if ( (user_id < 1) || (title == "") || (description == "") || (snippet_code == "") )
            { 
                return false;
            }
             
            try
            {
                 
                MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234567890");
                mcon.Open();
                MySqlCommand comm = mcon.CreateCommand();
                comm.CommandText = "INSERT INTO csharp_save_snippet_codes.snippet_code(user_id, title, description, snippet_code) VALUES(?user_id, ?title, ?description, ?snippet_code)";
                 
                comm.Parameters.Add("?user_id", user_id);
                comm.Parameters.Add("?title", title);
                comm.Parameters.Add("?description", description);
                comm.Parameters.Add("?snippet_code", snippet_code);
                 
                int status = comm.ExecuteNonQuery(); 
               // Console.WriteLine("inserted to database csharp_testing1.users"); 
                mcon.Close(); 
                mysql_status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mysql_status = false; 
            }
             
            return mysql_status;
        }

    }
}
