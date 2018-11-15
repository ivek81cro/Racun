﻿using System;
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
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Redni br.";
            dataGridView1.Columns[1].Name = "Naziv";
            dataGridView1.Columns[2].Name = "Količina";
            dataGridView1.Columns[3].Name = "Cijena";
            dataGridView1.Columns[4].Name = "Iznos";
        }

        void popuniUslugeBox()
        {
            cboxUsluge.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
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
                    cboxUsluge.Items.Add(citaj.GetString("naziv"));
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
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
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
        double iznos=0;
        double pdv=0;
        double ukupno=0;

        private void btnZakljuci_Click(object sender, EventArgs e)
        {
            int brRac=0;
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "select id_racun from racuni.racun;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    brRac= 1 + int.Parse(citaj.GetString("id_racun"));
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //https://stackoverflow.com/questions/21018900/save-datagridview-to-mysql
            try
            {
                string config = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
                MySqlConnection con = new MySqlConnection(config);
                string query = "INSERT INTO racuni.stavke(id_racun, id_kupac, kolicina, cijena, iznos)" +
                    "VALUES (@id_racun, @id_kupac, @kolicina, @cijena, @iznos);";

                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue(
                        "@id_racun", brRac);
                    cmd.Parameters.AddWithValue(
                        "@id_kupac", int.Parse(txtSifraKupca.Text.ToString()));
                    cmd.Parameters.AddWithValue(
                        "@kolicina", int.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString()));
                    cmd.Parameters.AddWithValue(
                        "@cijena", double.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString()));
                    cmd.Parameters.AddWithValue(
                        "@iznos", double.Parse(dataGridView1.Rows[row].Cells[4].Value.ToString()));

                    cmd.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Zaključeno");
                brojacStavke = 0;
                con.Close();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (MySqlException er)
            {
                MessageBox.Show("Error:" + er.ToString());
            }
            //unos računa
            string upit2 = "INSERT INTO racuni.racun (broj, iznos, pdv, ukupno) VALUES ('"+brRac+"/1/1', '"+labIznosRn.Text+"'," +
                " '"+labPdvRn.Text+"', '"+lblUkRn.Text+"');";
            MySqlCommand bazazapovjed2 = new MySqlCommand(upit2, bazaspoj);
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed2.ExecuteReader();
                while (citaj.Read())
                {
                    
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            iznos = 0;
            pdv = 0;
            ukupno = 0;
        }

        private void btnDodajUslugu_Click(object sender, EventArgs e)
        {
            double ukupnoT = double.Parse(lblCijenaUsl.Text) * int.Parse(txtKolicina.Text);
            brojacStavke++;
            dataGridView1.Rows.Add(brojacStavke,cboxUsluge.Text,txtKolicina.Text,lblCijenaUsl.Text,ukupnoT);
            iznos = Math.Round(iznos + ukupnoT,2);
            pdv = Math.Round(iznos * 0.25,2);
            ukupno = Math.Round(iznos + pdv,2);
            labIznosRn.Text = iznos.ToString() + " KN";
            labPdvRn.Text = pdv.ToString() + " KN";
            lblUkRn.Text = ukupno.ToString() + " KN";
        }

        private void cboxKupci_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "select * from racuni.kupac WHERE naziv='" + cboxKupci.SelectedItem +"';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                if (citaj.Read())
                {
                    labOib.Text = citaj.GetString("oib");
                    labTelefon.Text = citaj.GetString("telefon");
                    labAdresa.Text = citaj.GetString("adresa");
                    txtSifraKupca.Text = citaj.GetString("id_kup");
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboxUsluge_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "SELECT * FROM racuni.usluga WHERE naziv='"+cboxUsluge.SelectedItem+"';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                if (citaj.Read())
                {
                    lblNazivUsl.Text = citaj.GetString("naziv");
                    lblIdUsl.Text = citaj.GetString("id_usl");
                    lblCijenaUsl.Text = citaj.GetString("cijena");
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboxUsluge_Leave(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "SELECT * FROM racuni.usluga WHERE id_usl='" + lblIdUsl.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                if (citaj.Read())
                {
                    lblNazivUsl.Text = citaj.GetString("naziv");
                    lblIdUsl.Text = citaj.GetString("id_usl");
                    lblCijenaUsl.Text = citaj.GetString("cijena");
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