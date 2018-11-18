namespace Racun
{
    partial class Glavni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavni));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kupciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racuniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uslugeToolStripMenuItem,
            this.kupciToolStripMenuItem,
            this.racuniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1246, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uslugeToolStripMenuItem
            // 
            this.uslugeToolStripMenuItem.Name = "uslugeToolStripMenuItem";
            this.uslugeToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.uslugeToolStripMenuItem.Text = "Usluge";
            this.uslugeToolStripMenuItem.Click += new System.EventHandler(this.uslugeToolStripMenuItem_Click);
            // 
            // kupciToolStripMenuItem
            // 
            this.kupciToolStripMenuItem.Name = "kupciToolStripMenuItem";
            this.kupciToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.kupciToolStripMenuItem.Text = "Kupci";
            this.kupciToolStripMenuItem.Click += new System.EventHandler(this.kupciToolStripMenuItem_Click);
            // 
            // racuniToolStripMenuItem
            // 
            this.racuniToolStripMenuItem.Name = "racuniToolStripMenuItem";
            this.racuniToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.racuniToolStripMenuItem.Text = "Računi";
            this.racuniToolStripMenuItem.Click += new System.EventHandler(this.racuniToolStripMenuItem_Click);
            // 
            // Glavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 805);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Glavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glavni";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uslugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kupciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racuniToolStripMenuItem;
    }
}