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
    public partial class Form4 : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0KTFLO8;Initial Catalog=Project;Integrated Security=True");

        DataTable dataTable;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "" && comboBox1.SelectedIndex < 0)
            {
                String str = "select * from product";

                displayData(str);
            }

            else if(comboBox1.SelectedIndex >= 0)
            {
                String str = string.Format("select * from product where " + comboBox1.SelectedItem.ToString() + " LIKE '%{0}%'", textBox1.Text);

                displayData(str);
                
            }

            else
            {
                String str = string.Format("select * from product where ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);
                displayData(str);
            }
            /**********String str = "select * from product";
            String str2 = "mashuk";
            str = string.Format(str + " = '{0}'", str2);*********/
            
        }

        private void displayData(String str)
        {
            connection.Open();

            dataTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    DataView dv = new DataView(dataTable);

                    dv.RowFilter = string.Format(comboBox1.SelectedItem.ToString() + " LIKE '%{0}%'", textBox1.Text);

                    dataGridView1.DataSource = dv;
                }

                else
                {
                    //String str = string.Format("select * from product where ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);

                    //displayData("select * from product");

                    DataView dv = new DataView(dataTable);

                    dv.RowFilter = string.Format("ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);

                    dataGridView1.DataSource = dv;
                }
            }

             catch (Exception ex)
            {
                MessageBox.Show("Plz Enter A Valid Character!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String str = "insert into productInfo values('" + textBox2.Text + "', '" + textBox3.Text + "', '" + int.Parse(textBox4.Text) + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "', '" + textBox8.Text + "' )";

            connection.Open();

            SqlCommand cmd = new SqlCommand(str, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();

            frm.Show();
        }
    }
}
