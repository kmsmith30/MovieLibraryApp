namespace MovieLibraryApp.View
{
    partial class Play
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play));
            this.wmpMovie = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.wmpMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // wmpMovie
            // 
            this.wmpMovie.Enabled = true;
            this.wmpMovie.Location = new System.Drawing.Point(12, 12);
            this.wmpMovie.Name = "wmpMovie";
            this.wmpMovie.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpMovie.OcxState")));
            this.wmpMovie.Size = new System.Drawing.Size(776, 426);
            this.wmpMovie.TabIndex = 0;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wmpMovie);
            this.Name = "Play";
            this.Text = "Play";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Play_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Play_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.wmpMovie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpMovie;
    }
}