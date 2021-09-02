using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_1
{
    public partial class Form1 : Form
    {


        SqlConnection connenction = new SqlConnection("Data Source=DESKTOP-0KTFLO8;Initial Catalog=Project;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Please Fiil Up All the fields!");
                }

                else
                {

                    

                    if (textBox4.Text == textBox5.Text)
                    {

                        connenction.Open();

                        SqlCommand cmd = new SqlCommand("insert into admin values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '"+textBox4.Text+"')", connenction);

                        cmd.ExecuteNonQuery();

                        connenction.Close();

                        MessageBox.Show("Sign Up Successful!");

                        Form2 frm = new Form2();

                        frm.Show();

                    }

                    else
                    {
                        MessageBox.Show("Password Didn't Match!");
                    }

                    
                }
 
            }

            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form2 frm = new Form2();
                frm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text.Contains("@"))
            {
                textBox2.Focus();
            }
            else
            {
                if (e.KeyCode.Equals(Keys.Tab))
                {
                    
                    MessageBox.Show("Please Enter a Valid Email Address!");

                    textBox1.Focus();
                    
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Contains("@")))
            {
                MessageBox.Show("Enter a Valid Email Address!");

                textBox1.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "anikahmed@gmail.com")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "anikahmed@gmail.com";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Anik")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Anik";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Ahmed")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Ahmed";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Password")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.White;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                textBox4.Text = "Password";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Password")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Password";
                textBox5.ForeColor = Color.Silver;
            }
        }

       
    }
}
