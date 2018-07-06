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
            string mySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=library_management";
            MySqlConnection databaseConnection = new MySqlConnection(mySqlConnectionString);
        }
    }
}
