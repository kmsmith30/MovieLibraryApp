using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibraryApp.Model;
using MovieLibraryApp.View;

namespace MovieLibraryApp
{

    public partial class ListAll : Form
    {
        private const int NumMovies = 8;

        private const int ImgWidth = 82;
        private const int ImgHeight = 120;

        private static Color PG = Color.PaleGreen;
        private static Color DWhite = Color.FromArgb(240, 244, 248);

        private int pageNum;
        private int movieNum;

        private int maxPage;

        private Movie movieA1;
        private Movie movieA2;
        private Movie movieA3;
        private Movie movieA4;
        private Movie movieB1;
        private Movie movieB2;
        private Movie movieB3;
        private Movie movieB4;

        public List<Movie> Movies { get; set; }

        public ListAll(GenreType genre)
        {
            InitializeComponent();

            ClearAllLetters();

            InitMovieList(genre);
            
            InitMovieScreen();
        }

        private void ResetMovies()
        {
            movieA1 = null;
            movieA2 = null;
            movieA3 = null;
            movieA4 = null;
            movieB1 = null;
            movieB2 = null;
            movieB3 = null;
            movieB4 = null;
        }

        private void SetPageValues()
        {
            pageNum = 0;
            movieNum = 0;

            maxPage = (int)(Movies.Count / NumMovies);

            if (Movies.Count > 0 && Movies.Count % NumMovies == 0)
            {
                maxPage--;
            }

            btnLeft.Visible = false;

            if (maxPage == 0)
            {
                btnRight.Visible = false;
            }
            else
            {
                btnRight.Visible = true;
            }
        }

        public void InitMovieList(GenreType genre)
        {
            ResetMovies();

            if (genre == GenreType.Null)
            {
                HighlightStar();

                Movies = Movie.LoadAll();
            }
            else
            {
                HideAllAlphaLabels();

                Movies = Movie.LoadByGenre(genre);
            }

            Movies = Movies.OrderBy(o => o.Title).ToList();

            if (genre == GenreType.Null)
            {
                this.Text = $"All Movies ({Movie.NumMovies})";
            }
            else if (genre == GenreType.FilmNoir)
            {
                this.Text = $"Film-Noir Movies ({Movies.Count})";
            }
            else if (genre == GenreType.SciFi)
            {
                this.Text = $"Sci-Fi Movies ({Movies.Count})";
            }
            else
            {
                this.Text = genre.ToString() + $" Movies ({Movies.Count})";
            }

            SetPageValues();
        }

        private void InitMovieList(char letter)
        {
            ResetMovies();

            if (letter != '*')
            {
                Movies = Movie.LoadByLetter(letter);

                this.Text = $"{letter} Movies ({Movies.Count})";
            }
            else
            {
                Movies = Movie.LoadAll();

                this.Text = $"All Movies ({Movies.Count})";
            }

            Movies = Movies.OrderBy(m => m.Title).ToList();


            SetPageValues();
        }

        private void HideAllAlphaLabels()
        {
            lblHashtag.Visible = false;
            lblA.Visible = false;
            lblB.Visible = false;
            lblC.Visible = false;
            lblD.Visible = false;
            lblE.Visible = false;
            lblF.Visible = false;
            lblG.Visible = false;
            lblH.Visible = false;
            lblI.Visible = false;
            lblJ.Visible = false;
            lblK.Visible = false;
            lblL.Visible = false;
            lblM.Visible = false;
            lblN.Visible = false;
            lblO.Visible = false;
            lblP.Visible = false;
            lblQ.Visible = false;
            lblR.Visible = false;
            lblS.Visible = false;
            lblT.Visible = false;
            lblU.Visible = false;
            lblV.Visible = false;
            lblW.Visible = false;
            lblX.Visible = false;
            lblY.Visible = false;
            lblZ.Visible = false;
            lblStar.Visible = false;
        }

        private void InitMovieScreen()
        {
            movieNum = 0;

            for (int i = pageNum * NumMovies; i < Movies.Count; i++)
            {
                SetMovie(Movies[i]);

                movieNum++;

                if (movieNum == NumMovies)
                {
                    break;
                }
            }

            while (movieNum < NumMovies)
            {
                SetMovie(null);

                movieNum++;
            }

            movieNum = 0;
        }

