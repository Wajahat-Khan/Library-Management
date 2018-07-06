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

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkUser();
        }

        private void checkUser()
        {
            string mySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=library_management";
            MySqlConnection databaseConnection = new MySqlConnection(mySqlConnectionString);
            string id = textBox1.Text;
            string user = textBox2.Text;
            string  pass= textBox3.Text;
            try
            {
                databaseConnection.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM users WHERE Name = '" + user + "' and Password = '" + pass + "'", databaseConnection);
                MySqlDataReader userDetails = cmd1.ExecuteReader();
                if (userDetails.HasRows)
                {
                    //fine fine = new fine();
                    //  fine.Show();
                    MessageBox.Show("logged in as: " + user);
                    int fine = 0;
                    //fine fine = new fine();
                    //  fine.Show();
                    userDetails.Close();

                    MySqlCommand cmd2 = new MySqlCommand("SELECT issued_books.Artifact_id, issued_books.Returned_date FROM issued_books INNER JOIN users ON issued_books.User_id = users.User_id WHERE issued_books.User_id =" + id, databaseConnection);
                    MySqlDataAdapter d1 = new MySqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    d1.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {

                        DateTime now = DateTime.Now;
                        DateTime tr = (DateTime)dr["Returned_date"];
                        TimeSpan t = tr - now;
                        double days = t.TotalDays;
                        int remain = (int)days;
                        //MessageBox.Show(remain.ToString());
                        if (remain <= 0)
                        {
                            int count = remain * -1;
                            MySqlCommand cmd3 = new MySqlCommand("SELECT Type FROM artifacts where Id = '" + dr["Artifact_id"] + "'", databaseConnection);
                            MySqlDataAdapter d2 = new MySqlDataAdapter(cmd3);
                            DataTable dt2 = new DataTable();
                            d2.Fill(dt2);
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                if (dr2["type"].ToString() == "Book")
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        fine += 50;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        fine += 100;
                                    }
                                }
                            }
                        }

                    }
                    MessageBox.Show("Your Fine is : " + fine);


                    InitializeComponent();
                    this.Visible = false;

                    Form1 frm = new Form1(this);
                    frm.Show();

                }
                else
                    MessageBox.Show("Please enter a valid user name or password");

            }

            catch
            {
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string mySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=library_management";
            MySqlConnection databaseConnection = new MySqlConnection(mySqlConnectionString);
            string id = textBox1.Text;
            string user = textBox2.Text;
            string pass = textBox3.Text;
            try
            {
                databaseConnection.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO users(User_id, Name, Password) VALUES (" + id + "," + "'" + user + "'" + "," + "'" + pass + "'" + " )", databaseConnection);
                MySqlDataReader userDetails = cmd1.ExecuteReader();
                MessageBox.Show("Congratulations for Signing Up " + user);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

       

    }
}
