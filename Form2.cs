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

namespace EmlakKayıtProgramSon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-LQ9NQVA;Initial Catalog=siteler;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }




        private void button5_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Zambak Sitesi")
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }


            if (comboBox1.Text == "Papatya Sitesi")
            {
                button2.BackColor = Color.Red;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }


            if (comboBox1.Text == "Lale Sitesi")
            {
                button3.BackColor = Color.Red;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }

                if (comboBox1.Text == "Gül Sitesi") { 
                button4.BackColor = Color.Red;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
        }
    }
    private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert Into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) values ('"+textBox6.Text.ToString()+"', '"+
            comboBox1.Text.ToString()+"', '"+comboBox3.Text.ToString()+"', '"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+comboBox4.Text.ToString()+"',  '"
            +textBox7.Text.ToString()+"','"+textBox5.Text.ToString()+"', '"+textBox4.Text.ToString()+"', '"+textBox3.Text.ToString()+"','"+comboBox2.Text.ToString()+"')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        int id = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from sitebilgi where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox6.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id ='" + textBox6.Text.ToString() + "', site='" + comboBox1.Text.ToString() + "',oda='"
            + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "', fiyat='" + textBox2.Text.ToString() + "', blok='" + comboBox4.Text.ToString() + "', no='" + textBox7.Text.ToString() + "', adsoyad='" + textBox5.Text.ToString() + "', telefon='"
            + textBox4.Text.ToString() + "', notlar='" + textBox3.Text.ToString() + "', satkira='" + comboBox2.Text.ToString() + "' where id =" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();

        }
    }
}