        private void SetMovie(Movie m)
        {
            switch (movieNum)
            {
                case 0:
                    if (m == null) HideA1();
                    else SetA1(m);
                    break;
                case 1:
                    if (m == null) HideA2();
                    else SetA2(m);
                    break;
                case 2:
                    if (m == null) HideA3();
                    else SetA3(m);
                    break;
                case 3:
                    if (m == null) HideA4();
                    else SetA4(m);
                    break;
                case 4:
                    if (m == null) HideB1();
                    else SetB1(m);
                    break;
                case 5:
                    if (m == null) HideB2();
                    else SetB2(m);
                    break;
                case 6:
                    if (m == null) HideB3();
                    else SetB3(m);
                    break;
                case 7:
                    if (m == null) HideB4();
                    else SetB4(m);
                    break;
                default:
                    break;
            }
        }

        private void HideAll()
        {
            HideRowA();
            HideRowB();
        }

        private void HideRowA()
        {
            HideA1();
            HideA2();
            HideA3();
            HideA4();
        }
        private void HideRowB()
        {
            HideB1();
            HideB2();
            HideB3();
            HideB4();
        }

        private void HideA1()
        {
            btnA1.Visible = false;
            lblA1.Visible = false;
        }
        private void HideA2()
        {
            btnA2.Visible = false;
            lblA2.Visible = false;
        }
        private void HideA3()
        {
            btnA3.Visible = false;
            lblA3.Visible = false;
        }
        private void HideA4()
        {
            btnA4.Visible = false;
            lblA4.Visible = false;
        }

        private void HideB1()
        {
            btnB1.Visible = false;
            lblB1.Visible = false;
        }
        private void HideB2()
        {
            btnB2.Visible = false;
            lblB2.Visible = false;
        }
        private void HideB3()
        {
            btnB3.Visible = false;
            lblB3.Visible = false;
        }
        private void HideB4()
        {
            btnB4.Visible = false;
            lblB4.Visible = false;
        }

        private void SetA1(Movie m)
        {
            movieA1 = m;

            if (movieA1.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieA1.ImageFile);
                btnA1.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnA1.Image = null;
            }

            lblA1.Text = movieA1.Title;

            btnA1.Visible = true;
            lblA1.Visible = true;
        }
        private void SetA2(Movie m)
        {
            movieA2 = m;

            if (movieA2.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieA2.ImageFile);
                btnA2.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnA2.Image = null;
            }

            lblA2.Text = movieA2.Title;

