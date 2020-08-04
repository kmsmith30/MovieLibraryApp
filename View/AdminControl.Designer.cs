namespace MovieLibraryApp.View
{
    partial class AdminControl
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
            this.lblDirector = new System.Windows.Forms.Label();
            this.txtDirFirst = new System.Windows.Forms.TextBox();
            this.lblMovie = new System.Windows.Forms.Label();
            this.cbxMovies = new System.Windows.Forms.ComboBox();
            this.lblActor = new System.Windows.Forms.Label();
            this.txtActFirst = new System.Windows.Forms.TextBox();
            this.btnAddDirector = new System.Windows.Forms.Button();
            this.btnAddActor = new System.Windows.Forms.Button();
            this.lblImg = new System.Windows.Forms.Label();
            this.txtImg = new System.Windows.Forms.TextBox();
            this.txtActMiddle = new System.Windows.Forms.TextBox();
            this.txtDirMiddle = new System.Windows.Forms.TextBox();
            this.txtActLast = new System.Windows.Forms.TextBox();
            this.txtDirLast = new System.Windows.Forms.TextBox();
            this.txtChar = new System.Windows.Forms.TextBox();
            this.lblChar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDirector.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblDirector.Location = new System.Drawing.Point(49, 28);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(89, 24);
            this.lblDirector.TabIndex = 0;
            this.lblDirector.Text = "Director:";
            // 
            // txtDirFirst
            // 
            this.txtDirFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtDirFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDirFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtDirFirst.Location = new System.Drawing.Point(177, 25);
            this.txtDirFirst.Name = "txtDirFirst";
            this.txtDirFirst.Size = new System.Drawing.Size(150, 29);
            this.txtDirFirst.TabIndex = 1;
            this.txtDirFirst.Text = "First";
            this.txtDirFirst.TextChanged += new System.EventHandler(this.txtDirFirst_TextChanged);
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblMovie.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblMovie.Location = new System.Drawing.Point(72, 156);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(72, 24);
            this.lblMovie.TabIndex = 2;
            this.lblMovie.Text = "Movie:";
            // 
            // cbxMovies
            // 
            this.cbxMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.cbxMovies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbxMovies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.cbxMovies.FormattingEnabled = true;
            this.cbxMovies.Location = new System.Drawing.Point(177, 153);
            this.cbxMovies.Name = "cbxMovies";
            this.cbxMovies.Size = new System.Drawing.Size(570, 32);
            this.cbxMovies.TabIndex = 7;
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblActor.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblActor.Location = new System.Drawing.Point(73, 93);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(65, 24);
            this.lblActor.TabIndex = 4;
            this.lblActor.Text = "Actor:";
            // 
            // txtActFirst
            // 
            this.txtActFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtActFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtActFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtActFirst.Location = new System.Drawing.Point(177, 88);
            this.txtActFirst.Name = "txtActFirst";
            this.txtActFirst.Size = new System.Drawing.Size(150, 29);
            this.txtActFirst.TabIndex = 4;
            this.txtActFirst.Text = "First";
            this.txtActFirst.TextChanged += new System.EventHandler(this.txtActFirst_TextChanged);
            // 
            // btnAddDirector
            // 
            this.btnAddDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnAddDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAddDirector.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnAddDirector.Location = new System.Drawing.Point(187, 380);
            this.btnAddDirector.Name = "btnAddDirector";
            this.btnAddDirector.Size = new System.Drawing.Size(140, 30);
            this.btnAddDirector.TabIndex = 10;
            this.btnAddDirector.Text = "Add Director";
            this.btnAddDirector.UseVisualStyleBackColor = false;
            this.btnAddDirector.Click += new System.EventHandler(this.btnAddDirector_Click);
            // 
            // btnAddActor
            // 
            this.btnAddActor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnAddActor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAddActor.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnAddActor.Location = new System.Drawing.Point(438, 380);
            this.btnAddActor.Name = "btnAddActor";
            this.btnAddActor.Size = new System.Drawing.Size(135, 30);
            this.btnAddActor.TabIndex = 11;
            this.btnAddActor.Text = "Add Actor";
            this.btnAddActor.UseVisualStyleBackColor = false;
            this.btnAddActor.Click += new System.EventHandler(this.btnAddActor_Click);
            // 
            // lblImg
            // 
            this.lblImg.AutoSize = true;
            this.lblImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblImg.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblImg.Location = new System.Drawing.Point(30, 220);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(114, 24);
            this.lblImg.TabIndex = 8;
            this.lblImg.Text = "Image File:";
            // 
            // txtImg
            // 
            this.txtImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtImg.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtImg.Location = new System.Drawing.Point(177, 217);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(570, 29);
            this.txtImg.TabIndex = 8;
            // 
            // txtActMiddle
            // 
            this.txtActMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtActMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtActMiddle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtActMiddle.Location = new System.Drawing.Point(389, 88);
            this.txtActMiddle.Name = "txtActMiddle";
            this.txtActMiddle.Size = new System.Drawing.Size(150, 29);
            this.txtActMiddle.TabIndex = 5;
            this.txtActMiddle.Text = "Middle";
            this.txtActMiddle.TextChanged += new System.EventHandler(this.txtActMiddle_TextChanged);
            // 
            // txtDirMiddle
            // 
            this.txtDirMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtDirMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDirMiddle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtDirMiddle.Location = new System.Drawing.Point(389, 25);
            this.txtDirMiddle.Name = "txtDirMiddle";
            this.txtDirMiddle.Size = new System.Drawing.Size(150, 29);
            this.txtDirMiddle.TabIndex = 2;
            this.txtDirMiddle.Text = "Middle";
            this.txtDirMiddle.TextChanged += new System.EventHandler(this.txtDirMiddle_TextChanged);
            // 
            // txtActLast
            // 
            this.txtActLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtActLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtActLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtActLast.Location = new System.Drawing.Point(597, 88);
            this.txtActLast.Name = "txtActLast";
            this.txtActLast.Size = new System.Drawing.Size(150, 29);
            this.txtActLast.TabIndex = 6;
            this.txtActLast.Text = "Last";
            this.txtActLast.TextChanged += new System.EventHandler(this.txtActLast_TextChanged);
            // 
            // txtDirLast
            // 
            this.txtDirLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtDirLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDirLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtDirLast.Location = new System.Drawing.Point(597, 25);
            this.txtDirLast.Name = "txtDirLast";
            this.txtDirLast.Size = new System.Drawing.Size(150, 29);
            this.txtDirLast.TabIndex = 3;
            this.txtDirLast.Text = "Last";
            this.txtDirLast.TextChanged += new System.EventHandler(this.txtDirLast_TextChanged);
            // 
            // txtChar
            // 
            this.txtChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtChar.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtChar.Location = new System.Drawing.Point(177, 279);
            this.txtChar.Name = "txtChar";
            this.txtChar.Size = new System.Drawing.Size(570, 29);
            this.txtChar.TabIndex = 9;
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblChar.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblChar.Location = new System.Drawing.Point(4, 282);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(167, 24);
            this.lblChar.TabIndex = 15;
            this.lblChar.Text = "Character Name:";
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtChar);
            this.Controls.Add(this.lblChar);
            this.Controls.Add(this.txtActLast);
            this.Controls.Add(this.txtDirLast);
            this.Controls.Add(this.txtActMiddle);
            this.Controls.Add(this.txtDirMiddle);
            this.Controls.Add(this.txtImg);
            this.Controls.Add(this.lblImg);
            this.Controls.Add(this.btnAddActor);
            this.Controls.Add(this.btnAddDirector);
            this.Controls.Add(this.txtActFirst);
            this.Controls.Add(this.lblActor);
            this.Controls.Add(this.cbxMovies);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.txtDirFirst);
            this.Controls.Add(this.lblDirector);
            this.Name = "AdminControl";
            this.Text = "Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminControl_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox txtDirFirst;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ComboBox cbxMovies;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.TextBox txtActFirst;
        private System.Windows.Forms.Button btnAddDirector;
        private System.Windows.Forms.Button btnAddActor;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.TextBox txtImg;
        private System.Windows.Forms.TextBox txtActMiddle;
        private System.Windows.Forms.TextBox txtDirMiddle;
        private System.Windows.Forms.TextBox txtActLast;
        private System.Windows.Forms.TextBox txtDirLast;
        private System.Windows.Forms.TextBox txtChar;
        private System.Windows.Forms.Label lblChar;
    }
}