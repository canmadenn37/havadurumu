using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace havadurumu
{
    class kullanıcıgiris
    {
        SqlConnection con = new SqlConnection("server = DESKTOP-GC349NE\\SQLEXPRESS; Initial Catalog = hava; Integrated Security = True");
        SqlCommand komut;
        SqlDataReader read;
        
        Form2 frm2 = new Form2();
        

        
        public SqlDataReader kullanıcı(TextBox admin_ad, TextBox admin_sifre)
        {
            con.Open();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "select *from admin where admin_ad='" + admin_ad.Text + "'and admin_sifre='" + admin_sifre.Text + "'";
            read = komut.ExecuteReader();

            if (read.Read()==true)
            {
                MessageBox.Show("Sisteme Giriş Başarılı", "Sistem Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frm2.ShowDialog();
            }
            else
            {

                MessageBox.Show("Sisteme Giriş Başarısız", "Sistem Giriş ",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            con.Close();
            return read;
            




            






        }
    }
}