            btnA2.Visible = true;
            lblA2.Visible = true;
        }
        private void SetA3(Movie m)
        {
            movieA3 = m;

            if (movieA3.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieA3.ImageFile);
                btnA3.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnA3.Image = null;
            }

            lblA3.Text = movieA3.Title;

            btnA3.Visible = true;
            lblA3.Visible = true;
        }
        private void SetA4(Movie m)
        {
            movieA4 = m;

            if (movieA4.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieA4.ImageFile);
                btnA4.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnA4.Image = null;
            }

            lblA4.Text = movieA4.Title;

            btnA4.Visible = true;
            lblA4.Visible = true;
        }

        private void SetB1(Movie m)
        {
            movieB1 = m;

            if (movieB1.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieB1.ImageFile);
                btnB1.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnB1.Image = null;
            }

            lblB1.Text = movieB1.Title;

            btnB1.Visible = true;
            lblB1.Visible = true;
        }
        private void SetB2(Movie m)
        {
            movieB2 = m;

            if (movieB2.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieB2.ImageFile);
                btnB2.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnB2.Image = null;
            }

            lblB2.Text = movieB2.Title;

            btnB2.Visible = true;
            lblB2.Visible = true;
        }
        private void SetB3(Movie m)
        {
            movieB3 = m;

            if (movieB3.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieB3.ImageFile);
                btnB3.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnB3.Image = null;
            }

            lblB3.Text = movieB3.Title;

            btnB3.Visible = true;
            lblB3.Visible = true;
        }
        private void SetB4(Movie m)
        {
            movieB4 = m;

            if (movieB4.ImageFile != "")
            {
                Image movieImg = Image.FromFile(Movie.ImgPath + movieB4.ImageFile);
                btnB4.Image = Helpers.ResizeImage(movieImg, ImgWidth, ImgHeight);
            }
            else
            {
                btnB4.Image = null;
            }

            lblB4.Text = movieB4.Title;

            btnB4.Visible = true;
            lblB4.Visible = true;
        }

        private void ClearAllLetters()
        {
            lblHashtag.ForeColor = DWhite;
            lblA.ForeColor = DWhite;
            lblB.ForeColor = DWhite;
            lblC.ForeColor = DWhite;
            lblD.ForeColor = DWhite;
            lblE.ForeColor = DWhite;
            lblF.ForeColor = DWhite;
            lblG.ForeColor = DWhite;
            lblH.ForeColor = DWhite;
            lblI.ForeColor = DWhite;
            lblJ.ForeColor = DWhite;
            lblK.ForeColor = DWhite;
            lblL.ForeColor = DWhite;
            lblM.ForeColor = DWhite;
            lblN.ForeColor = DWhite;
            lblO.ForeColor = DWhite;
            lblP.ForeColor = DWhite;
            lblQ.ForeColor = DWhite;
            lblR.ForeColor = DWhite;
            lblS.ForeColor = DWhite;
            lblT.ForeColor = DWhite;
            lblU.ForeColor = DWhite;
            lblV.ForeColor = DWhite;
            lblW.ForeColor = DWhite;
            lblX.ForeColor = DWhite;
            lblY.ForeColor = DWhite;
            lblZ.ForeColor = DWhite;
            lblStar.ForeColor = DWhite;
        }

        private void HighlightHashtag()
        {
            lblHashtag.ForeColor = PG;
        }
        private void HighlightA()
        {
            lblA.ForeColor = PG;
        }
        private void HighlightB()
        {
            lblB.ForeColor = PG;
        }
        private void HighlightC()
        {
            lblC.ForeColor = PG;
        }
        private void HighlightD()
        {
            lblD.ForeColor = PG;
        }
        private void HighlightE()
        {
            lblE.ForeColor = PG;
        }
        private void HighlightF()
        {
            lblF.ForeColor = PG;
        }
        private void HighlightG()
        {
            lblG.ForeColor = PG;
        }
        private void HighlightH()
        {
            lblH.ForeColor = PG;
        }
        private void HighlightI()
        {
            lblI.ForeColor = PG;
        }
        private void HighlightJ()
        {
            lblJ.ForeColor = PG;
        }
        private void HighlightK()
        {
            lblK.ForeColor = PG;
        }
        private void HighlightL()
        {
            lblL.ForeColor = PG;
        }
        private void HighlightM()
        {
            lblM.ForeColor = PG;
        }
        private void HighlightN()
        {
            lblN.ForeColor = PG;
        }
        private void HighlightO()
        {
            lblO.ForeColor = PG;
        }
        private void HighlightP()
        {
            lblP.ForeColor = PG;
        }
        private void HighlightQ()
        {
            lblQ.ForeColor = PG;
        }
        private void HighlightR()
        {
            lblR.ForeColor = PG;
        }
        private void HighlightS()
        {
            lblS.ForeColor = PG;
        }
        private void HighlightT()
        {
            lblT.ForeColor = PG;
        }
        private void HighlightU()
        {
            lblU.ForeColor = PG;
        }
        private void HighlightV()
        {
            lblV.ForeColor = PG;
        }
        private void HighlightW()
        {
            lblW.ForeColor = PG;
        }
        private void HighlightX()
        {
            lblX.ForeColor = PG;
        }
        private void HighlightY()
        {
            lblY.ForeColor = PG;
        }
        private void HighlightZ()
        {
            lblZ.ForeColor = PG;
        }
        private void HighlightStar()
        {
            lblStar.ForeColor = PG;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Program.ViewToNav();

            this.Close();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            HideAll();

            btnRight.Visible = true;

            if (pageNum > 0)
            {
                pageNum--;

                if (pageNum == 0)
                {
                    btnLeft.Visible = false;
                }
            }

            InitMovieScreen();
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            HideAll();

            btnLeft.Visible = true;

            if (pageNum < maxPage)
            {
                pageNum++;

                if (pageNum == maxPage)
                {
                    btnRight.Visible = false;
                }
            }

            InitMovieScreen();
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieA1.MovieId);
        }
        private void btnA2_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieA2.MovieId);
        }
        private void btnA3_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieA3.MovieId);
        }
        private void btnA4_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieA4.MovieId);
        }
        private void btnB1_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieB1.MovieId);
        }
        private void btnB2_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieB2.MovieId);
        }
        private void btnB3_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieB3.MovieId);
        }
        private void btnB4_Click(object sender, EventArgs e)
        {
            Program.ViewToMovieDetail(movieB4.MovieId);
        }

        private void lblHashtag_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('#');

            InitMovieScreen();

            ClearAllLetters();

            HighlightHashtag();

        }
        private void lblA_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('A');

            InitMovieScreen();

            ClearAllLetters();

            HighlightA();
        }
        private void lblB_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('B');

            InitMovieScreen();

            ClearAllLetters();

            HighlightB();
        }
        private void lblC_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('C');

            InitMovieScreen();

            ClearAllLetters();

            HighlightC();
        }
        private void lblD_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('D');

            InitMovieScreen();

            ClearAllLetters();

            HighlightD();
        }
        private void lblE_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('E');

            InitMovieScreen();

            ClearAllLetters();

            HighlightE();
        }
        private void lblF_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('F');

            InitMovieScreen();

            ClearAllLetters();

            HighlightF();
        }
        private void lblG_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('G');

            InitMovieScreen();

            ClearAllLetters();

            HighlightG();
        }
        private void lblH_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('H');

            InitMovieScreen();

            ClearAllLetters();

            HighlightH();
        }
        private void lblI_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('I');

            InitMovieScreen();

            ClearAllLetters();

            HighlightI();
        }
        private void lblJ_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('J');

            InitMovieScreen();

            ClearAllLetters();

            HighlightJ();
        }
        private void lblK_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('K');

            InitMovieScreen();

            ClearAllLetters();

            HighlightK();
        }
        private void lblL_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('L');

            InitMovieScreen();

            ClearAllLetters();

            HighlightL();
        }
        private void lblM_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('M');

            InitMovieScreen();

            ClearAllLetters();

            HighlightM();
        }
        private void lblN_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('N');

            InitMovieScreen();

            ClearAllLetters();

            HighlightN();
        }
        private void lblO_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('O');

            InitMovieScreen();

            ClearAllLetters();

            HighlightO();
        }
        private void lblP_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('P');

            InitMovieScreen();

            ClearAllLetters();

            HighlightP();
        }
        private void lblQ_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('Q');

            InitMovieScreen();

            ClearAllLetters();

            HighlightQ();
        }
        private void lblR_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('R');

            InitMovieScreen();

            ClearAllLetters();

            HighlightR();
        }
        private void lblS_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('S');

            InitMovieScreen();

            ClearAllLetters();

            HighlightS();
        }
        private void lblT_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('T');

            InitMovieScreen();

            ClearAllLetters();

            HighlightT();
        }
        private void lblU_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('U');

            InitMovieScreen();

            ClearAllLetters();

            HighlightU();
        }
        private void lblV_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('V');

            InitMovieScreen();

            ClearAllLetters();

            HighlightV();
        }
        private void lblW_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('W');

            InitMovieScreen();

            ClearAllLetters();

            HighlightW();
        }
        private void lblX_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('X');

            InitMovieScreen();

            ClearAllLetters();

            HighlightX();
        }
        private void lblY_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('Y');

            InitMovieScreen();

            ClearAllLetters();

            HighlightY();
        }
        private void lblZ_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('Z');

            InitMovieScreen();

            ClearAllLetters();

            HighlightZ();
        }

        private void lblStar_Click(object sender, EventArgs e)
        {
            HideAll();

            InitMovieList('*');

            InitMovieScreen();

            ClearAllLetters();

            HighlightStar();
        }

        private void ListAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ViewToNav();
        }
    }
}
