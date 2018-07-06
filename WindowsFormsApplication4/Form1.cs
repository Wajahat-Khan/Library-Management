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
   
    

    
    
    
    
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

         private Form2 mainForm = null;
    public Form1(Form callingForm)
    {
        mainForm = callingForm as Form2; 
        InitializeComponent();
    }

        private void button1_Click(object sender, EventArgs e)
        {
            run_Query();
        }
        private void run_Query()
        {
            string query = textBox1.Text;
            string a = string.Format("Select * from artifacts where Author= '{0}'", query);
           
            if (query == "")
            {
                MessageBox.Show("please enter a query");
            }
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=Library;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(a, databaseConnection);
            commandDatabase.CommandTimeout = 60;
           


            
    try
    {
        databaseConnection.Open();
       MySqlDataReader reader = commandDatabase.ExecuteReader();
        // Success, now list 

        // If there are available rows
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9)  );
                listBox1.Items.Add(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                
                // Example to save in the listView1 :
                //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                //var listViewItem = new ListViewItem(row);
                //listView1.Items.Add(listViewItem);

                string q = reader.GetString(8);
                int res = String.Compare(q, "0");
                if (res == 0)
                {
                    Console.Write("This book isnt available");
                    listBox1.Items.Add(" \n This book isnt available");
                }

                else
                {
                    Console.Write("This book is available");
                    listBox1.Items.Add(" \n This book is available");

                }
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }

        databaseConnection.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run_Query2();
        }

        private void run_Query2()
        {
            string query = textBox2.Text;
            string a = string.Format("Select * from artifacts where Name= '{0}'", query);

            if (query == "")
            {
                MessageBox.Show("please enter a query");
            }
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=Library;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(a, databaseConnection);
            commandDatabase.CommandTimeout = 60;




            try
            {
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        listBox2.Items.Add(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        // Example to save in the listView1 :
                        //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        //var listViewItem = new ListViewItem(row);
                        //listView1.Items.Add(listViewItem);
                       string q=reader.GetString(8);
                       int res = String.Compare(q, "0");
                       if (res == 0)
                       {
                           Console.Write("This book isnt available");
                           listBox2.Items.Add(" \n This book isnt available");
                       }

                       else
                       {
                           Console.Write("This book is available");
                           listBox2.Items.Add(" \n This book is available");

                       }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            run_Query3();
        }
        private void run_Query3()
        {
            string query = textBox3.Text;
            string a = string.Format("Select * from artifacts where Genre= '{0}'", query);

            if (query == "")
            {
                MessageBox.Show("please enter a query");
            }
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=Library;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(a, databaseConnection);
            commandDatabase.CommandTimeout = 60;




            try
            {
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        listBox3.Items.Add(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        
                        // Example to save in the listView1 :
                        //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        //var listViewItem = new ListViewItem(row);
                        //listView1.Items.Add(listViewItem);
                        string q = reader.GetString(8);
                        int res = String.Compare(q, "0");
                        if (res == 0)
                        {
                            Console.Write("This book isnt available");
                            listBox3.Items.Add(" \n This book isnt available");
                        }

                        else
                        {
                            Console.Write("This book is available");
                            listBox3.Items.Add(" \n This book is available");

                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            run_Query4();
        }


        private void run_Query4()
        {
           
            string a = "Select * from artifacts;";

           
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=Library;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(a, databaseConnection);
            commandDatabase.CommandTimeout = 60;




            try
            {
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        listBox4.Items.Add(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8) + " - " + reader.GetString(9));
                        // Example to save in the listView1 :
                        //string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        //var listViewItem = new ListViewItem(row);
                        //listView1.Items.Add(listViewItem);
                    
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
