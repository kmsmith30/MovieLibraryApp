using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibraryApp.Model;
//using LibVLCSharp.Shared;

namespace MovieLibraryApp.View
{

    public partial class Play : Form
    {
        public Movie Mov { get; private set; }

        private System.Windows.Forms.Timer idleTimer;

        private TimeSpan idleTimeout;

        private DateTime lastMouseMove;

        private bool isHidden;

        public Play()
        {
            wmpMovie = null;
        }

        public Play(int mid)
        {
            InitializeComponent();

            InitTimer();

            this.Enabled = true;

            wmpMovie.Focus();

            Mov = Movie.LoadById(mid);

            this.Text = Mov.Title + $" ({Mov.Year})";

            wmpMovie.URL = Movie.VidPath + Mov.VideoFile;
        }

        private void InitTimer()
        {
            idleTimeout = TimeSpan.FromSeconds(2);

            isHidden = false;

            idleTimer = new Timer();

            idleTimer.Tick += new EventHandler(IdleTick);

            idleTimer.Interval = 2000;

            idleTimer.Enabled = true;

            idleTimer.Start();
        }

        private void IdleTick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - lastMouseMove;

            if (elapsed >= idleTimeout && !isHidden)
            {
                Cursor.Hide();

                idleTimer.Stop();

                wmpMovie.uiMode = "none";

                isHidden = true;
            }
        }

        private void Play_MouseMove(object sender, MouseEventArgs e)
        {
            lastMouseMove = DateTime.Now;

            if (isHidden)
            {
                Cursor.Show();

                idleTimer.Start();

                wmpMovie.uiMode = "full";

                isHidden = false;
            }
        }

        private void Play_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();

            idleTimer.Stop();

            Program.PlayToMovieDetail(Mov.MovieId);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112)
            {
                if (m.WParam == new IntPtr(0xF030))
                {
                    wmpMovie.Size = new Size(1346, 830);
                    wmpMovie.stretchToFit = true;
                    //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                
                if (m.WParam == new IntPtr(0xF120))
                {
                    wmpMovie.Size = new Size(776, 426);
                    wmpMovie.stretchToFit = false;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                }
            }

            base.WndProc(ref m);
        }
    }
}
