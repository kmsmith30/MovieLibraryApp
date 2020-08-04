using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibraryApp.Model;

namespace MovieLibraryApp
{
    public partial class AddMovie : Form
    {
        // AddMovie Form Constructor
        public AddMovie()
        {
            InitializeComponent();

            InitYearList();
            InitRatingList();
            InitFormatList();
        }

        // Initialize Year Drop-Down List
        private void InitYearList()
        {
            cbxYearList.Items.Clear();

            int currYear = DateTime.Now.Year;

            const int dt = 200; // years

            for (int i = 0; i < dt; i++)
            {
                cbxYearList.Items.Add(currYear - i);
            }
        }

        // Initialize Rating Drop-Down List
        private void InitRatingList()
        {
            cbxRatingList.Items.Clear();

            foreach (Movie.RatingType rate in Enum.GetValues(typeof(Movie.RatingType)))
            {
                string val = rate.ToString();

                if (val != "Null")
                {
                    if (val == "NotRated")
                    {
                        val = "Not Rated";
                    }
                    else if (val == "PG13")
                    {
                        val = "PG-13";
                    }

                    cbxRatingList.Items.Add(val);
                }
            }
        }

        // Initialize Format Drop-Down List
        private void InitFormatList()
        {
            cbxFormatList.Items.Clear();

            foreach (Movie.FormatType fmt in Enum.GetValues(typeof(Movie.FormatType)))
            {
                cbxFormatList.Items.Add(fmt.ToString());
            }
        }

        // Counts all Genre Check Boxes for at least one checked
        private int GetGenreCount()
        {
            int total = 0;

            total += Convert.ToInt32(chbxAction.Checked);
            total += Convert.ToInt32(chbxAdventure.Checked);
            total += Convert.ToInt32(chbxAnimation.Checked);
            total += Convert.ToInt32(chbxBiography.Checked);
            total += Convert.ToInt32(chbxComedy.Checked);
            total += Convert.ToInt32(chbxCrime.Checked);
            total += Convert.ToInt32(chbxDrama.Checked);
            total += Convert.ToInt32(chbxFamily.Checked);
            total += Convert.ToInt32(chbxFantasy.Checked);
            total += Convert.ToInt32(chbxFilmNoir.Checked);
            total += Convert.ToInt32(chbxHistory.Checked);
            total += Convert.ToInt32(chbxHorror.Checked);
            total += Convert.ToInt32(chbxMusic.Checked);
            total += Convert.ToInt32(chbxMusical.Checked);
            total += Convert.ToInt32(chbxMystery.Checked);
            total += Convert.ToInt32(chbxRomance.Checked);
            total += Convert.ToInt32(chbxSciFi.Checked);
            total += Convert.ToInt32(chbxSport.Checked);
            total += Convert.ToInt32(chbxThriller.Checked);
            total += Convert.ToInt32(chbxWar.Checked);
            total += Convert.ToInt32(chbxWestern.Checked);

            return total;
        }

        private List<GenreType> CheckAction(List<GenreType> genres)
        {
            if (chbxAction.Checked)
            {
                genres.Add(GenreType.Action);
            }

            return genres;
        }

        private List<GenreType> CheckAdventure(List<GenreType> genres)
        {
            if (chbxAdventure.Checked)
            {
                genres.Add(GenreType.Adventure);
            }

            return genres;
        }

        private List<GenreType> CheckAnimation(List<GenreType> genres)
        {
            if (chbxAnimation.Checked)
            {
                genres.Add(GenreType.Animation);
            }

            return genres;
        }

        private List<GenreType> CheckBiography(List<GenreType> genres)
        {
            if (chbxBiography.Checked)
            {
                genres.Add(GenreType.Biography);
            }

            return genres;
        }

        private List<GenreType> CheckComedy(List<GenreType> genres)
        {
            if (chbxComedy.Checked)
            {
                genres.Add(GenreType.Comedy);
            }

            return genres;
        }

