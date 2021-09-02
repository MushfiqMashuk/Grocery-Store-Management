using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_1
{
    public partial class UserControl1 : UserControl
    {

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A1G7TIS\\AMINSQL;Initial Catalog=Amin;Integrated Security=True");

        SqlDataReader DataReader;


        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from ProfitView", connection);

            connection.Open();

            DataReader = cmd.ExecuteReader();

            while (DataReader.Read())
            {
                chart1.Series["Profit"].Points.AddXY(DataReader["date"], DataReader["profitcolumn"]);
            }

            connection.Close();
            /*this.chart1.Series["Age"].Points.AddXY("Mashuk", 45);
            this.chart1.Series["Age"].Points.AddXY("Mushfiq", 23);
            this.chart1.Series["Age"].Points.AddXY("Joshim", 67);
            this.chart1.Series["Age"].Points.AddXY("Carl Marks", 56);*/
        }
    }
}
