using Checklist.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace Checklist
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        public MySqlConnection mysql;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlConnection = ConfigurationManager.ConnectionStrings["MaConnexion"].ConnectionString;
                mysql = new MySqlConnection(sqlConnection);
                mysql.Open();
                string queryInsert = "insert into users(login, password, status) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "') ";
                MySqlCommand cmd = new MySqlCommand(queryInsert, mysql);
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() == 0)
                {
                    label4.Text = "Registrierung erfolgreich abgeschlossen !";
                }
                else
                {
                    label4.Text = "Bitte alle Felder ausfüllen !";
                }
                mysql.Close();
                //this.Close();
                textBox1.Text = ""; textBox2.Text = ""; comboBox1.Text = "";
                authentification a = new authentification();
                a.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler: bitte alle Felder ausfüllen ");                
            }


        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            authentification a = new authentification();
            a.Hide();
        }
    }
}