        private List<GenreType> CheckCrime(List<GenreType> genres)
        {
            if (chbxCrime.Checked)
            {
                genres.Add(GenreType.Crime);
            }

            return genres;
        }

        private List<GenreType> CheckDrama(List<GenreType> genres)
        {
            if (chbxDrama.Checked)
            {
                genres.Add(GenreType.Drama);
            }

            return genres;
        }

        private List<GenreType> CheckFamily(List<GenreType> genres)
        {
            if (chbxFamily.Checked)
            {
                genres.Add(GenreType.Family);
            }

            return genres;
        }

        private List<GenreType> CheckFantasy(List<GenreType> genres)
        {
            if (chbxFantasy.Checked)
            {
                genres.Add(GenreType.Fantasy);
            }

            return genres;
        }

        private List<GenreType> CheckFilmNoir(List<GenreType> genres)
        {
            if (chbxFilmNoir.Checked)
            {
                genres.Add(GenreType.FilmNoir);
            }

            return genres;
        }

        private List<GenreType> CheckHistory(List<GenreType> genres)
        {
            if (chbxHistory.Checked)
            {
                genres.Add(GenreType.History);
            }

            return genres;
        }

        private List<GenreType> CheckHorror(List<GenreType> genres)
        {
            if (chbxHorror.Checked)
            {
                genres.Add(GenreType.Horror);
            }

            return genres;
        }

        private List<GenreType> CheckMusic(List<GenreType> genres)
        {
            if (chbxMusic.Checked)
            {
                genres.Add(GenreType.Music);
            }

            return genres;
        }

        private List<GenreType> CheckMusical(List<GenreType> genres)
        {
            if (chbxMusical.Checked)
            {
                genres.Add(GenreType.Musical);
            }

            return genres;
        }

        private List<GenreType> CheckMystery(List<GenreType> genres)
        {
            if (chbxMystery.Checked)
            {
                genres.Add(GenreType.Mystery);
            }

            return genres;
        }

        private List<GenreType> CheckRomance(List<GenreType> genres)
        {
            if (chbxRomance.Checked)
            {
                genres.Add(GenreType.Romance);
            }

            return genres;
        }

        private List<GenreType> CheckSciFi(List<GenreType> genres)
        {
            if (chbxSciFi.Checked)
            {
                genres.Add(GenreType.SciFi);
            }

            return genres;
        }

        private List<GenreType> CheckSport(List<GenreType> genres)
        {
            if (chbxSport.Checked)
            {
                genres.Add(GenreType.Sport);
            }

            return genres;
        }

        private List<GenreType> CheckThriller(List<GenreType> genres)
        {
            if (chbxThriller.Checked)
            {
                genres.Add(GenreType.Thriller);
            }

            return genres;
        }

        private List<GenreType> CheckWar(List<GenreType> genres)
        {
            if (chbxWar.Checked)
            {
                genres.Add(GenreType.War);
            }

            return genres;
        }

        private List<GenreType> CheckWestern(List<GenreType> genres)
        {
            if (chbxWestern.Checked)
            {
                genres.Add(GenreType.Western);
            }

            return genres;
        }

        private List<GenreType> GetGenres()
        {
            List<GenreType> genres = new List<GenreType>();

            CheckAction(genres);
            CheckAdventure(genres);
            CheckAnimation(genres);
            CheckBiography(genres);
            CheckComedy(genres);
            CheckCrime(genres);
            CheckDrama(genres);
            CheckFamily(genres);
            CheckFantasy(genres);
            CheckFilmNoir(genres);
            CheckHistory(genres);
            CheckHorror(genres);
            CheckMusic(genres);
            CheckMusical(genres);
            CheckMystery(genres);
            CheckRomance(genres);
            CheckSciFi(genres);
            CheckSport(genres);
            CheckThriller(genres);
            CheckWar(genres);
            CheckWestern(genres);

            return genres;
        }

