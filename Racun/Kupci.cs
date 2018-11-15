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
    public partial class Kupci : Form
    {
        public Kupci()
        {
            InitializeComponent();
            ucitajDatagridView();
            Resetirajpolja();
        }
        private MySqlConnection connection;
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }

            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private MySqlDataAdapter mySqlDataAdapter;
        void ucitajDatagridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            connection = new MySqlConnection(connectionString);
            if (this.OpenConnection() == true)
            {
                string upit = "SELECT id_kup AS 'Šifra', naziv AS 'Naziv', adresa AS 'Adresa', oib AS 'OIB', telefon AS 'Telefon' FROM racuni.kupac;";
                mySqlDataAdapter = new MySqlDataAdapter(upit, connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                //close connection
                this.CloseConnection();
            }
            else { MessageBox.Show("Nije ostvaren spoj sa bazom."); }
        }
        void Resetirajpolja()
        {
            ucitajDatagridView();
            txtAdresa.Clear();
            txtNaziv.Clear();
            txtOib.Clear();
            txtTelefon.Clear();
            txtSifra.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow red = this.dataGridView1.Rows[e.RowIndex];

                txtSifra.Text = red.Cells["Šifra"].Value.ToString();
                txtNaziv.Text = red.Cells["Naziv"].Value.ToString();
                txtAdresa.Text = red.Cells["Adresa"].Value.ToString();
                txtOib.Text = red.Cells["OIB"].Value.ToString();
                txtTelefon.Text = red.Cells["Telefon"].Value.ToString();
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "INSERT INTO racuni.kupac (naziv, adresa, oib, telefon) VALUES('" + txtNaziv.Text + 
                "','" + txtAdresa.Text + "', '"+ txtOib.Text +"','"+ txtTelefon.Text +"');";
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
                ucitajDatagridView();
                Resetirajpolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "DELETE FROM racuni.kupac WHERE id_kup='" + txtSifra.Text +"';";
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
                ucitajDatagridView();
                Resetirajpolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPromjeni_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            string upit = "UPDATE racuni.kupac SET naziv='" + txtNaziv.Text + "', adresa='" + txtAdresa.Text +
                "', oib='" + txtOib.Text +"', telefon='" + txtTelefon.Text + "' WHERE id_kup='" + txtSifra.Text + "';";
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
                ucitajDatagridView();
                Resetirajpolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
