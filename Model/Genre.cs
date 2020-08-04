using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace MovieLibraryApp.Model
{
    public enum GenreType {
        Action = 100,
        Adventure = 101,
        Animation = 118,
        Biography = 222,
        Comedy = 243,
        Crime = 303,
        Drama = 369,
        Family = 405,
        Fantasy = 444,
        FilmNoir = 488,
        History = 509,
        Horror = 555,
        Music = 599,
        Musical = 605,
        Mystery = 666,
        Other = 711,
        Romance = 702,
        SciFi = 757,
        Sport = 799,
        Thriller = 808,
        War = 818,
        Western = 880, 
        Null = -905
    };

    public class Genre
    {
        public const int Error = 0x422;

        public const string DbName = "dbo.Genres";

        public const string ImgPath = Program.ImgPath + @"Genres\";

        public int GenreId { get; private set; }

        public GenreType Type { get; private set; }

        public int MovieId { get; private set; }

        public Genre()
        {
            GenreId = Error;
            MovieId = Error;
            Type = GenreType.Other;
        }

        public Genre(GenreType gt, int mid) : base() 
        {
            Type = gt;
            MovieId = mid;
        }

        public static bool Insert(Genre g)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("dbo.uspNewGenre", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@GenreType", SqlDbType.Int));
                    sqlCmd.Parameters["@GenreType"].Value = (int)g.Type;

                    sqlCmd.Parameters.Add(new SqlParameter("@MovieId", SqlDbType.Int));
                    sqlCmd.Parameters["@MovieId"].Value = g.MovieId;

                    sqlCmd.Parameters.Add(new SqlParameter("@GenreId", SqlDbType.Int));
                    sqlCmd.Parameters["@GenreId"].Direction = ParameterDirection.Output;

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
                            g.GenreId = (int)sqlCmd.Parameters["@GenreId"].Value;
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

        public static Genre LoadById(int gid)
        {
            Genre genre = new Genre();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT * FROM " + DbName + " WHERE GenreId = @GenreId";

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@GenreId", SqlDbType.Int));
                    sqlCmd.Parameters["@GenreId"].Value = gid;

                    try
                    {
                        sqlConn.Open();

                        using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
                        {
                            if (sqlReader.HasRows)
                            {
                                while (sqlReader.Read())
                                {
                                    genre.GenreId = sqlReader.GetInt32(sqlReader.GetOrdinal("@GenreId"));
                                    genre.Type = (GenreType)sqlReader.GetInt32(sqlReader.GetOrdinal("@GenreType"));
                                    genre.MovieId = sqlReader.GetInt32(sqlReader.GetOrdinal("@MovieId"));
                                }
                            }
                        }
                    }
                    catch
                    {
                        genre = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return genre;
        }

        public static List<Genre> LoadAll()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT * FROM " + DbName;

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
                                    Genre g = new Genre();

                                    g.GenreId = sqlReader.GetInt32(0);
                                    g.Type = (GenreType)sqlReader.GetInt32(1);
                                    g.MovieId = sqlReader.GetInt32(2);

                                    genres.Add(g);
                                }
                            }
                        }
                    }
                    catch
                    {
                        genres = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return genres;
        }

        public static List<Genre> LoadAllByType(GenreType type)
        {
            List<Genre> allGenres = LoadAll();

            List<Genre> genres = new List<Genre>();
            
            foreach (Genre genre in allGenres)
            {
                if (genre.Type == type)
                {
                    genres.Add(genre);
                }
            }

            return genres;
        }

        public static bool ResetId()
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "DBCC CHECKIDENT ('Genres', RESEED, 0)";

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