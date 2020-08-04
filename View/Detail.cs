using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibraryApp.Model;

namespace MovieLibraryApp.View
{
    public enum DetailType { Movie, Null, Person };

    public partial class Detail : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private const int MainImgW = 132;
        private const int MainImgH = 194;

        private const int SecondaryImgW = 88;
        private const int SecondaryImgH = 120;

        private const int NumSecondaries = 6;

        private DetailType type;

        private Movie movie;
        private Person person;

        private List<Director> directors;
        private List<Actor> actors;

        private List<Movie> moviesAct;
        private List<Movie> moviesDir;

        private List<Person> People { get; set; }

        private List<Movie> Movies { get; set; }

        private Person personA;
        private Person personB;
        private Person personC;
        private Person personD;
        private Person personE;
        private Person personF;

        private Movie movieA;
        private Movie movieB;
        private Movie movieC;
        private Movie movieD;
        private Movie movieE;
        private Movie movieF;

        private int pageNum;
        private int detailNum;

        private int maxPage;

        public Detail()
        {
            type = DetailType.Null;

            movie = null;

            directors = null;
            actors = null;

            detailNum = 0;

            pageNum = 0;
        }

        public Detail(int xid, DetailType dt) : base()
        {
            InitializeComponent();

            if (dt == DetailType.Movie)
            {
                type = DetailType.Movie;

                movie = Movie.LoadById(xid);
                person = null;

                if (movie.VideoFile != null && movie.VideoFile != "")
                {
                    btnPlay.Visible = true;
                }
                else
                {
                    btnPlay.Visible = false;
                }

                InitMovieDetails();

                ResetPeople();

                directors = Director.LoadByMovie(movie.MovieId);
                actors = Actor.LoadByMovie(movie.MovieId);

                InitPeopleList();

                SetPageValues();

                InitPeopleScreen();
            }
            else if (dt == DetailType.Person)
            {
                btnPlay.Visible = false;

                type = DetailType.Person;

                person = Person.LoadById(xid);
                movie = null;

                InitPersonDetails();

                ResetMovies();

                moviesAct = Actor.LoadMoviesByPersonId(xid);
                moviesDir = Director.LoadMoviesByPersonId(xid);

                InitMovieList();

                SetPageValues();

                InitMovieScreen();
            }
        }

        private void ResetPeople()
        {
            personA = null;
            personB = null;
            personC = null;
            personD = null;
            personE = null;
            personF = null;
        }

        private void ResetMovies()
        {
            movieA = null;
            movieB = null;
            movieC = null;
            movieD = null;
            movieE = null;
            movieF = null;
        }


        private void InitMovieDetails()
        {
            if (movie != null)
            {
                this.Text = movie.Title;

                lblTitle.Text = movie.Title + $" ({movie.Year})";

                lblSecondary.Text = $"{(int)movie.RunTime / 60}h {movie.RunTime % 60}min";

                SetGenres();

                if (movie.ImageFile != "")
                {
                    Image movieImg = Image.FromFile(Movie.ImgPath + movie.ImageFile);
                    pbxImage.Image = Helpers.ResizeImage(movieImg, MainImgW, MainImgH);
                }

                txtDescription.Text = movie.Description;
                txtDescription.Select(0, 0);

                lblLow.Visible = true;
                txtDescription.Visible = true;
            }
        }

        private void InitPersonDetails()
        {
            if (person != null)
            {
                this.Text = GetNameString(person);

                lblTitle.Text = GetNameString(person);

                lblSecondary.Visible = false;

                lblLow.Visible = false;

                if (person.ImageFile != "")
                {
                    Image personImg = Image.FromFile(Person.ImgPath + person.ImageFile);
                    pbxImage.Image = Helpers.ResizeImage(personImg, MainImgW, MainImgH);
                }

                txtDescription.Visible = false;
            }
        }

        private void InitPeopleList()
        {
            People = new List<Person>();

            foreach (Person dir in directors)
            {
                People.Add(dir);
            }

            foreach (Person act in actors)
            {
                People.Add(act);
            }
        }

