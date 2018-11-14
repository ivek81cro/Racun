using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Racun
{
    public partial class Racuni : Form
    {
        public Racuni()
        {
            InitializeComponent();
            popuniUslugeBox();
            popuniKupciBox();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Redni br.";
            dataGridView1.Columns[1].Name = "Naziv";
            dataGridView1.Columns[2].Name = "Količina";
            txtBrRacuna.Text = "1";
            labNaziv.Text = "12";
        }
        Usluge usluge;

        private void uslugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usluge == null)
            {
                usluge = new Usluge();
                usluge.FormClosed += grad_FormClosed;
                usluge.Show();
            }
            else
            {
                usluge.Close();
                usluge = new Usluge();
                usluge.FormClosed += grad_FormClosed;
                usluge.Show();
            }
        }
        void grad_FormClosed(object sender, FormClosedEventArgs e)
        {
            usluge = null;
            //throw new NotImplementedException();
        }
        void popuniUslugeBox()
        {
            cboxUsluge.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123";
            string upit = "select * from racuni.usluga;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziNaziv = citaj.GetString("naziv");
                    cboxUsluge.Items.Add(traziNaziv);
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuniKupciBox()
        {
            cboxKupci.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123";
            string upit = "select * from racuni.kupac;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziNaziv = citaj.GetString("naziv");
                    cboxKupci.Items.Add(traziNaziv);
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int brojacStavke=0;
        private void btnZakljuci_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/21018900/save-datagridview-to-mysql
            try
            {
                string config = "datasource=localhost;port=3306;username=racuni;password=pass123";
                MySqlConnection con = new MySqlConnection(config);
                string query = "INSERT INTO racuni.stavke(id_stavke, id_racun, id_kupac, kolicina) VALUES (@id_stavke, @id_racun, @id_kupac, @kolicina);";

                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue(
                        "@id_stavke", row);
                    cmd.Parameters.AddWithValue(
                        "@id_racun", int.Parse(txtBrRacuna.Text.ToString()));
                    cmd.Parameters.AddWithValue(
                        "@id_kupac", int.Parse(labNaziv.Text.ToString()));
                    cmd.Parameters.AddWithValue(
                        "@kolicina", int.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString()));

                    cmd.ExecuteNonQuery();
                    
                }
                MessageBox.Show("sucess");
                brojacStavke = 0;
                con.Close();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (MySqlException er)
            {
                MessageBox.Show("Error:" + er.ToString());
            }
        }

        private void btnDodajUslugu_Click(object sender, EventArgs e)
        {
            brojacStavke++;
            dataGridView1.Rows.Add(brojacStavke,cboxUsluge.Text,txtKolicina.Text);
        }

        private void cboxKupci_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123";
            string upit = "select * from racuni.kupac;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                if (citaj.Read())
                {
                    labNaziv.Text = citaj.GetString("naziv");
                    labOib.Text = citaj.GetString("oib");
                    labTelefon.Text = citaj.GetString("telefon");
                    labAdresa.Text = citaj.GetString("adresa");
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
