using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibraryApp.Model;

namespace MovieLibraryApp.View
{
    public partial class Categorize : Form
    {
        private const int ImgWidth = 182;
        private const int ImgHeight = 112;

        private int pageNum;

        public Categorize()
        {
            InitializeComponent();

            pageNum = 0;

            btnLeft.Visible = false;

            InitGenreButtons();
        }

        private void InitGenreButtons()
        {

            if (pageNum == 0)
            {
                InitPage1();

                ShowAll();
            }
            else if (pageNum == 1)
            {
                InitPage2();

                ShowAll();

                btnC2.Visible = false;
                btnC3.Visible = false;
                btnC4.Visible = false;
            }
        }
        
        private void InitPage1()
        {
            Image actImg = Image.FromFile(Genre.ImgPath + "Action.jpg");
            btnA1.Image = Helpers.ResizeImage(actImg, ImgWidth, ImgHeight);
            btnA1.Text = "ACTION";

            Image advImg = Image.FromFile(Genre.ImgPath + "Adventure.jpg");
            btnA2.Image = Helpers.ResizeImage(advImg, ImgWidth, ImgHeight);
            btnA2.Text = "ADVENTURE";

            Image aniImg = Image.FromFile(Genre.ImgPath + "Animation.jpg");
            btnA3.Image = Helpers.ResizeImage(aniImg, ImgWidth, ImgHeight);
            btnA3.Text = "ANIMATION";

            Image bioImg = Image.FromFile(Genre.ImgPath + "Biography.jpg");
            btnA4.Image = Helpers.ResizeImage(bioImg, ImgWidth, ImgHeight);
            btnA4.Text = "BIOGRAPHY";

            Image comImg = Image.FromFile(Genre.ImgPath + "Comedy.jpg");
            btnB1.Image = Helpers.ResizeImage(comImg, ImgWidth, ImgHeight);
            btnB1.Text = "COMEDY";

            Image criImg = Image.FromFile(Genre.ImgPath + "Crime.jpg");
            btnB2.Image = Helpers.ResizeImage(criImg, ImgWidth, ImgHeight);
            btnB2.Text = "CRIME";

            Image draImg = Image.FromFile(Genre.ImgPath + "Drama.jpg");
            btnB3.Image = Helpers.ResizeImage(draImg, ImgWidth, ImgHeight);
            btnB3.Text = "DRAMA";

            Image famImg = Image.FromFile(Genre.ImgPath + "Family.jpg");
            btnB4.Image = Helpers.ResizeImage(famImg, ImgWidth, ImgHeight);
            btnB4.Text = "FAMILY";

            Image fanImg = Image.FromFile(Genre.ImgPath + "Fantasy.jpg");
            btnC1.Image = Helpers.ResizeImage(fanImg, ImgWidth, ImgHeight);
            btnC1.Text = "FANTASY";

            Image fnImg = Image.FromFile(Genre.ImgPath + "FilmNoir.jpg");
            btnC2.Image = Helpers.ResizeImage(fnImg, ImgWidth, ImgHeight);
            btnC2.Text = "FILM-NOIR";

            Image hisImg = Image.FromFile(Genre.ImgPath + "History.jpg");
            btnC3.Image = Helpers.ResizeImage(hisImg, ImgWidth, ImgHeight);
            btnC3.Text = "HISTORY";

            Image horImg = Image.FromFile(Genre.ImgPath + "Horror.jpg");
            btnC4.Image = Helpers.ResizeImage(horImg, ImgWidth, ImgHeight);
            btnC4.Text = "HORROR";
        }

        private void InitPage2()
        {
            Image musImg = Image.FromFile(Genre.ImgPath + "Music.jpg");
            btnA1.Image = Helpers.ResizeImage(musImg, ImgWidth, ImgHeight);
            btnA1.Text = "MUSIC";

            Image mslImg = Image.FromFile(Genre.ImgPath + "Musical.jpg");
            btnA2.Image = Helpers.ResizeImage(mslImg, ImgWidth, ImgHeight);
            btnA2.Text = "MUSICAL";

            Image mysImg = Image.FromFile(Genre.ImgPath + "Mystery.jpg");
            btnA3.Image = Helpers.ResizeImage(mysImg, ImgWidth, ImgHeight);
            btnA3.Text = "MYSTERY";

            Image romImg = Image.FromFile(Genre.ImgPath + "Romance.jpg");
            btnA4.Image = Helpers.ResizeImage(romImg, ImgWidth, ImgHeight);
            btnA4.Text = "ROMANCE";

            Image sfImg = Image.FromFile(Genre.ImgPath + "SciFi.jpg");
            btnB1.Image = Helpers.ResizeImage(sfImg, ImgWidth, ImgHeight);
            btnB1.Text = "SCI-FI";

            Image spoImg = Image.FromFile(Genre.ImgPath + "Sport.jpg");
            btnB2.Image = Helpers.ResizeImage(spoImg, ImgWidth, ImgHeight);
            btnB2.Text = "SPORT";

            Image thrImg = Image.FromFile(Genre.ImgPath + "Thriller.jpg");
            btnB3.Image = Helpers.ResizeImage(thrImg, ImgWidth, ImgHeight);
            btnB3.Text = "THRILLER";

            Image warImg = Image.FromFile(Genre.ImgPath + "War.jpg");
            btnB4.Image = Helpers.ResizeImage(warImg, ImgWidth, ImgHeight);
            btnB4.Text = "WAR";

            Image wesImg = Image.FromFile(Genre.ImgPath + "Western.jpg");
            btnC1.Image = Helpers.ResizeImage(wesImg, ImgWidth, ImgHeight);
            btnC1.Text = "WESTERN";
        }

        private void HideAll()
        {
            btnA1.Visible = false;
            btnA2.Visible = false;
            btnA3.Visible = false;
            btnA4.Visible = false;

            btnB1.Visible = false;
            btnB2.Visible = false;
            btnB3.Visible = false;
            btnB4.Visible = false;

            btnC1.Visible = false;
            btnC2.Visible = false;
            btnC3.Visible = false;
            btnC4.Visible = false;
        }

        private void ShowAll()
        {
            btnA1.Visible = true;
            btnA2.Visible = true;
            btnA3.Visible = true;
            btnA4.Visible = true;

            btnB1.Visible = true;
            btnB2.Visible = true;
            btnB3.Visible = true;
            btnB4.Visible = true;

            btnC1.Visible = true;
            btnC2.Visible = true;
            btnC3.Visible = true;
            btnC4.Visible = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (pageNum == 1)
            {
                pageNum--;

                btnLeft.Visible = false;
                btnRight.Visible = true;

                InitGenreButtons();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                pageNum++;

                btnLeft.Visible = true;
                btnRight.Visible = false;

                InitGenreButtons();
            }
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Action);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Music);
            }
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Adventure);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Musical);
            }
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Animation);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Mystery);
            }
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Biography);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Romance);
            }
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Comedy);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.SciFi);
            }
        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Crime);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Sport);
            }
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Drama);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Thriller);
            }
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Family);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.War);
            }
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Fantasy);
            }
            else if (pageNum == 1)
            {
                Program.CategoryToView(GenreType.Western);
            }
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.FilmNoir);
            }
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.History);
            }
        }

        private void btnC4_Click(object sender, EventArgs e)
        {
            if (pageNum == 0)
            {
                Program.CategoryToView(GenreType.Horror);
            }
        }

        private void Categorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CategoryToNav();
        }
    }
}