        private bool AddMovieGenres(Movie movie)
        {
            bool result = true;

            List<GenreType> genres = GetGenres();

            foreach (GenreType gtype in genres)
            { 
                Genre g = new Genre(gtype, movie.MovieId);

                result &= Genre.Insert(g);
            }

            return result;
        }

        private List<string> GetDirectors(string dirStr)
        {
            List<string> dirList = new List<string>();

            if (dirStr.Contains(','))
            {
                string[] dirs = dirStr.Split(',');

                foreach (string str in dirs)
                {
                    dirList.Add(str);
                }
            }
            else
            {
                dirList.Add(dirStr);
            }

            return dirList;
        }

        private void ClearForm()
        {
            txtTitle.Text = "";
            cbxYearList.SelectedItem = null;
            numRunTime.Value = 0;
            cbxRatingList.SelectedItem = null;
        }

        // Check if Form data is valid for inserting into db
        private bool IsDataValid()
        {
            // Check Title is not empty
            if (txtTitle.Text == null || txtTitle.Text == "")
            {
                MessageBox.Show("Title cannot be empty");

                return false;
            }

            // Check Year is not in future
            if ((int)cbxYearList.SelectedItem > DateTime.Now.Year)
            {
                MessageBox.Show($"Year cannot be later than current year ({DateTime.Now.Year})");

                return false;
            }

            // Check Run Time is positive and not absurd (under ~16 hours)
            if (numRunTime.Value < 0 || numRunTime.Value > 1000)
            {
                MessageBox.Show("Run time must be greater than 0 and less than 1000");

                return false;
            }

            // Check Director is not empty
            if (txtDirector.Text == null || txtDirector.Text == "")
            {
                MessageBox.Show("Director cannot be empty");

                return false;
            }

            // Check if at least one Genre is checked
            if (GetGenreCount() < 1)
            {
                MessageBox.Show("At least one Genre should be checked");

                return false;
            }

            // Check Description is not empty
            if (txtDescription.Text == null || txtDescription.Text == "")
            {
                MessageBox.Show("Description cannot be empty");

                return false;
            }

            // Check Image File is not empty
            if (txtImageFile.Text == null || txtImageFile.Text == "")
            {
                MessageBox.Show("Description cannot be empty");

                return false;
            }

            return true; // Data is valid
        }

        // "Add" Click Handler
        private void BtnComplete_Click(object sender, EventArgs e)
        {
            // Check Form data is valid
            if (IsDataValid())
            {
                // Get User data
                string titleStr = txtTitle.Text;
                int yearInt = (int)cbxYearList.SelectedItem;
                int runInt = (int)numRunTime.Value;
                Movie.RatingType rate = Movie.StrToRating(cbxRatingList.SelectedItem.ToString());

                string dirStr = txtDirector.Text;
                List<string> dirs = GetDirectors(dirStr);

                string fmtStr = cbxFormatList.SelectedItem.ToString();
                Enum.TryParse(fmtStr, out Movie.FormatType fmt);

                string desc = txtDescription.Text;
                string img = txtImageFile.Text;

                // Add Movie to Database
                Movie movie = new Movie(titleStr, yearInt, runInt, rate, fmt, desc, img);
                bool success = Movie.Insert(movie);

                if (!success)
                {
                    MessageBox.Show("Error adding Movie into Database");
                }

                // Add Genres
                success = AddMovieGenres(movie);

                if (success)
                {
                    MessageBox.Show("\"" + titleStr + "\" added successfully!", "Success");

                    ClearForm();

                    Program.AddToNav();
                }
                else
                {
                    MessageBox.Show("Error adding Movie Genres into Database");
                }
            }
        }

        // "Cancel" Click Handler
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form Closing Handler
        private void AddMovie_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to cancel?", 
                "Cancel Adding Movie", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                Program.AddToNav();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}