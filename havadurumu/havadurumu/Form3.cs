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

namespace havadurumu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            datagrip(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server = DESKTOP-GC349NE\\SQLEXPRESS; Initial Catalog = hava; Integrated Security = True");
            DataTable dt = new DataTable();
            string sql1 = "Select Şehir,Yıl,Ay,Sıcaklık,Nem,Rüzgar,Karlı_gün,Deniz_Basınç,Sürekli_Rüzgar,Fırtınalı_Gün,Sisli_Gün,Ortalama_Görüş from hava_verileri where Şehir=@aranan and Yıl=@tarih1 and Ay=@tarih2";

            SqlDataAdapter da = new SqlDataAdapter(sql1, con);

            da.SelectCommand.Parameters.AddWithValue("@aranan", textBox1.Text);
            da.SelectCommand.Parameters.AddWithValue("@tarih1", textBox2.Text);
            da.SelectCommand.Parameters.AddWithValue("@tarih2", textBox3.Text);

            con.Open();
            da.Fill(dt);
           
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            

        }

        public void datagrip(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            



        }
    }
}