        private void InitMovieList()
        {
            Movies = new List<Movie>();

            foreach (Movie mov in moviesDir)
            {
                Movies.Add(mov);
            }

            foreach (Movie mov in moviesAct)
            {
                Movies.Add(mov);
            }

            Movies = Movies.OrderBy(m => m.Year).ToList();
            Movies.Reverse();

        StartHere:

            for (int i = 0; i < Movies.Count; i++)
            {
                for (int j = 0; j < Movies.Count; j++)
                {
                    if (Movies[i].MovieId == Movies[j].MovieId && i != j)
                    {
                        Movies.RemoveAt(j);

                        goto StartHere;
                    }
                }
            }
        }

        private void SetPageValues()
        {
            pageNum = 0;
            detailNum = 0;

            int total = (type == DetailType.Movie) ?
                People.Count : Movies.Count;

            maxPage = (int)(total / NumSecondaries);

            if (total > 0 && total % NumSecondaries == 0)
            {
                maxPage--;
            }

            btnLeft.Visible = false;

            if (maxPage == 0)
            {
                btnRight.Visible = false;
            }
        }

        private void InitPeopleScreen()
        {
            detailNum = 0;

            for (int i = pageNum * NumSecondaries; i < People.Count; i++)
            {
                SetPerson(People[i]);

                detailNum++;

                if (detailNum == NumSecondaries)
                {
                    break;
                }
            }

            while (detailNum < NumSecondaries)
            {
                SetPerson(null);

                detailNum++;
            }

            detailNum = 0;
        }

        private void InitMovieScreen()
        {
            detailNum = 0;

            for (int i = pageNum * NumSecondaries; i < Movies.Count; i++)
            {
                SetMovie(Movies[i]);

                detailNum++;

                if (detailNum == NumSecondaries)
                {
                    break;
                }
            }

            while (detailNum < NumSecondaries)
            {
                SetMovie(null);

                detailNum++;
            }

            detailNum = 0;
        }


        private void SetMovie(Movie movie)
        {
            switch (detailNum)
            {
                case 0:
                    if (movie == null) HideA();
                    else SetMovieA(movie);
                    break;
                case 1:
                    if (movie == null) HideB();
                    else SetMovieB(movie);
                    break;
                case 2:
                    if (movie == null) HideC();
                    else SetMovieC(movie);
                    break;
                case 3:
                    if (movie == null) HideD();
                    else SetMovieD(movie);
                    break;
                case 4:
                    if (movie == null) HideE();
                    else SetMovieE(movie);
                    break;
                case 5:
                    if (movie == null) HideF();
                    else SetMovieF(movie);
                    break;
                default:
                    break;
            }
        }


        private void SetPerson(Person person)
        {
            switch (detailNum)
            {
                case 0:
                    if (person == null) HideA();
                    else SetPersonA(person);
                    break;
                case 1:
                    if (person == null) HideB();
                    else SetPersonB(person);
                    break;
                case 2:
                    if (person == null) HideC();
                    else SetPersonC(person);
                    break;
                case 3:
                    if (person == null) HideD();
                    else SetPersonD(person);
                    break;
                case 4:
                    if (person == null) HideE();
                    else SetPersonE(person);
                    break;
                case 5:
                    if (person == null) HideF();
                    else SetPersonF(person);
                    break;
                default:
                    break;
            }
        }


        private void HideAllSecondaries()
        {
            HideA();
            HideB();
            HideC();
            HideD();
            HideE();
            HideF();
        }

        private void HideA()
        {
            btnA.Visible = false;
            lblTitleA.Visible = false;
            lblNameA.Visible = false;
        }
        private void HideB()
        {
            btnB.Visible = false;
            lblTitleB.Visible = false;
            lblNameB.Visible = false;
        }
        private void HideC()
        {
            btnC.Visible = false;
            lblTitleC.Visible = false;
            lblNameC.Visible = false;
        }
        private void HideD()
        {
            btnD.Visible = false;
            lblTitleD.Visible = false;
            lblNameD.Visible = false;
        }
        private void HideE()
        {
            btnE.Visible = false;
            lblTitleE.Visible = false;
            lblNameE.Visible = false;
        }
        private void HideF()
        {
            btnF.Visible = false;
            lblTitleF.Visible = false;
            lblNameF.Visible = false;
        }

        private string GetNameString(Person p)
        {
            string name = p.FirstName;

            if (p.MiddleName != null && p.MiddleName != "")
            {
                name += ' ' + p.MiddleName;
            }

            if (p.LastName != null && p.LastName != "")
            {
                name += ' ' + p.LastName;
            }

            return name;
        }

