using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MovieLibraryApp.Model
{
    class Actor : Person
    {
        private const int TopId = 894;

        public new const string DbName = "dbo.Actors";

        public int ActorId { get; private set; }

        public int MovieId { get; private set; }

        public string CharacterName { get; set; }

        public Actor() : base()
        {
            ActorId = Error;
            MovieId = Error;
            CharacterName = "";
        }

        public Actor(string firstname,int mid) : base(firstname)
        {
            MovieId = mid;
        }

        public Actor(string firstname, string lastname,int mid) :
            base(firstname, lastname)
        {
            MovieId = mid;
        }

        public Actor(string firstname, string middlename, string lastname, int mid) : 
            base(firstname, middlename, lastname)
        {
            MovieId = mid;
        }

        public static bool Insert(Actor a)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("dbo.uspNewActor", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@PersonId", SqlDbType.Int));
                    sqlCmd.Parameters["@PersonId"].Value = a.PersonId;

                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Value = a.MovieId;

                    sqlCmd.Parameters.Add(new SqlParameter("@CharacterName", SqlDbType.NVarChar, 100));
                    sqlCmd.Parameters["@CharacterName"].Value = a.CharacterName;

                    sqlCmd.Parameters.Add(new SqlParameter("@ActorId", SqlDbType.Int));
                    sqlCmd.Parameters["@ActorId"].Direction = ParameterDirection.Output;

                    try
                    {
                        sqlConn.Open();

                        int check = sqlCmd.ExecuteNonQuery();

                        if (check == 0)
                        {
                            result = false;
                        }
                        else
                        {
                            a.PersonId = (int)sqlCmd.Parameters["@PersonId"].Value;
                        }
                    }
                    catch
                    {
                        result = false;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return result;
        }

        public static List<Actor> LoadByMovie(int mid)
        {
            List<Actor> actors = new List<Actor>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT * FROM " + DbName + " WHERE MovieId = @MovieId";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Value = mid;

                    try
                    {
                        sqlConn.Open();

                        using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
                        {
                            if (sqlReader.HasRows)
                            {
                                while (sqlReader.Read())
                                {
                                    int pid = sqlReader.GetInt32(sqlReader.GetOrdinal("PersonId"));
                                    string charname = sqlReader.GetString(sqlReader.GetOrdinal("CharacterName"));

                                    Person person = LoadById(pid);

                                    Actor actor = new Actor(person.FirstName, person.MiddleName, person.LastName, mid);
                                    actor.PersonId = pid;
                                    actor.CharacterName = charname;
                                    actor.ImageFile = person.ImageFile;

                                    actors.Add(actor);
                                }
                            }
                        }
                    }
                    catch
                    {
                        actors = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return actors;
        }

        public static List<Movie> LoadMoviesByPersonId(int pid)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT * FROM " + DbName + " WHERE PersonId = @PersonId";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@PersonId", SqlDbType.Int));
                    sqlCmd.Parameters["@PersonId"].Value = pid;

                    try
                    {
                        sqlConn.Open();

                        using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
                        {
                            if (sqlReader.HasRows)
                            {
                                while (sqlReader.Read())
                                {
                                    int mid = sqlReader.GetInt32(sqlReader.GetOrdinal("MovieId"));

                                    Movie movie = Movie.LoadById(mid);

                                    movies.Add(movie);
                                }
                            }
                        }
                    }
                    catch
                    {
                        movies = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return movies;
        }

        public new static bool ResetId()
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string sqlQuery = $"DBCC CHECKIDENT ('Actors', RESEED, {TopId})";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();

                        int check = sqlCmd.ExecuteNonQuery();

                        if (check == 0)
                        {
                            result = false;
                        }
                    }
                    catch
                    {
                        result = false;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return result;
        }
    }
}
