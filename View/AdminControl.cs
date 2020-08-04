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
    public partial class AdminControl : Form
    {
        List<Movie> movies;

        public AdminControl()
        {
            InitializeComponent();

            InitControls();

            InitMovieList();
        }

        private void InitControls()
        {
            txtActFirst.GotFocus += txtActFirst_GotFocus;
            txtActFirst.LostFocus += txtActFirst_LostFocus;

            txtDirFirst.GotFocus += txtDirFirst_GotFocus;
            txtDirFirst.LostFocus += txtDirFirst_LostFocus;

            txtActMiddle.GotFocus += txtActMiddle_GotFocus;
            txtActMiddle.LostFocus += txtActMiddle_LostFocus;

            txtDirMiddle.GotFocus += txtDirMiddle_GotFocus;
            txtDirMiddle.LostFocus += txtDirMiddle_LostFocus;

            txtActLast.GotFocus += txtActLast_GotFocus;
            txtActLast.LostFocus += txtActLast_LostFocus;

            txtDirLast.GotFocus += txtDirLast_GotFocus;
            txtDirLast.LostFocus += txtDirLast_LostFocus;
        }

        private void InitMovieList()
        {
            movies = Movie.LoadAll();

            cbxMovies.Items.Clear();

            foreach (Movie movie in movies)
            {
                cbxMovies.Items.Add(movie.Title);
            }
        }

        private bool IsDirectorEmpty()
        {
            return txtDirFirst.Text == "First" &&
                txtDirMiddle.Text == "Middle" &&
                txtDirLast.Text == "Last";
        }
        private bool IsActorEmpty()
        {
            return txtActFirst.Text == "First" &&
                txtActMiddle.Text == "Middle" &&
                txtActLast.Text == "Last";
        }

        private Director GetDirector()
        {
            Director dir;

            string fn = "", mn = "", ln = "";

            int mid = cbxMovies.SelectedIndex+1;

            if (txtDirFirst.Text != "First")
            {
                fn = txtDirFirst.Text;
            }

            if (txtDirMiddle.Text != "Middle")
            {
                mn = txtDirMiddle.Text;
            }

            if (txtDirLast.Text != "Last")
            {
                ln = txtDirLast.Text;
            }

            if (fn != "" && mn == "" && ln == "")
            {
                dir = new Director(fn, mid);
            }
            else if (fn != "" && mn == "" && ln != "")
            {
                dir = new Director(fn, ln, mid);
            }
            else if (fn != "" && mn != "" && ln != "")
            {
                dir = new Director(fn, mn, ln, mid);
            }
            else
            {
                dir = null;
            }

            return dir;
        }
        private Actor GetActor()
        {
            Actor act;

            string fn = "", mn = "", ln = "";

            int mid = cbxMovies.SelectedIndex + 1;

            if (txtActFirst.Text != "First")
            {
                fn = txtActFirst.Text;
            }

            if (txtActMiddle.Text != "Middle")
            {
                mn = txtActMiddle.Text;
            }

            if (txtActLast.Text != "Last")
            {
                ln = txtActLast.Text;
            }

            if (fn != "" && mn == "" && ln == "")
            {
                act = new Actor(fn, mid);
            }
            else if (fn != "" && mn == "" && ln != "")
            {
                act = new Actor(fn, ln, mid);
            }
            else if (fn != "" && mn != "" && ln != "")
            {
                act = new Actor(fn, mn, ln, mid);
            }
            else
            {
                act = null;
            }

            return act;
        }

        private void ResetControlForm()
        {
            txtDirFirst.Text = "First";
            txtDirMiddle.Text = "Middle";
            txtDirLast.Text = "Last";

            txtActFirst.Text = "First";
            txtActMiddle.Text = "Middle";
            txtActLast.Text = "Last";

            //cbxMovies.SelectedIndex = -1;

            txtImg.Text = "";

            txtChar.Text = "";
        }

        private void btnAddDirector_Click(object sender, EventArgs e)
        {
            if (!IsDirectorEmpty())
            {
                if (IsActorEmpty())
                {
                    if (cbxMovies.SelectedIndex != -1)
                    {
                        Director director = GetDirector();

                        if (Person.Exists(director))
                        {
                            int pid = Person.GetIdByName(director.FirstName, director.MiddleName,
                                director.LastName);

                            director.PersonId = pid;

                            bool success = Director.Insert(director);

                            if (success)
                            {
                                MessageBox.Show("Director exists and is added!");

                                ResetControlForm();
                            }
                            else
                            {
                                MessageBox.Show("Error adding Director to Db");
                            }
                        }
                        else if (txtImg.Text != "")
                        {
                            director.ImageFile = txtImg.Text;

                            bool success = Person.Insert(director);

                            if (success)
                            {
                                MessageBox.Show("Person added!");
                            }
                            else
                            {
                                MessageBox.Show("Error adding Person to db");
                                return;
                            }

                            int pid = Person.GetIdByName(director.FirstName, director.MiddleName, 
                                director.LastName);

                            director.PersonId = pid;

                            success = Director.Insert(director);

                            if (success)
                            {
                                MessageBox.Show("Director successfully added!");

                                ResetControlForm();
                            }
                            else
                            {
                                MessageBox.Show("Error adding Director to Db");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Image must be filled");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: A Movie must be selected");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Actor name is not empty");
                }
            }
            else
            {
                MessageBox.Show("Error: Director name or image can't be empty");
            }
        }

        private void btnAddActor_Click(object sender, EventArgs e)
        {
            if (!IsActorEmpty())
            {
                if (IsDirectorEmpty())
                {
                    if (cbxMovies.SelectedIndex != -1)
                    {
                        Actor actor = GetActor();

                        if (Person.Exists(actor) && txtChar.Text != "")
                        {
                            int pid = Person.GetIdByName(actor.FirstName, actor.MiddleName,
                                actor.LastName);

                            actor.PersonId = pid;
                            actor.CharacterName = txtChar.Text;

                            bool success = Actor.Insert(actor);

                            if (success)
                            {
                                MessageBox.Show("Actor exists and is added!");

                                ResetControlForm();
                            }
                            else
                            {
                                MessageBox.Show("Error adding Actor to db");
                            }
                        }
                        else if (txtImg.Text != "" && txtChar.Text != "")
                        {
                            actor.ImageFile = txtImg.Text;

                            bool success = Person.Insert(actor);

                            if (success)
                            {
                                MessageBox.Show("Person added!");
                            }
                            else
                            {
                                MessageBox.Show("Error adding Person to db");
                                return;
                            }

                            int pid = Person.GetIdByName(actor.FirstName, actor.MiddleName,
                                actor.LastName);

                            actor.PersonId = pid;
                            actor.CharacterName = txtChar.Text;

                            success = Actor.Insert(actor);

                            if (success)
                            {
                                MessageBox.Show("Actor successfully added!");

                                ResetControlForm();
                            }
                            else
                            {
                                MessageBox.Show("Error adding Actor to Db");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Image and Character should be filled");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error: Director name is not empty");
                }
            }
            else
            {
                MessageBox.Show("Error: Actor name or image can't be empty");
            }
        }

        private void txtDirFirst_GotFocus(object sender, EventArgs e)
        {
            if (txtDirFirst.Text == "First")
            {
                txtDirFirst.Text = "";
            }
        }

        private void txtDirFirst_LostFocus(object sender, EventArgs e)
        {
            if (txtDirFirst.Text == "")
            {
                txtDirFirst.Text = "First";
            }
        }

        private void txtActFirst_GotFocus(object sender, EventArgs e)
        {
            if (txtActFirst.Text == "First")
            {
                txtActFirst.Text = "";
            }
        }

        private void txtActFirst_LostFocus(object sender, EventArgs e)
        {
            if (txtActFirst.Text == "")
            {
                txtActFirst.Text = "First";
            }
        }

        private void txtDirMiddle_GotFocus(object sender, EventArgs e)
        {
            if (txtDirMiddle.Text == "Middle")
            {
                txtDirMiddle.Text = "";
            }
        }

        private void txtDirMiddle_LostFocus(object sender, EventArgs e)
        {
            if (txtDirMiddle.Text == "")
            {
                txtDirMiddle.Text = "Middle";
            }
        }

        private void txtActMiddle_GotFocus(object sender, EventArgs e)
        {
            if (txtActMiddle.Text == "Middle")
            {
                txtActMiddle.Text = "";
            }
        }

        private void txtActMiddle_LostFocus(object sender, EventArgs e)
        {
            if (txtActMiddle.Text == "")
            {
                txtActMiddle.Text = "Middle";
            }
        }

        private void txtDirLast_GotFocus(object sender, EventArgs e)
        {
            if (txtDirLast.Text == "Last")
            {
                txtDirLast.Text = "";
            }
        }

        private void txtDirLast_LostFocus(object sender, EventArgs e)
        {
            if (txtDirLast.Text == "")
            {
                txtDirLast.Text = "Last";
            }
        }

        private void txtActLast_GotFocus(object sender, EventArgs e)
        {
            if (txtActLast.Text == "Last")
            {
                txtActLast.Text = "";
            }
        }

        private void txtActLast_LostFocus(object sender, EventArgs e)
        {
            if (txtActLast.Text == "")
            {
                txtActLast.Text = "Last";
            }
        }


        private void txtDirFirst_TextChanged(object sender, EventArgs e)
        {
            if (txtDirFirst.Text == "First")
            {
                txtDirFirst.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtDirFirst.ForeColor = Color.PaleGreen;
            }
        }

        private void txtDirMiddle_TextChanged(object sender, EventArgs e)
        {
            if (txtDirMiddle.Text == "Middle")
            {
                txtDirMiddle.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtDirMiddle.ForeColor = Color.PaleGreen;
            }
        }

        private void txtDirLast_TextChanged(object sender, EventArgs e)
        {
            if (txtDirLast.Text == "Last")
            {
                txtDirLast.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtDirLast.ForeColor = Color.PaleGreen;
            }
        }

        private void txtActFirst_TextChanged(object sender, EventArgs e)
        {
            if (txtActFirst.Text == "First")
            {
                txtActFirst.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtActFirst.ForeColor = Color.PaleGreen;
            }
        }

        private void txtActMiddle_TextChanged(object sender, EventArgs e)
        {
            if (txtActMiddle.Text == "Middle")
            {
                txtActMiddle.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtActMiddle.ForeColor = Color.PaleGreen;
            }
        }

        private void txtActLast_TextChanged(object sender, EventArgs e)
        {
            if (txtActLast.Text == "Last")
            {
                txtActLast.ForeColor = Color.FromArgb(240, 244, 248);
            }
            else
            {
                txtActLast.ForeColor = Color.PaleGreen;
            }
        }


        private void AdminControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ControlToNav();
        }
    }
}