using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImagesServer_v3._0
{
    public partial class AdminUser : Form
    {
        public AdminUser()
        {
            InitializeComponent();
            RoundObjects();
            txtPassword.Focus();
        }


        void RoundObjects()
        {
            this.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15));
            panel1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 10, 10));
            txtPassword.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtPassword.Width, txtPassword.Height, 10, 10));
            btnPassword.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnPassword.Width, btnPassword.Height, 10, 10));
        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
          
            if (txtPassword.Text == "Admin2021" || txtPassword.Text == "2021")
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Abort;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnPassword_Click(sender, e);
            }
        }
    }
}