        private void SetPersonA(Person p)
        {
            personA = p;

            if (personA.ImageFile != "" && personA.ImageFile != null)
            {
                Image aImg = Image.FromFile(Person.ImgPath + personA.ImageFile);
                btnA.Image = Helpers.ResizeImage(aImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameA.Text = GetNameString(p);

            if (p is Director)
            {
                lblTitleA.Text = "DIRECTOR";
            }
            else if (p is Actor)
            {
                Actor actor = (Actor)personA;

                lblTitleA.Text = actor.CharacterName;
            }

            btnA.Visible = true;
            lblTitleA.Visible = true;
            lblNameA.Visible = true;
        }
        private void SetPersonB(Person p)
        {
            personB = p;

            if (personB.ImageFile != "" && personB.ImageFile != null)
            {
                Image bImg = Image.FromFile(Person.ImgPath + personB.ImageFile);
                btnB.Image = Helpers.ResizeImage(bImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameB.Text = GetNameString(p);

            if (p is Director)
            {
                lblTitleB.Text = "DIRECTOR";
            }
            else if (p is Actor)
            {
                Actor actor = (Actor)personB;

                lblTitleB.Text = actor.CharacterName;
            }

            btnB.Visible = true;
            lblTitleB.Visible = true;
            lblNameB.Visible = true;
        }
        private void SetPersonC(Person p)
        {
            personC = p;

            if (personC.ImageFile != "" && personC.ImageFile != null)
            {
                Image cImg = Image.FromFile(Person.ImgPath + personC.ImageFile);
                btnC.Image = Helpers.ResizeImage(cImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameC.Text = GetNameString(p);

            if (p is Director)
            {
                lblTitleC.Text = "DIRECTOR";
            }
            else if (p is Actor)
            {
                Actor actor = (Actor)personC;

                lblTitleC.Text = actor.CharacterName;
            }

            btnC.Visible = true;
            lblTitleC.Visible = true;
            lblNameC.Visible = true;
        }
        private void SetPersonD(Person p)
        {
            personD = p;

            if (personD.ImageFile != "" && personD.ImageFile != null)
            {
                Image dImg = Image.FromFile(Person.ImgPath + personD.ImageFile);
                btnD.Image = Helpers.ResizeImage(dImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameD.Text = GetNameString(p);

            if (personD is Director)
            {
                lblTitleD.Text = "DIRECTOR";
            }
            else if (personD is Actor)
            {
                Actor actor = (Actor)personD;

                lblTitleD.Text = actor.CharacterName;
            }

            btnD.Visible = true;
            lblTitleD.Visible = true;
            lblNameD.Visible = true;
        }
        private void SetPersonE(Person p)
        {
            personE = p;

            if (personE.ImageFile != "" && personE.ImageFile != null)
            {
                Image eImg = Image.FromFile(Person.ImgPath + personE.ImageFile);
                btnE.Image = Helpers.ResizeImage(eImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameE.Text = GetNameString(p);

            if (p is Director)
            {
                lblTitleE.Text = "DIRECTOR";
            }
            else if (p is Actor)
            {
                Actor actor = (Actor)personE;

                lblTitleE.Text = actor.CharacterName;
            }

            btnE.Visible = true;
            lblTitleE.Visible = true;
            lblNameE.Visible = true;
        }
        private void SetPersonF(Person p)
        {
            personF = p;

            if (personF.ImageFile != "" && personF.ImageFile != null)
            {
                Image fImg = Image.FromFile(Person.ImgPath + personF.ImageFile);
                btnF.Image = Helpers.ResizeImage(fImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameF.Text = GetNameString(p);

            if (p is Director)
            {
                lblTitleF.Text = "DIRECTOR";
            }
            else if (p is Actor)
            {
                Actor actor = (Actor)personF;

                lblTitleF.Text = actor.CharacterName;
            }

            btnF.Visible = true;
            lblTitleF.Visible = true;
            lblNameF.Visible = true;
        }

        private void SetMovieA(Movie m)
        {
            movieA = m;

            if (movieA.ImageFile != "" && movieA.ImageFile != null)
            {
                Image aImg = Image.FromFile(Movie.ImgPath + movieA.ImageFile);
                btnA.Image = Helpers.ResizeImage(aImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameA.Text = movieA.Title;
            lblTitleA.Text = movieA.Year.ToString();

            btnA.Visible = true;
            lblTitleA.Visible = true;
            lblNameA.Visible = true;
        }
        private void SetMovieB(Movie m)
        {
            movieB = m;

            if (movieB.ImageFile != "" && movieB.ImageFile != null)
            {
                Image bImg = Image.FromFile(Movie.ImgPath + movieB.ImageFile);
                btnB.Image = Helpers.ResizeImage(bImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameB.Text = movieB.Title;
            lblTitleB.Text = movieB.Year.ToString();

            btnB.Visible = true;
            lblTitleB.Visible = true;
            lblNameB.Visible = true;
        }
        private void SetMovieC(Movie m)
        {
            movieC = m;

            if (movieC.ImageFile != "" && movieC.ImageFile != null)
            {
                Image cImg = Image.FromFile(Movie.ImgPath + movieC.ImageFile);
                btnC.Image = Helpers.ResizeImage(cImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameC.Text = movieC.Title;
            lblTitleC.Text = movieC.Year.ToString();

            btnC.Visible = true;
            lblTitleC.Visible = true;
            lblNameC.Visible = true;
        }
        private void SetMovieD(Movie m)
        {
            movieD = m;

            if (movieD.ImageFile != "" && movieD.ImageFile != null)
            {
                Image dImg = Image.FromFile(Movie.ImgPath + movieD.ImageFile);
                btnD.Image = Helpers.ResizeImage(dImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameD.Text = movieD.Title;
            lblTitleD.Text = movieD.Year.ToString();

            btnD.Visible = true;
            lblTitleD.Visible = true;
            lblNameD.Visible = true;
        }
        private void SetMovieE(Movie m)
        {
            movieE = m;

            if (movieE.ImageFile != "" && movieE.ImageFile != null)
            {
                Image eImg = Image.FromFile(Movie.ImgPath + movieE.ImageFile);
                btnE.Image = Helpers.ResizeImage(eImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameE.Text = movieE.Title;
            lblTitleE.Text = movieE.Year.ToString();

            btnE.Visible = true;
            lblTitleE.Visible = true;
            lblNameE.Visible = true;
        }
        private void SetMovieF(Movie m)
        {
            movieF = m;

            if (movieE.ImageFile != "" && movieE.ImageFile != null)
            {
                Image fImg = Image.FromFile(Movie.ImgPath + movieF.ImageFile);
                btnF.Image = Helpers.ResizeImage(fImg, SecondaryImgW, SecondaryImgH);
            }

            lblNameF.Text = movieF.Title;
            lblTitleF.Text = movieF.Year.ToString();

            btnF.Visible = true;
            lblTitleF.Visible = true;
            lblNameF.Visible = true;
        }

        private void SetGenres()
        {
            string genreStr = "";
            int count = 0;

            foreach (GenreType gtype in movie.Genres)
            {
                if (gtype == GenreType.FilmNoir)
                {
                    genreStr += "Film -Noir";
                }
                else if (gtype == GenreType.SciFi)
                {
                    genreStr += "Sci-Fi";
                }
                else
                {
                    genreStr += gtype.ToString();
                }

                count++;

                if (count != movie.Genres.Count)
                {
                    genreStr += ", ";
                }
            }

            lblLow.Text = genreStr;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            HideAllSecondaries();

            if (pageNum > 0)
            {
                pageNum--;

                if (pageNum == 0)
                {
                    btnLeft.Visible = false;
                }
            }

            btnRight.Visible = true;

            InitPeopleScreen();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            HideAllSecondaries();

            if (pageNum < maxPage)
            {
                pageNum++;

                if (pageNum == maxPage)
                {
                    btnRight.Visible = false;
                }
            }

            btnLeft.Visible = true;

            InitPeopleScreen();
        }


        private void btnA_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personA.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieA.MovieId);
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personB.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieB.MovieId);
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personC.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieC.MovieId);
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personD.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieD.MovieId);
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personE.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieE.MovieId);
            }
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            if (type == DetailType.Movie)
            {
                Program.MovieDetailToPersonDetail(personF.PersonId);
            }
            else if (type == DetailType.Person)
            {
                Program.PersonDetailToMovieDetail(movieF.MovieId);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Program.MovieDetailToPlay(movie.MovieId);
        }


        private void Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.DetailToView();
        }
    }
}
