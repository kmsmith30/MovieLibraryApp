using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieLibraryApp.Model
{
    public class Movie
    {
        public const int Error = 0x401;

        private const int TopId = 125;

        /* Database Name */
        public const string DbName = "dbo.Movies";

        public const string ImgPath = Program.ImgPath + @"Movies\";

        public const string VidPath = Program.VidPath + @"Movies\";

        public static int NumMovies = 0;

        /* Represents the Format of the Movie */
        public enum FormatType
        {
            Bluray = 109,
            Digital = 250,
            DVD = 269,
            Other = 333,
            VHS = 679,
            Null = -905
        }

        /* Represents the Rating of the Movie */
        public enum RatingType
        {
            Approved = 101, 
            G = 200,
            NotRated = 333,
            Other = 444,
            Passed = 505, 
            PG = 606,
            PG13 = 757,
            R = 808,
            Null = -905
        };

        /* Unique Movie Id */
        public int MovieId { get; private set; }

        /* Title of Movie */
        public string Title { get; private set; }
        
        /* Year Movie was released */
        public int Year { get; private set; }
        
        /* Run Time (in minutes) of Movie */
        public int RunTime { get; private set; }

        public List<GenreType> Genres { get; set; } 

        private List<Person> Directors { get; set; }

        private List<Person> Actors { get; set; }

        private RatingType Rating { get; set; }

        public FormatType Format { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; private set; }

        public string VideoFile { get; private set; }

        /* Default Movie Constructor */
        public Movie()
        {
            MovieId = Error;
            Title = "";
            Year = Error;
            RunTime = Error;
            Rating = RatingType.Null;
            Directors = null;
            Actors = null;
            Format = FormatType.Null;
            Description = "";
            ImageFile = "";
            VideoFile = "";
        }

        /* Movie Constructor */
        public Movie(string title, int year, int rt, RatingType rate,
            FormatType fmt, string description, string img) : base()
        {
            Title = title;
            Year = year;
            RunTime = rt;
            Rating = rate;
            Format = fmt;
            Description = description;
            ImageFile = img;
        }

        /* Helper Function to determine RatingType based on string value */
        public static RatingType StrToRating(string rateStr)
        {
            if (rateStr == "Not Rated")
            {
                return RatingType.NotRated;
            }
            else if (rateStr == "PG-13")
            {
                return RatingType.PG13;
            }

            return (RatingType)Enum.Parse(typeof(RatingType), rateStr);
        }

        /* Database Functions */

        /* Insert Movie into Database */
        public static bool Insert(Movie m)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("dbo.uspNewMovie", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 400));
                    sqlCmd.Parameters["@Title"].Value = m.Title;

                    sqlCmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int));
                    sqlCmd.Parameters["@Year"].Value = m.Year;

                    sqlCmd.Parameters.Add(new SqlParameter("@RunTime", SqlDbType.Int));
                    sqlCmd.Parameters["@RunTime"].Value = m.RunTime;

                    sqlCmd.Parameters.Add(new SqlParameter("@Rating", SqlDbType.NVarChar, 50));
                    sqlCmd.Parameters["@Rating"].Value = (int)m.Rating;

                    sqlCmd.Parameters.Add(new SqlParameter("@Format", SqlDbType.Int));
                    sqlCmd.Parameters["@Format"].Value = (int)m.Format;

                    sqlCmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.Text));
                    sqlCmd.Parameters["@Description"].Value = m.Description;

                    sqlCmd.Parameters.Add(new SqlParameter("@ImageFile", SqlDbType.NVarChar, 200));
                    sqlCmd.Parameters["@ImageFile"].Value = m.ImageFile;

                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Direction = ParameterDirection.Output;

                    

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
                            m.MovieId = (int)sqlCmd.Parameters["@MovieID"].Value;
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
    
        private static Movie AddGenres(int mid, Movie movie)
        {
            List<Genre> genres = Genre.LoadAll();

            List<GenreType> types = new List<GenreType>();

            foreach (Genre g in genres)
            {
                if (g.MovieId == mid)
                {
                    types.Add(g.Type);
                }
            }

            movie.Genres = types;

            return movie;
        }

        /* Retreive Movie from Database by its Id */
        public static Movie LoadById(int mid)
        {
            Movie movie = new Movie();

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
                                    movie.MovieId = sqlReader.GetInt32(sqlReader.GetOrdinal("MovieId"));
                                    movie.Title = sqlReader.GetString(sqlReader.GetOrdinal("Title"));
                                    movie.Year = sqlReader.GetInt32(sqlReader.GetOrdinal("Year"));
                                    movie.RunTime = sqlReader.GetInt32(sqlReader.GetOrdinal("RunTime"));

                                    int ri = sqlReader.GetOrdinal("Rating");
                                    int fi = sqlReader.GetOrdinal("Format");
                                    int ifi = sqlReader.GetOrdinal("ImageFile");
                                    int di = sqlReader.GetOrdinal("Description");
                                    int vfi = sqlReader.GetOrdinal("VideoFile");

                                    if (!sqlReader.IsDBNull(ri))
                                    {
                                        movie.Rating = (RatingType)sqlReader.GetInt32(ri);
                                    }

                                    if (!sqlReader.IsDBNull(fi))
                                    {
                                        movie.Format = (FormatType)sqlReader.GetInt32(fi);
                                    }

                                    if (!sqlReader.IsDBNull(ifi))
                                    {
                                        movie.ImageFile = sqlReader.GetString(ifi);
                                    }

                                    if (!sqlReader.IsDBNull(di))
                                    {
                                        movie.Description = sqlReader.GetString(di);
                                    }

                                    if (!sqlReader.IsDBNull(vfi))
                                    {
                                        movie.VideoFile = sqlReader.GetString(vfi);
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        movie = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            if (movie != null)
            {
                movie = AddGenres(mid, movie);
            }

            return movie;
        }

        public static List<Movie> LoadAll()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT MovieId FROM " + DbName;

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
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

                                    Movie m = LoadById(mid);

                                    movies.Add(m);
                                }

                                NumMovies = movies.Count;
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

        public static List<Movie> LoadByGenre(GenreType gtype)
        {
            List<Genre> genres = Genre.LoadAllByType(gtype);

            List<Movie> movies = new List<Movie>();

            foreach (Genre g in genres)
            {
                movies.Add(LoadById(g.MovieId));
            }

            return movies;
        }

        public static List<Movie> LoadByLetter(char letter)
        {
            const char NumberMode = '#';

            List<Movie> movies = LoadAll();

            List<Movie> letMovies = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (letter == NumberMode && Char.IsDigit(movie.Title[0]))
                {
                    letMovies.Add(movie);
                }
                else if (movie.Title[0] == letter)
                {
                    letMovies.Add(movie);
                }
            }

            return letMovies;
        }


        /* Delete Movie from Database */
        public static bool Delete(int mid)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "DELETE FROM " + DbName + " WHERE MovieId = @MovieId";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Value = mid;

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
    
        /* Reset MovieId Field */
        public static bool ResetId()
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string sqlQuery = $"DBCC CHECKIDENT ('Movies', RESEED, {TopId})";

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
