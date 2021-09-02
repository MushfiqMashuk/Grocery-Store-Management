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
    public partial class Form5 : Form
    {


        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-L5G3GOO\\ANIKSQL;Initial Catalog=Admin;Integrated Security=True");

        DataTable dataTable; 

        SqlDataReader DataReader; 

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                connection.Close();

                String str2 = "select quantity from product where productid = '" + textBox1.Text + "'";
                //string quan;
                int quan = 0;


                SqlCommand cmd2 = new SqlCommand(str2, connection);

                connection.Open();

                using ( DataReader = cmd2.ExecuteReader())
                {
                    while (DataReader.Read())
                    {
                       quan = int.Parse(DataReader["quantity"].ToString());
                    }
                }

                connection.Close();

                //int quan2 = int.Parse(quan);

                if (quan != 0 && quan != null && (quan - int.Parse(textBox2.Text)) >= 0)
                {

                    String str = "exec AddSell '" + textBox1.Text + "','" + int.Parse(textBox2.Text) + "' ,'" + float.Parse(textBox3.Text) + "' ,'" + float.Parse(label3.Text) + "'";

                    connection.Open();

                    SqlCommand cmd = new SqlCommand(str, connection);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Inserted Successfully!");

                    connection.Close();

                    displayData();
                    clearData();
                }

                else
                {
                    MessageBox.Show("Product is Out of Stock!");
                    clearData();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Add an Existing Product Id");
            }

        }

        /*private void addLabel()
        {
           

            Label l1 = new Label();
            l1.Text = textBox1.Text;
            l1.AutoSize = true;
           // l1.Padding = new System.Windows.Forms.Padding(5,0,10,0);
            flowLayoutPanel1.Controls.Add(l1);
            

            Label l2 = new Label();
            l2.Text = textBox2.Text;
            l2.AutoSize = true;
            //l2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            l2.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(l2);
            

            Label l3 = new Label();
            l3.Text = textBox3.Text;
            l3.AutoSize = true;
            // l3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            l3.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(l3);
            
        }*/

       
        private void displayData()
        {
            String str = "select * from Sell order by date desc";

            connection.Open();

            dataTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            connection.Close();

            
        }

        private void clearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label3.Text = "00";
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();

            frm.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {

                float a = float.Parse(textBox3.Text) * int.Parse(textBox2.Text);

                label3.Text = string.Format("{0}", a);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {

                float a = float.Parse(textBox3.Text) * int.Parse(textBox2.Text);

                label3.Text = string.Format("{0}", a);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    DataView dv = new DataView(dataTable);

                    dv.RowFilter = string.Format("date" + " LIKE '%{0}%'", textBox5.Text);

                    dataGridView1.DataSource = dv;
                }

                /*else
                {
                    //String str = string.Format("select * from product where ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);

                    //displayData("select * from product");

                    DataView dv = new DataView(dataTable);

                    dv.RowFilter = string.Format("ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);

                    dataGridView1.DataSource = dv;
                }*/
            }

            catch (Exception ex)
            {
                MessageBox.Show("Plz Enter A Valid Character!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string str = ""
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            frm.Show();
        }
    }
}
