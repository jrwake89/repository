using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibary.Models.Models;
using DVDLibrary.Models.Models;


namespace DVDLibrary.Data
{
    public class DVDRepository : IDVDRepository
    {
        private static List<Ratings> _ratings = new List<Ratings>
            {
                new Ratings {RatingID = 1, Rating = "G" },
                new Ratings {RatingID = 2, Rating = "PG" },
                new Ratings {RatingID = 3, Rating = "PG-13" },
                new Ratings {RatingID = 4, Rating = "R" }
            };

        public List<DVDListView> ConvertToListView(List<DVD> dvds)
        {

            var dvdListViews = from dvd in dvds
                                             join rating in _ratings on dvd.RatingID equals rating.RatingID
                                             select new DVDListView { dvdId = dvd.DVDID, dvdTitle = dvd.DVDTitle, director = dvd.Director, rating = rating.Rating, releaseYear = dvd.ReleaseYear, notes = dvd.Notes};

            return dvdListViews.ToList();
        }

        public List<DVDListView> AllDVD()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<DVD> DVD = new List<DVD>();
                SqlCommand cmd = new SqlCommand("AllDVD");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.DVDID = (int)dr["DVDID"];
                        currentRow.DVDTitle = dr["DVDTitle"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Notes = dr["Notes"].ToString();

                        DVD.Add(currentRow);
                    }

                    List<DVDListView> dvdListView = ConvertToListView(DVD);

                    return dvdListView;
                }
            }
        }

        public void DeleteDVD(int DVDID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                List<DVD> DVD = new List<DVD>();
                SqlCommand cmd = new SqlCommand("DVDDelete");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDID", DVDID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public DVDListView DVDByID(int DVDID)
        {
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                
                SqlCommand cmd = new SqlCommand("DVDByID");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDID", DVDID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DVDID = (int)dr["DVDID"];
                        dvd.RatingID = (int)dr["RatingId"];
                        dvd.DVDTitle = dr["DVDTitle"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Notes = dr["Notes"].ToString();
                    }
                }
            }

            List<DVD> dvdList = new List<DVD>();
            dvdList.Add(dvd);

            List<DVDListView> dvdListView = ConvertToListView(dvdList);

            return dvdListView[0];
        }

        public List<DVDListView> DVDByRating(string rating)
        {
            List<DVD> DVD = new List<DVD>();
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var dvds = _ratings.Where(r => r.Rating == rating);
                int ratingId = 0;

                foreach(var rate in dvds)
                {
                    ratingId = rate.RatingID;
                }

                SqlCommand cmd = new SqlCommand("DVDByRating");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RatingID", ratingId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DVDID = (int)dr["DVDID"];
                        dvd.RatingID = (int)dr["RatingId"];
                        dvd.DVDTitle = dr["DVDTitle"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Notes = dr["Notes"].ToString();

                        DVD.Add(dvd);
                    }
                }

                List<DVDListView> dvdListView = ConvertToListView(DVD);


                return dvdListView;
            }
        }

        public List<DVDListView> DVDDirector(string director)
        {
            List<DVD> DVD = new List<DVD>();
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDDirector");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DVDID = (int)dr["DVDID"];
                        dvd.RatingID = (int)dr["RatingId"];
                        dvd.DVDTitle = dr["DVDTitle"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Notes = dr["Notes"].ToString();

                        DVD.Add(dvd);
                    }
                }

                List<DVDListView> dvdListView = ConvertToListView(DVD);


                return dvdListView;
            }
        }

        public List<DVDListView> DVDReleaseYear(int releaseYear)
        {
            List<DVD> DVD = new List<DVD>();
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDReleaseYear");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DVDID = (int)dr["DVDID"];
                        dvd.RatingID = (int)dr["RatingId"];
                        dvd.DVDTitle = dr["DVDTitle"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Notes = dr["Notes"].ToString();

                        DVD.Add(dvd);
                    }
                }

                List<DVDListView> dvdListView = ConvertToListView(DVD);


                return dvdListView;
            }
        }

        public List<DVDListView> DVDTitle(string dvdTitle)
        {
            List<DVD> DVD = new List<DVD>();
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {


                SqlCommand cmd = new SqlCommand("DVDTitle");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDTitle", dvdTitle);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DVDID = (int)dr["DVDID"];
                        dvd.RatingID = (int)dr["RatingId"];
                        dvd.DVDTitle = dr["DVDTitle"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Notes = dr["Notes"].ToString();

                        DVD.Add(dvd);
                    }
                }

                List<DVDListView> dvdListView = ConvertToListView(DVD);


                return dvdListView;
            }
        }

        public void InsertDVD(DVDListView dvdListView)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<DVDListView> dvds = AllDVD();
                DVD dvd = new DVD()
                {
                    DVDID = dvds.Count()-1,
                    DVDTitle = dvdListView.dvdTitle,
                    Director = dvdListView.director,
                    ReleaseYear = dvdListView.releaseYear,
                    Notes = dvdListView.notes
                };

                dvd.RatingID = GetIdFromRating(dvdListView.rating);
                SqlCommand cmd = new SqlCommand("InsertDVD", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DVDID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@RatingID", dvd.RatingID);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@DVDTitle", dvd.DVDTitle);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateDVD(DVDListView dvdListView)
        {
            DVD dvd = new DVD()
            {
                DVDID = dvdListView.dvdId,
                DVDTitle = dvdListView.dvdTitle,
                Director = dvdListView.director,
                ReleaseYear = dvdListView.releaseYear,
                Notes = dvdListView.notes
            };

            dvd.RatingID = GetIdFromRating(dvdListView.rating);
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                
                SqlCommand cmd = new SqlCommand("UpdateDVD", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DVDID", dvd.DVDID);
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@RatingId", dvd.RatingID);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@DVDTitle", dvd.DVDTitle);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

            }        
        }

        public int GetIdFromRating(string rat)
        {
            int ratId = 0;

            var rating = _ratings.Where(r => r.Rating == rat);
            foreach (var rate in rating)
            {
                ratId = rate.RatingID;
            }

            return ratId;
        }
    }
}
