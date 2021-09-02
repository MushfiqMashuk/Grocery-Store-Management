using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Form3 frm = new Form3();

              
                frm.Show();

                /*if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please Fiil Up All the fields!");
                }

                else
                {

                    Form3 frm;

                    frm = new Form3();

                    frm.Show();
                }*/

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Email";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text=="Password")
            {
                textBox2.Text="";
                textBox2.ForeColor=Color.White;
        }
    }

        private void textBox2_Leave(object sender, EventArgs e)
        {
        
            if(textBox2=="")
            {
                textBox2.Text="Password";
                textBox2.ForeColor=Color.Silver;
        }
}

