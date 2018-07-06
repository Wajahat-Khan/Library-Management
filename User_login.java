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

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            checkUser();
        }

        private void checkUser()
        {
            string mySqlConnectionString = "datasource=localhost;port=3306;username=root;password=;database=library_management";
            MySqlConnection databaseConnection = new MySqlConnection(mySqlConnectionString);
            string user = username.Text;
            string pass = password.Text;
            try
            {
                databaseConnection.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM users WHERE Name = '" + user + "' and Password = '" + pass + "'", databaseConnection);
                MySqlDataReader userDetails = cmd1.ExecuteReader();
                if (userDetails.HasRows)
                {
                    //fine fine = new fine();
                  //  fine.Show();
                    MessageBox.Show("logged in as: " +user);
                    
                }
            }

            catch
            {
            }

        }

    }
}
