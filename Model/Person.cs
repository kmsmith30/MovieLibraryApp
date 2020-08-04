using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibraryApp.Model
{
    public class Person
    {
        public const int Error = 0x444;

        private const int TopId = 822;

        public const string DbName = "dbo.People";

        public const string ImgPath = Program.ImgPath + @"People\";

        public static int NumPeople = 0;

        public int PersonId { get; set; }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public string ImageFile { get; set; }

        public Person()
        {
            PersonId = Error;
            FirstName = "";
            MiddleName = "";
            LastName = "";
            ImageFile = "";
        }

        public Person(string firstname) : base()
        {
            FirstName = firstname;
            MiddleName = "";
            LastName = "";
        }

        public Person(string firstname, string lastname) : base()
        {
            FirstName = firstname;
            MiddleName = "";
            LastName = lastname;
        }

        public Person(string firstname, string middlename, string lastname) 
            : base()
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
        }
    
        public static bool Insert(Person p)
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("dbo.uspNewPerson", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 200));
                    sqlCmd.Parameters["@FirstName"].Value = p.FirstName;

                    sqlCmd.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 200));

                    if (p.MiddleName != "" && p.MiddleName != null)
                    {
                        sqlCmd.Parameters["@MiddleName"].Value = p.MiddleName;
                    }
                    else
                    {
                        sqlCmd.Parameters["@MiddleName"].Value = DBNull.Value;
                    }

                    sqlCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 200));

                    if (p.LastName != "" && p.LastName != null)
                    {
                        sqlCmd.Parameters["@LastName"].Value = p.LastName;
                    }
                    else
                    {
                        sqlCmd.Parameters["@LastName"].Value = DBNull.Value;
                    }

                    sqlCmd.Parameters.Add(new SqlParameter("@ImageFile", SqlDbType.NVarChar, 200));

                    if (p.ImageFile != "" && p.ImageFile != null)
                    {
                        sqlCmd.Parameters["@ImageFile"].Value = p.ImageFile;
                    }
                    else
                    {
                        sqlCmd.Parameters["@ImageFile"].Value = DBNull.Value;
                    }

                    sqlCmd.Parameters.Add(new SqlParameter("@PersonId", SqlDbType.Int));
                    sqlCmd.Parameters["@PersonId"].Direction = ParameterDirection.Output;

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
                            p.PersonId = (int)sqlCmd.Parameters["@PersonId"].Value;
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
    
        public static Person LoadById(int pid)
        {
            Person person = new Person();

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
                                    person.PersonId = sqlReader.GetInt32(sqlReader.GetOrdinal("PersonId"));
                                    person.FirstName = sqlReader.GetString(sqlReader.GetOrdinal("FirstName"));

                                    int mni = sqlReader.GetOrdinal("MiddleName");
                                    int lni = sqlReader.GetOrdinal("LastName");
                                    int ifi = sqlReader.GetOrdinal("ImageFile");

                                    if (!sqlReader.IsDBNull(mni))
                                    {
                                        person.MiddleName = sqlReader.GetString(mni);
                                    }

                                    if (!sqlReader.IsDBNull(lni))
                                    {
                                        person.LastName = sqlReader.GetString(lni);
                                    }

                                    if (!sqlReader.IsDBNull(ifi))
                                    {
                                        person.ImageFile = sqlReader.GetString(ifi);
                                    }
                                }
                            }
                        }
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
    
        public static List<Person> LoadAll()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sqlQuery = "SELECT PersonId FROM " + DbName;

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
                                    int pid = sqlReader.GetInt32(sqlReader.GetOrdinal("PersonId"));

                                    Person p = Person.LoadById(pid);

                                    people.Add(p);
                                }
                            }
                        }
                    }
                    catch
                    {
                        people = null;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }

            return people;
        }

        public static bool Exists(Person p)
        {
            bool result = false;

            List<Person> people = LoadAll();

            foreach (Person person in people)
            {
                if (person.FirstName == p.FirstName 
                    && person.MiddleName == p.MiddleName
                    && person.LastName == p.LastName)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static int GetIdByName(string fn, string mn, string ln)
        {
            List<Person> people = LoadAll();

            foreach (Person p in people)
            {
                if (p.FirstName == fn && p.MiddleName == mn && p.LastName == ln)
                {
                    return p.PersonId;
                }
            }

            return -1;
        }

        public static bool ResetId()
        {
            bool result = true;

            using (SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string sqlQuery = $"DBCC CHECKIDENT ('People', RESEED, {TopId})";

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