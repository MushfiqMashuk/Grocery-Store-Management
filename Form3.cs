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
    public partial class Form3 : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A1G7TIS\\AMINSQL;Initial Catalog=Amin;Integrated Security=True");

        DataTable dataTable;

        SqlDataReader DataReader;

        

        public Form3()
        {
            InitializeComponent();

            FillCombo(comboBox2, "select * from category", "categoryName");
            FillCombo(comboBox1, "select * from brand", "brandName");

            label11.Text = "";
            label12.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String str= "exec AddProduct '" + textBox1.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + int.Parse(textBox2.Text) + "','" + float.Parse(textBox4.Text) + "','" + textBox5.Text + "' ,'" + dateTimePicker1.Value.ToString() + "'";

                connection.Open();

                SqlCommand cmd = new SqlCommand(str, connection);

                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Data Inserted Successfully!");

                connection.Close();

                displayData();

                clear();
            }

            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();

            frm.Show();

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void displayData()
        {
            String str = "select * from product";

            connection.Open();

            dataTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = DateTime.Today.ToString();

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            //try
            //{
                if (comboBox3.SelectedIndex >= 0 && textBox3.Text != "")
                {
                    DataView dv = new DataView(dataTable);

                    dv.RowFilter = string.Format(comboBox3.SelectedItem.ToString() + " LIKE '%{0}%'", textBox3.Text);

                    dataGridView1.DataSource = dv;

                }

                else
                {
                    //String str = string.Format("select * from product where ProductName LIKE '%{0}%' or category LIKE '%{0}%' or BrandName LIKE '%{0}%'", textBox1.Text);

                    //displayData("select * from product");


                    if (textBox3.Text != "" && Int32.TryParse(textBox3.Text, out int result))
                    {
                        DataView dv = new DataView(dataTable);

                        dv.RowFilter = "productID = '" + int.Parse(textBox3.Text) + "' or CategoryID = '" + int.Parse(textBox3.Text) + "' or BrandID = '" + int.Parse(textBox3.Text) + "'";

                        dataGridView1.DataSource = dv;
                    }

                    else if (textBox3.Text != "")
                    {
                        DataView dv = new DataView(dataTable);

                        dv.RowFilter = string.Format("ProductName LIKE '%{0}%' or category LIKE '%{0}%' or Brand LIKE '%{0}%'", textBox3.Text);

                        dataGridView1.DataSource = dv;
                    }
                //}
            }

            /*catch (Exception ex)
            {
                MessageBox.Show("dff");
            }*/
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //}

            /*catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "update product set productName = '" + textBox1.Text + "', category = '" + comboBox2.Text + "', Brand = '" + comboBox1.Text + "', quantity = '" + int.Parse(textBox2.Text) + "', price = '" + float.Parse(textBox4.Text) + "', Description = '" + textBox5.Text + "', ExpireDate = '" + dateTimePicker1.Value.ToString() + "' where productID = '" + int.Parse(textBox3.Text) + "'";

                connection.Open();

                SqlCommand cmd = new SqlCommand(str, connection);

                cmd.ExecuteNonQuery();

                connection.Close();

                displayData();

                clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "delete from product where productID = '" + int.Parse(textBox3.Text) + "'";

                connection.Open();

                SqlCommand cmd = new SqlCommand(str, connection);

                cmd.ExecuteNonQuery();

                connection.Close();

                displayData();

                clear();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();

            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();

            frm.Show();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void FillCombo(ComboBox comboBox, String str, String str2)
        {
             
           
            SqlCommand cmd = new SqlCommand(str, connection);

            try
            {
                connection.Open();

                DataReader = cmd.ExecuteReader();

                while (DataReader.Read())
                {
                    
                    comboBox.Items.Add(DataReader[str2]);

                    
                }

                connection.Close();

            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Invalid!");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "")
                {
                    String str = "insert into category values('" + textBox6.Text + "')";

                    SqlCommand cmd = new SqlCommand(str, connection);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    connection.Close();

                    label11.Text = "Please Reload The Page To See The Changes";
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Please Enter a Valid Categor Name!");
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text != "")
                {
                    String str = "insert into brand values('" + textBox7.Text + "')";

                    SqlCommand cmd = new SqlCommand(str, connection);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    connection.Close();


                    label12.Text = "Please Reload The Page To See The Changes";
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Please Enter a Valid Brand Name!");
            }

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
