using System.Windows.Forms;

namespace MovieLibraryApp
{
    partial class AddMovie
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
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbxYearList = new System.Windows.Forms.ComboBox();
            this.chbxAction = new System.Windows.Forms.CheckBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.chbxAdventure = new System.Windows.Forms.CheckBox();
            this.chbxAnimation = new System.Windows.Forms.CheckBox();
            this.chbxBiography = new System.Windows.Forms.CheckBox();
            this.chbxComedy = new System.Windows.Forms.CheckBox();
            this.chbxCrime = new System.Windows.Forms.CheckBox();
            this.chbxDrama = new System.Windows.Forms.CheckBox();
            this.chbxFamily = new System.Windows.Forms.CheckBox();
            this.chbxFantasy = new System.Windows.Forms.CheckBox();
            this.chbxFilmNoir = new System.Windows.Forms.CheckBox();
            this.chbxHistory = new System.Windows.Forms.CheckBox();
            this.chbxHorror = new System.Windows.Forms.CheckBox();
            this.chbxMusic = new System.Windows.Forms.CheckBox();
            this.chbxMystery = new System.Windows.Forms.CheckBox();
            this.chbxMusical = new System.Windows.Forms.CheckBox();
            this.chbxRomance = new System.Windows.Forms.CheckBox();
            this.chbxSciFi = new System.Windows.Forms.CheckBox();
            this.chbxSport = new System.Windows.Forms.CheckBox();
            this.chbxThriller = new System.Windows.Forms.CheckBox();
            this.chbxWar = new System.Windows.Forms.CheckBox();
            this.chbxWestern = new System.Windows.Forms.CheckBox();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.numRunTime = new System.Windows.Forms.NumericUpDown();
            this.lblDirector = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.cbxRatingList = new System.Windows.Forms.ComboBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.cbxFormatList = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblImgFile = new System.Windows.Forms.Label();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRunTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnComplete.Location = new System.Drawing.Point(104, 398);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(80, 30);
            this.btnComplete.TabIndex = 30;
            this.btnComplete.Text = "Add";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnCancel.Location = new System.Drawing.Point(604, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 30);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtTitle.Location = new System.Drawing.Point(192, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(483, 29);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(130, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 24);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblYear.Location = new System.Drawing.Point(81, 64);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(59, 24);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year:";
            // 
            // cbxYearList
            // 
            this.cbxYearList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.cbxYearList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYearList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYearList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbxYearList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.cbxYearList.FormattingEnabled = true;
            this.cbxYearList.Location = new System.Drawing.Point(146, 61);
            this.cbxYearList.Name = "cbxYearList";
            this.cbxYearList.Size = new System.Drawing.Size(122, 32);
            this.cbxYearList.TabIndex = 2;
            // 
            // chbxAction
            // 
            this.chbxAction.AutoSize = true;
            this.chbxAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxAction.Location = new System.Drawing.Point(134, 126);
            this.chbxAction.Name = "chbxAction";
            this.chbxAction.Size = new System.Drawing.Size(73, 24);
            this.chbxAction.TabIndex = 5;
            this.chbxAction.Text = "Action";
            this.chbxAction.UseVisualStyleBackColor = true;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblGenre.Location = new System.Drawing.Point(30, 126);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(98, 24);
            this.lblGenre.TabIndex = 8;
            this.lblGenre.Text = "Genre(s):";
            // 
            // chbxAdventure
            // 
            this.chbxAdventure.AutoSize = true;
            this.chbxAdventure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxAdventure.Location = new System.Drawing.Point(213, 126);
            this.chbxAdventure.Name = "chbxAdventure";
            this.chbxAdventure.Size = new System.Drawing.Size(101, 24);
            this.chbxAdventure.TabIndex = 6;
            this.chbxAdventure.Text = "Adventure";
            this.chbxAdventure.UseVisualStyleBackColor = true;
            // 
            // chbxAnimation
            // 
            this.chbxAnimation.AutoSize = true;
            this.chbxAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxAnimation.Location = new System.Drawing.Point(320, 126);
            this.chbxAnimation.Name = "chbxAnimation";
            this.chbxAnimation.Size = new System.Drawing.Size(99, 24);
            this.chbxAnimation.TabIndex = 7;
            this.chbxAnimation.Text = "Animation";
            this.chbxAnimation.UseVisualStyleBackColor = true;
            // 
            // chbxBiography
            // 
            this.chbxBiography.AutoSize = true;
            this.chbxBiography.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxBiography.Location = new System.Drawing.Point(425, 126);
            this.chbxBiography.Name = "chbxBiography";
            this.chbxBiography.Size = new System.Drawing.Size(99, 24);
            this.chbxBiography.TabIndex = 8;
            this.chbxBiography.Text = "Biography";
            this.chbxBiography.UseVisualStyleBackColor = true;
            // 
            // chbxComedy
            // 
            this.chbxComedy.AutoSize = true;
            this.chbxComedy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxComedy.Location = new System.Drawing.Point(526, 126);
            this.chbxComedy.Name = "chbxComedy";
            this.chbxComedy.Size = new System.Drawing.Size(86, 24);
            this.chbxComedy.TabIndex = 9;
            this.chbxComedy.Text = "Comedy";
            this.chbxComedy.UseVisualStyleBackColor = true;
            // 
            // chbxCrime
            // 
            this.chbxCrime.AutoSize = true;
            this.chbxCrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxCrime.Location = new System.Drawing.Point(618, 128);
            this.chbxCrime.Name = "chbxCrime";
            this.chbxCrime.Size = new System.Drawing.Size(69, 24);
            this.chbxCrime.TabIndex = 10;
            this.chbxCrime.Text = "Crime";
            this.chbxCrime.UseVisualStyleBackColor = true;
            // 
            // chbxDrama
            // 
            this.chbxDrama.AutoSize = true;
            this.chbxDrama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxDrama.Location = new System.Drawing.Point(693, 128);
            this.chbxDrama.Name = "chbxDrama";
            this.chbxDrama.Size = new System.Drawing.Size(76, 24);
            this.chbxDrama.TabIndex = 11;
            this.chbxDrama.Text = "Drama";
            this.chbxDrama.UseVisualStyleBackColor = true;
            // 
            // chbxFamily
            // 
            this.chbxFamily.AutoSize = true;
            this.chbxFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxFamily.Location = new System.Drawing.Point(134, 156);
            this.chbxFamily.Name = "chbxFamily";
            this.chbxFamily.Size = new System.Drawing.Size(73, 24);
            this.chbxFamily.TabIndex = 12;
            this.chbxFamily.Text = "Family";
            this.chbxFamily.UseVisualStyleBackColor = true;
            // 
            // chbxFantasy
            // 
            this.chbxFantasy.AutoSize = true;
            this.chbxFantasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxFantasy.Location = new System.Drawing.Point(213, 156);
            this.chbxFantasy.Name = "chbxFantasy";
            this.chbxFantasy.Size = new System.Drawing.Size(85, 24);
            this.chbxFantasy.TabIndex = 13;
            this.chbxFantasy.Text = "Fantasy";
            this.chbxFantasy.UseVisualStyleBackColor = true;
            // 
            // chbxFilmNoir
            // 
            this.chbxFilmNoir.AutoSize = true;
            this.chbxFilmNoir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxFilmNoir.Location = new System.Drawing.Point(304, 156);
            this.chbxFilmNoir.Name = "chbxFilmNoir";
            this.chbxFilmNoir.Size = new System.Drawing.Size(90, 24);
            this.chbxFilmNoir.TabIndex = 14;
            this.chbxFilmNoir.Text = "Film-Noir";
            this.chbxFilmNoir.UseVisualStyleBackColor = true;
            // 
            // chbxHistory
            // 
            this.chbxHistory.AutoSize = true;
            this.chbxHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxHistory.Location = new System.Drawing.Point(400, 156);
            this.chbxHistory.Name = "chbxHistory";
            this.chbxHistory.Size = new System.Drawing.Size(77, 24);
            this.chbxHistory.TabIndex = 15;
            this.chbxHistory.Text = "History";
            this.chbxHistory.UseVisualStyleBackColor = true;
            // 
            // chbxHorror
            // 
            this.chbxHorror.AutoSize = true;
            this.chbxHorror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxHorror.Location = new System.Drawing.Point(483, 156);
            this.chbxHorror.Name = "chbxHorror";
            this.chbxHorror.Size = new System.Drawing.Size(73, 24);
            this.chbxHorror.TabIndex = 16;
            this.chbxHorror.Text = "Horror";
            this.chbxHorror.UseVisualStyleBackColor = true;
            // 
            // chbxMusic
            // 
            this.chbxMusic.AutoSize = true;
            this.chbxMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxMusic.Location = new System.Drawing.Point(562, 156);
            this.chbxMusic.Name = "chbxMusic";
            this.chbxMusic.Size = new System.Drawing.Size(69, 24);
            this.chbxMusic.TabIndex = 17;
            this.chbxMusic.Text = "Music";
            this.chbxMusic.UseVisualStyleBackColor = true;
            // 
            // chbxMystery
            // 
            this.chbxMystery.AutoSize = true;
            this.chbxMystery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxMystery.Location = new System.Drawing.Point(134, 186);
            this.chbxMystery.Name = "chbxMystery";
            this.chbxMystery.Size = new System.Drawing.Size(82, 24);
            this.chbxMystery.TabIndex = 19;
            this.chbxMystery.Text = "Mystery";
            this.chbxMystery.UseVisualStyleBackColor = true;
            // 
            // chbxMusical
            // 
            this.chbxMusical.AutoSize = true;
            this.chbxMusical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxMusical.Location = new System.Drawing.Point(637, 156);
            this.chbxMusical.Name = "chbxMusical";
            this.chbxMusical.Size = new System.Drawing.Size(81, 24);
            this.chbxMusical.TabIndex = 18;
            this.chbxMusical.Text = "Musical";
            this.chbxMusical.UseVisualStyleBackColor = true;
            // 
            // chbxRomance
            // 
            this.chbxRomance.AutoSize = true;
            this.chbxRomance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxRomance.Location = new System.Drawing.Point(222, 186);
            this.chbxRomance.Name = "chbxRomance";
            this.chbxRomance.Size = new System.Drawing.Size(97, 24);
            this.chbxRomance.TabIndex = 20;
            this.chbxRomance.Text = "Romance";
            this.chbxRomance.UseVisualStyleBackColor = true;
            // 
            // chbxSciFi
            // 
            this.chbxSciFi.AutoSize = true;
            this.chbxSciFi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxSciFi.Location = new System.Drawing.Point(325, 186);
            this.chbxSciFi.Name = "chbxSciFi";
            this.chbxSciFi.Size = new System.Drawing.Size(68, 24);
            this.chbxSciFi.TabIndex = 21;
            this.chbxSciFi.Text = "Sci-Fi";
            this.chbxSciFi.UseVisualStyleBackColor = true;
            // 
            // chbxSport
            // 
            this.chbxSport.AutoSize = true;
            this.chbxSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxSport.Location = new System.Drawing.Point(399, 186);
            this.chbxSport.Name = "chbxSport";
            this.chbxSport.Size = new System.Drawing.Size(67, 24);
            this.chbxSport.TabIndex = 22;
            this.chbxSport.Text = "Sport";
            this.chbxSport.UseVisualStyleBackColor = true;
            // 
            // chbxThriller
            // 
            this.chbxThriller.AutoSize = true;
            this.chbxThriller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxThriller.Location = new System.Drawing.Point(472, 186);
            this.chbxThriller.Name = "chbxThriller";
            this.chbxThriller.Size = new System.Drawing.Size(74, 24);
            this.chbxThriller.TabIndex = 23;
            this.chbxThriller.Text = "Thriller";
            this.chbxThriller.UseVisualStyleBackColor = true;
            // 
            // chbxWar
            // 
            this.chbxWar.AutoSize = true;
            this.chbxWar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxWar.Location = new System.Drawing.Point(552, 186);
            this.chbxWar.Name = "chbxWar";
            this.chbxWar.Size = new System.Drawing.Size(57, 24);
            this.chbxWar.TabIndex = 24;
            this.chbxWar.Text = "War";
            this.chbxWar.UseVisualStyleBackColor = true;
            // 
            // chbxWestern
            // 
            this.chbxWestern.AutoSize = true;
            this.chbxWestern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chbxWestern.Location = new System.Drawing.Point(610, 186);
            this.chbxWestern.Name = "chbxWestern";
            this.chbxWestern.Size = new System.Drawing.Size(88, 24);
            this.chbxWestern.TabIndex = 25;
            this.chbxWestern.Text = "Western";
            this.chbxWestern.UseVisualStyleBackColor = true;
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblRunTime.Location = new System.Drawing.Point(285, 64);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(161, 24);
            this.lblRunTime.TabIndex = 29;
            this.lblRunTime.Text = "Run Time (min):";
            // 
            // numRunTime
            // 
            this.numRunTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.numRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numRunTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.numRunTime.Location = new System.Drawing.Point(452, 64);
            this.numRunTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRunTime.Name = "numRunTime";
            this.numRunTime.Size = new System.Drawing.Size(71, 29);
            this.numRunTime.TabIndex = 3;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDirector.Location = new System.Drawing.Point(40, 248);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(113, 24);
            this.lblDirector.TabIndex = 31;
            this.lblDirector.Text = "Director(s):";
            // 
            // txtDirector
            // 
            this.txtDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtDirector.Location = new System.Drawing.Point(159, 245);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(287, 29);
            this.txtDirector.TabIndex = 26;
            // 
            // cbxRatingList
            // 
            this.cbxRatingList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.cbxRatingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRatingList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxRatingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbxRatingList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.cbxRatingList.FormattingEnabled = true;
            this.cbxRatingList.Location = new System.Drawing.Point(622, 61);
            this.cbxRatingList.Name = "cbxRatingList";
            this.cbxRatingList.Size = new System.Drawing.Size(97, 32);
            this.cbxRatingList.TabIndex = 4;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblRating.Location = new System.Drawing.Point(541, 64);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(75, 24);
            this.lblRating.TabIndex = 34;
            this.lblRating.Text = "Rating:";
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormat.Location = new System.Drawing.Point(479, 248);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(81, 24);
            this.lblFormat.TabIndex = 35;
            this.lblFormat.Text = "Format:";
            // 
            // cbxFormatList
            // 
            this.cbxFormatList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.cbxFormatList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormatList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxFormatList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbxFormatList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.cbxFormatList.FormattingEnabled = true;
            this.cbxFormatList.Location = new System.Drawing.Point(566, 245);
            this.cbxFormatList.Name = "cbxFormatList";
            this.cbxFormatList.Size = new System.Drawing.Size(121, 32);
            this.cbxFormatList.TabIndex = 27;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(7, 298);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(121, 24);
            this.lblDescription.TabIndex = 37;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtDescription.Location = new System.Drawing.Point(134, 295);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(654, 29);
            this.txtDescription.TabIndex = 28;
            // 
            // lblImgFile
            // 
            this.lblImgFile.AutoSize = true;
            this.lblImgFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblImgFile.Location = new System.Drawing.Point(210, 349);
            this.lblImgFile.Name = "lblImgFile";
            this.lblImgFile.Size = new System.Drawing.Size(73, 24);
            this.lblImgFile.TabIndex = 39;
            this.lblImgFile.Text = "Image:";
            // 
            // txtImageFile
            // 
            this.txtImageFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.txtImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtImageFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtImageFile.Location = new System.Drawing.Point(289, 344);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.Size = new System.Drawing.Size(289, 29);
            this.txtImageFile.TabIndex = 29;
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtImageFile);
            this.Controls.Add(this.lblImgFile);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cbxFormatList);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.cbxRatingList);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.numRunTime);
            this.Controls.Add(this.lblRunTime);
            this.Controls.Add(this.chbxWestern);
            this.Controls.Add(this.chbxWar);
            this.Controls.Add(this.chbxThriller);
            this.Controls.Add(this.chbxSport);
            this.Controls.Add(this.chbxSciFi);
            this.Controls.Add(this.chbxRomance);
            this.Controls.Add(this.chbxMusical);
            this.Controls.Add(this.chbxMystery);
            this.Controls.Add(this.chbxMusic);
            this.Controls.Add(this.chbxHorror);
            this.Controls.Add(this.chbxHistory);
            this.Controls.Add(this.chbxFilmNoir);
            this.Controls.Add(this.chbxFantasy);
            this.Controls.Add(this.chbxFamily);
            this.Controls.Add(this.chbxDrama);
            this.Controls.Add(this.chbxCrime);
            this.Controls.Add(this.chbxComedy);
            this.Controls.Add(this.chbxBiography);
            this.Controls.Add(this.chbxAnimation);
            this.Controls.Add(this.chbxAdventure);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.chbxAction);
            this.Controls.Add(this.cbxYearList);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComplete);
            this.ForeColor = System.Drawing.Color.PaleGreen;
            this.Name = "AddMovie";
            this.Text = "Add Movie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddMovie_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numRunTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnComplete;
        private Button btnCancel;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblYear;
        private ComboBox cbxYearList;
        private Label lblGenre;
        private CheckBox chbxAction;
        private CheckBox chbxAdventure;
        private CheckBox chbxAnimation;
        private CheckBox chbxBiography;
        private CheckBox chbxComedy;
        private CheckBox chbxCrime;
        private CheckBox chbxDrama;
        private CheckBox chbxFamily;
        private CheckBox chbxFantasy;
        private CheckBox chbxFilmNoir;
        private CheckBox chbxHistory;
        private CheckBox chbxHorror;
        private CheckBox chbxMusic;
        private CheckBox chbxMystery;
        private CheckBox chbxMusical;
        private CheckBox chbxRomance;
        private CheckBox chbxSciFi;
        private CheckBox chbxSport;
        private CheckBox chbxThriller;
        private CheckBox chbxWar;
        private CheckBox chbxWestern;
        private Label lblRunTime;
        private NumericUpDown numRunTime;
        private Label lblDirector;
        private TextBox txtDirector;
        private ComboBox cbxRatingList;
        private Label lblRating;
        private Label lblFormat;
        private ComboBox cbxFormatList;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblImgFile;
        private TextBox txtImageFile;
    }
}