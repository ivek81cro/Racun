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
    public partial class Usluge : Form
    {
        public Usluge()
        {
            InitializeComponent();
            ucitajDatagridView();            
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

        //kod za direktnu izmjenu podataka u dgv ali dgv zakljucan iz razloga lake greske
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changes != null)
            {
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                mySqlDataAdapter.Update(changes);
                ((DataTable)dataGridView1.DataSource).AcceptChanges();

            }
        }
        void ucitajDatagridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
            connection = new MySqlConnection(connectionString);
            if (this.OpenConnection() == true)
            {
                string upit = "SELECT id_usl AS 'Šifra', naziv AS 'Naziv', cijena AS 'Cijena' FROM racuni.usluga;";
                mySqlDataAdapter = new MySqlDataAdapter(upit, connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                //close connection
                this.CloseConnection();
            }
            else { MessageBox.Show("Nije ostvaren spoj sa bazom."); }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (txtUsluga.Text != "" && txtCijena.Text != "")
            {
                txtCijena.Text = txtCijena.Text.Replace(",", ".");
                string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
                string upit = "INSERT INTO racuni.usluga (naziv, cijena) VALUES('" + txtUsluga.Text + "'," + txtCijena.Text + ");";
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
                    ucitajDatagridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke.");
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (txtUsluga.Text != "" && txtCijena.Text != "")
            {
                string constring = "datasource=localhost;port=3306;username=racuni;password=pass123;charset=utf8;";
                string upit = "DELETE FROM racuni.usluga WHERE id_usl='" + txtSifra.Text + "';";
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
                    ucitajDatagridView();
                    txtUsluga.Clear();
                    txtCijena.Clear();
                    txtSifra.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Odaberi uslugu za brisanje");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow red = this.dataGridView1.Rows[e.RowIndex];

                txtSifra.Text = red.Cells["Šifra"].Value.ToString();
                txtUsluga.Text = red.Cells["Naziv"].Value.ToString();
                txtCijena.Text = red.Cells["Cijena"].Value.ToString();
            }
        }
    }
}
