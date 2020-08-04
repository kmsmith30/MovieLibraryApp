using MovieLibraryApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovieLibraryApp
{
    public partial class Navigation : Form
    {
        // Navigation Form Constructor
        public Navigation()
        {
            InitializeComponent();

            /*
            Director.ResetId();
            Person.ResetId();
            Actor.ResetId();
            */
        }

        // "Admin" Click Handler
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Program.NavToControl();
        }

        // "View" Click Handler
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            Program.NavToView();
        }

        // "Search" Click Handler
        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            Program.NavToSearch();
        }

        // "Add" Click Handler
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            Program.NavToAdd();
        }

        // "Exit" Click Handler
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form Close Handler
        private void Navigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to exit the application?", "Exit?", MessageBoxButtons.YesNo);

            e.Cancel = (res == DialogResult.No);
        }
    }
}