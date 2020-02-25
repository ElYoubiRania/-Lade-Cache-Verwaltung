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
    public partial class authentification : Form
    {

       
        public authentification()
        {
            InitializeComponent();
        }

        public void SeConnecter()
        {
            try
            {
                string connexion = ConfigurationManager.ConnectionStrings["MaConnexion"].ConnectionString;
                MySqlConnection mysqlcnx = new MySqlConnection(connexion);
                string sqlquery = " select * from users where login like '" + textBox1.Text + "' and password like '" + textBox2.Text + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(sqlquery, mysqlcnx);
                mysqlcnx.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {


                    
                    Form1 F = new Form1();
                    F.Show();
                    
                    /*statut = dt.Rows[0][3].ToString();
                    label3.Text = "Vous êtes : " + statut;
                    this.Hide();*/


                }
                else
                {
                    MessageBox.Show("Irrtum! Falsche Anmeldung oder falsches Passwort! ");
                }


                mysqlcnx.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Verbindungsfehler !");
            }

        }
    

    private void button2_Click(object sender, EventArgs e)
        {
            signUp su = new signUp();
            su.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeConnecter();
            
        }
    }
}
