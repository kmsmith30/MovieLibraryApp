using MovieLibraryApp.Model;
using MovieLibraryApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibraryApp
{
    static class Program
    {
        public const string ImgPath = 
            @"C:\Users\Kevin Smith\source\repos\MovieLibraryApp\Images\";

        public const string VidPath =
            @"C:\Users\Kevin Smith\source\repos\MovieLibraryApp\Videos\";

        public static Navigation Nav { get; private set; }

        public static AdminControl Ctrl { get; private set; }

        public static ListAll View { get; set; }
        public static Search Search { get; set; }
        public static AddMovie Add { get; set; }

        public static Detail Detail { get; set; }

        public static Categorize Category { get; set; }

        public static Play Play { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Nav = new Navigation();

            Ctrl = new AdminControl { Visible = false };

            View = new ListAll(GenreType.Null) { Visible = false };
            Search = new Search { Visible = false };
            Add = new AddMovie { Visible = false };

            Detail = new Detail { Visible = false };
            Category = new Categorize { Visible = false };

            Play = new Play { Visible = false };

            Application.Run(Nav);
        }


        public static void NavToControl()
        {
            Nav.Hide();

            Ctrl.Show();
        }

        public static void ControlToNav()
        {
            Ctrl.Hide();
            Ctrl = new AdminControl { Visible = false };

            Nav.Show();
        }

        public static void NavToView()
        {
            Nav.Hide();

            View.Show();
        }

        public static void ViewToMovieDetail(int mid)
        {
            View.Hide();

            Detail = new Detail(mid, DetailType.Movie);
            Detail.Show();
        }

        public static void MovieDetailToPersonDetail(int pid)
        {
            Detail.Hide();

            Detail = new Detail(pid, DetailType.Person);
            Detail.Show();
        }

        public static void PersonDetailToMovieDetail(int mid)
        {
            Detail.Hide();

            Detail = new Detail(mid, DetailType.Movie);
            Detail.Show();
        }

        public static void MovieDetailToPlay(int mid)
        {
            Detail.Hide();

            Play = new Play(mid);
            Play.Show();
        }

        public static void PlayToMovieDetail(int mid)
        {
            Play.Hide();
            Play = new Play { Visible = false };

            Detail = new Detail(mid, DetailType.Movie);
            Detail.Show();
        }

        public static void DetailToView()
        {
            Detail.Hide();

            View.Show();
        }

        public static void ViewToNav()
        {
            View = new ListAll(GenreType.Null) { Visible = false };

            Nav.Show();
        }

        public static void NavToSearch()
        {
            Nav.Hide();

            Search.Show();
        }

        public static void SearchToCategory()
        {
            Search.Hide();

            Category.Show();
        }

        public static void CategoryToView(GenreType genre)
        {
            Category.Hide();
            Category = new Categorize { Visible = false };
            
            View = new ListAll(genre);
            View.Show();
        }

        public static void CategoryToNav()
        {
            Category = new Categorize { Visible = false };

            Nav.Show();
        }

        public static void SearchToNav()
        {
            Search.Hide();

            Nav.Show();
        }

        public static void NavToAdd()
        {
            Nav.Hide();

            Add.Show();
        }

        public static void AddToNav()
        {
            Add.Hide();
            Add = new AddMovie { Visible = false };

            View = new ListAll(GenreType.Null) { Visible = false };

            Nav.Show();
        }
    }
}
