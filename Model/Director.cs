using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryApp.Model
{
    class Director : Person
    {
        private const int TopId = 50;

        public new const string DbName = "dbo.Directors";

        public int DirectorId { get; private set; }

        public int MovieId { get; private set; }

        public Director() : base()
        {
            DirectorId = Error;
            MovieId = Error;
        }

        public Director(string firstname, int mid) : base(firstname)
        {
            MovieId = mid;
        }

        public Director(string firstname, string lastname, int mid) :
            base(firstname, lastname)
        {
            MovieId = mid;
        }

        public Director(string firstname, string middlename, string lastname, int mid) :
            base(firstname, middlename, lastname)
        {
            MovieId = mid;
        }

        public static bool Insert(Director d)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("dbo.uspNewDirector", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@PersonId", SqlDbType.Int));
                    sqlCmd.Parameters["@PersonId"].Value = d.PersonId;

                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Value = d.MovieId;

                    sqlCmd.Parameters.Add(new SqlParameter("@DirectorId", SqlDbType.Int));
                    sqlCmd.Parameters["@DirectorId"].Direction = ParameterDirection.Output;

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
                            d.DirectorId = (int)sqlCmd.Parameters["@DirectorId"].Value;
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

        public new static Person LoadById(int did)
        {
            Director director = new Director();
            Person person = new Person();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT * FROM " + DbName + " WHERE DirectorId = @DirectorId";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@DirectorId", SqlDbType.Int));
                    sqlCmd.Parameters["@DirectorId"].Value = did;

                    try
                    {
                        sqlConn.Open();

                        using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
                        {
                            if (sqlReader.HasRows)
                            {
                                while (sqlReader.Read())
                                {
                                    director.DirectorId = sqlReader.GetInt32(sqlReader.GetOrdinal("DirectorId"));
                                    director.PersonId = sqlReader.GetInt32(sqlReader.GetOrdinal("PersonId"));
                                    director.MovieId = sqlReader.GetInt32(sqlReader.GetOrdinal("MovieId"));
                                }
                            }
                        }

                        person = Person.LoadById(director.PersonId);
                    }
                    catch
                    {
                        person = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return person;
        }    
    
        public static List<Director> LoadByMovie(int mid)
        {
            List<Director> directors = new List<Director>();

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
                                    int dirId = sqlReader.GetInt32(sqlReader.GetOrdinal("DirectorId"));
                                    int perId = sqlReader.GetInt32(sqlReader.GetOrdinal("PersonId"));
                                    int movId = sqlReader.GetInt32(sqlReader.GetOrdinal("MovieId"));

                                    Person person = Person.LoadById(perId);

                                    Director director = new Director(person.FirstName, person.MiddleName,
                                        person.LastName, movId);

                                    director.PersonId = perId;
                                    director.ImageFile = person.ImageFile;

                                    directors.Add(director);
                                }
                            }
                        }
                    }
                    catch
                    {
                        directors = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return directors;
        }

        public new static List<Director> LoadAll()
        {
            List<Director> directors = new List<Director>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT DirectorId FROM " + DbName;
            }

            return directors;
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
                string sqlQuery = $"DBCC CHECKIDENT ('Directors', RESEED, {TopId})";

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
