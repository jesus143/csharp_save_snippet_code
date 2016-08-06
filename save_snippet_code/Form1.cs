using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using MySql.Data.MySqlClient;

namespace save_snippet_code
{
    public partial class Form1 : Form
    { 
        private int user_id = 1;
         
        public Form1()
        {
            InitializeComponent(); 
        }
         
        private void button1_Click(object sender, EventArgs e)
        { 
            save_response_label.Text = "";
             
            mysql.Mysql_Query msql = new mysql.Mysql_Query();

            if (!msql.insert_data(user_id, title_textbox.Text, description_textbox.Text, snippet_code_textbox.Text))
            {
               // MessageBox.Show("Please don't leave empty field.");
                save_response_label.Text = "Please don't leave empty field.....";
            }
            else
            {
                save_response_label.Text = "saved...";
            }
            
        } 
    }
}
