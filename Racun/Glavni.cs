using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racun
{
    public partial class Glavni : Form
    {
        public Glavni()
        {
            InitializeComponent();
        }
        Usluge usluge;
        Kupci kupci;
        Racuni racuni;

        private void uslugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usluge == null)
            {
                usluge = new Usluge();
                usluge.FormClosed += grad_FormClosed;
                usluge.MdiParent = this;
                usluge.Show();
                usluge.WindowState = FormWindowState.Maximized;
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

        private void kupciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kupci == null)
            {
                kupci = new Kupci();
                kupci.FormClosed += kup_FormClosed;
                kupci.MdiParent = this;
                kupci.Show();
                kupci.WindowState = FormWindowState.Maximized;
            }
            else
            {
                kupci.Close();
                kupci = new Kupci();
                kupci.FormClosed += kup_FormClosed;
                kupci.Show();
            }
        }
        void kup_FormClosed(object sender, FormClosedEventArgs e)
        {
            kupci = null;
            //throw new NotImplementedException();
        }

        private void racuniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (racuni == null)
            {
                racuni = new Racuni();
                racuni.FormClosed += rac_FormClosed;
                racuni.MdiParent = this;
                racuni.Show();
                racuni.WindowState = FormWindowState.Maximized;
            }
            else
            {
                racuni.Close();
                racuni = new Racuni();
                racuni.FormClosed += rac_FormClosed;
                racuni.Show();
            }
        }
        void rac_FormClosed(object sender, FormClosedEventArgs e)
        {
            racuni = null;
            //throw new NotImplementedException();
        }
    }
}
