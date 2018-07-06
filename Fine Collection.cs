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
       
                databaseConnection.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM users WHERE Name = '" + user + "' and Password = '" + pass + "'", databaseConnection);
                MySqlDataReader userDetails = cmd1.ExecuteReader();
                  
                if (userDetails.HasRows)
                {
                    int fine = 0;
                    //fine fine = new fine();
                    //  fine.Show();
                    userDetails.Close();

                    MySqlCommand cmd2 = new MySqlCommand("SELECT issued_books.Artifact_id, issued_books.Returned_date FROM issued_books INNER JOIN users ON issued_books.User_id = users.User_id ", databaseConnection);
                    MySqlDataAdapter d1 = new MySqlDataAdapter(cmd2);  
                    DataTable dt = new DataTable();
                        d1.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                           
                            DateTime now = DateTime.Now;
                            DateTime tr= (DateTime) dr["Returned_date"];
                            TimeSpan t= tr-now;
                            double days = t.TotalDays;
                            int remain = (int)days;
                            //MessageBox.Show(remain.ToString());
                            if (remain <= 0) {
                                int count = remain * -1;
                                MySqlCommand cmd3 = new MySqlCommand("SELECT Type FROM artifacts where Id = '" + dr["Artifact_id"] + "'"   , databaseConnection);
                                MySqlDataAdapter d2 = new MySqlDataAdapter(cmd3);
                                DataTable dt2 = new DataTable();
                                d2.Fill(dt2);
                                foreach (DataRow dr2 in dt2.Rows) {
                                    if (dr2["type"].ToString() == "Book")
                                    {
                                        for (int i = 0; i < count; i++)
                                        {
                                            fine += 50;
                                        }
                                    }
                                    else {
                                        for (int i = 0; i < count; i++)
                                        {
                                            fine += 100;
                                        }
                                    }
                                }
                            }
                            
                        }
                        MessageBox.Show("Your Fine is : " + fine);
                    }
                 

                }
         

        }

    }
