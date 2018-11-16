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
            ucitajBrojracuna();
            //inicijalizacija naziva stupaca u dgv
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Redni br.";
            dataGridView1.Columns[1].Name = "Naziv";
            dataGridView1.Columns[2].Name = "Količina";
            dataGridView1.Columns[3].Name = "Cijena";
            dataGridView1.Columns[4].Name = "Iznos";
            dataGridView1.Columns[5].Name = "Šifra usluge";

        }
        //Popuna comboboxa usluga
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
        //Popuna comboboxa kupaca
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
        int brRac = 0;//spremanje zadnjeg id-a racuna (broj)
        void ucitajBrojracuna()
        {
            
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
                    brRac = 1 + int.Parse(citaj.GetString("id_racun"));//iduci br=id +1                 
                }
                bazaspoj.Close();
                if (brRac == 0) { brRac++; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtBrRacuna.Text = brRac.ToString() + "/1/1";
        }

        int brojacStavke=0;
        double iznos=0;
        double pdv=0;
        double ukupno=0;

        private void btnZakljuci_Click(object sender, EventArgs e)
        {
            //Unos stavaka sa dgv u bazu
            if (cboxKupci.Text != "")
            {
                try
                {
                    string config = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
                    MySqlConnection con = new MySqlConnection(config);
                    string query = "INSERT INTO racuni.stavke(id_racun, id_kupac, id_usluge, kolicina, cijena, iznos)" +
                        "VALUES (@id_racun, @id_kupac, @id_usluge, @kolicina, @cijena, @iznos);";

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
                        cmd.Parameters.AddWithValue(
                            "@id_usluge", double.Parse(dataGridView1.Rows[row].Cells[5].Value.ToString()));

                        cmd.ExecuteNonQuery();

                    }
                    MessageBox.Show("Zaključeno");
                    //reset za novi racun
                    brojacStavke = 0;
                    con.Close();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    txtKolicina.Clear();
                    cboxKupci.ResetText();
                    cboxUsluge.ResetText();
                }
                catch (MySqlException er)
                {
                    MessageBox.Show("Error:" + er.ToString());
                }


                //unos računa u bazu
                string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
                string upit = "INSERT INTO racuni.racun (broj, iznos, pdv, ukupno) VALUES ('" + brRac + "/1/1', '" + labIznosRn.Text + "'," +
                    " '" + labPdvRn.Text + "', '" + lblUkRn.Text + "');";
                MySqlConnection bazaspoj = new MySqlConnection(constring);
                MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                MySqlDataReader citaj;
                try
                {
                    bazaspoj.Open();
                    citaj = bazazapovjed.ExecuteReader();
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
                ucitajBrojracuna();
                lblUkRn.Text = "";
                labIznosRn.Text = "";
                labPdvRn.Text = "";
                labAdresa.Text = "";
                labOib.Text = "";
                labTelefon.Text = "";
            }
            else
            {
                MessageBox.Show("Odaberi kupca.");
            }
        }
        //Dodaj uslugu u tablicu datagridv. i zbrajaj iznose
        private void btnDodajUslugu_Click(object sender, EventArgs e)
        {
            if (txtKolicina.Text != "" && cboxUsluge.Text!="")
            {
                double ukupnoT = double.Parse(lblCijenaUsl.Text) * int.Parse(txtKolicina.Text);
                brojacStavke++;
                dataGridView1.Rows.Add(brojacStavke, cboxUsluge.Text, txtKolicina.Text, lblCijenaUsl.Text, ukupnoT, lblIdUsl.Text);
                iznos = Math.Round(iznos + ukupnoT, 2);
                pdv = Math.Round(iznos * 0.25, 2);
                ukupno = Math.Round(iznos + pdv, 2);
                labIznosRn.Text = iznos.ToString() + " KN";
                labPdvRn.Text = pdv.ToString() + " KN";
                lblUkRn.Text = ukupno.ToString() + " KN";
            }
            else
            {
                MessageBox.Show("Odaberi uslugu i unesi količinu.");
            }
        }
        //Selekcija kupca, postavljanje parametara za bazu
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
        //Odabir usluge i postavljanje parametara za bazu
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Racuni_Load(object sender, EventArgs e)
        {

        }
    }
    
}
