using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace havadurumu
{
    public partial class Form4 : Form
    {
        string havalink = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

        public Form4()
        {
            InitializeComponent();
            datagrip(dataGridView1);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        public void datagrip(DataGridView dataGridView)
        {
           
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;






        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(havalink);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");


            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string maks_sıcaklık = node["Mak"].InnerText;
                string min_sıcaklık = node["Min"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = ili;

                row.Cells[1].Value = maks_sıcaklık;

                row.Cells[2].Value = min_sıcaklık;

                row.Cells[3].Value = durum;
                
                
                dataGridView1.Rows.Add(row);







            }
        }
    }
}
