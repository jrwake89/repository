using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibary.Models.Models;
using DVDLibrary.Models.Models;

namespace DVDLibrary.Data
{
    public class DVDRepositoryMock : IDVDRepository
    {
            private static List<DVD> _dvds = new List<DVD>
            {
                new DVD {DVDID = 1, DVDTitle = "Inception", Director = "Christopher Nolan", RatingID = 3, ReleaseYear = 2013, Notes = "Fantastic!"},
                new DVD {DVDID = 2, DVDTitle = "Memento", Director = "Christopher Nolan", RatingID = 4, ReleaseYear = 2001, Notes = "THE BEST"},
                new DVD {DVDID = 3, DVDTitle = "Finding Nemo", Director = "Andrew Stanton", RatingID = 1, ReleaseYear = 2003, Notes = "Will Make You Cry!" }
            };

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
                                             select new DVDListView { dvdId = dvd.DVDID, dvdTitle = dvd.DVDTitle, director = dvd.Director, rating = rating.Rating, releaseYear = dvd.ReleaseYear, notes = dvd.Notes };

            return dvdListViews.ToList();
        }

        public List<DVDListView> AllDVD()
        {
            List<DVDListView> dvdListView = ConvertToListView(_dvds);
            return dvdListView;
        }

        public void DeleteDVD(int dvdId)
        {

            _dvds.RemoveAll(d => d.DVDID == dvdId);
        }

        public DVDListView DVDByID(int dvdId)
        {
            List<DVD> dvds = _dvds.Where(d => d.DVDID == dvdId).ToList();

            List<DVDListView> dvdListView = ConvertToListView(dvds);
            return dvdListView[0];
        }

        public List<DVDListView> DVDByRating(string rating)
        {
            List<DVDListView> dvdListView = ConvertToListView(_dvds);

            List<DVDListView> dvds = dvdListView.Where(d => d.rating == rating).ToList();   
            return dvdListView;
        }

        public List<DVDListView> DVDDirector(string director)
        {
            List<DVD> dvds = _dvds.Where(d => d.Director== director).ToList();

            List<DVDListView> dvdListView = ConvertToListView(dvds);
            return dvdListView;
        }

        public List<DVDListView> DVDReleaseYear(int releaseYear)
        {
            List<DVD> dvds = _dvds.Where(d => d.ReleaseYear == releaseYear).ToList();

            List<DVDListView> dvdListView = ConvertToListView(dvds);
            return dvdListView;
        }

        public List<DVDListView> DVDTitle(string dvdTitle)
        {
            List<DVD> dvds =_dvds.Where(d => d.DVDTitle == dvdTitle).ToList();

            List<DVDListView> dvdListView = ConvertToListView(dvds);
            return dvdListView;
        }

        public void InsertDVD(DVDListView dvdListView)
        {
            DVD dvd = new DVD()
            {
                DVDID = dvdListView.dvdId,
                Director = dvdListView.director,
                DVDTitle = dvdListView.dvdTitle,
                ReleaseYear = dvdListView.releaseYear,
                Notes = dvdListView.notes
            };

            dvd.RatingID = GetIdFromRating(dvdListView.rating);
            _dvds.Add(dvd);
        }

        public void UpdateDVD(DVDListView dvdListView)
        {
            DVD dvd = new DVD()
            {
                DVDID = dvdListView.dvdId,
                Director = dvdListView.director,
                DVDTitle = dvdListView.dvdTitle,
                ReleaseYear = dvdListView.releaseYear,
                Notes = dvdListView.notes
            };

            dvd.RatingID = GetIdFromRating(dvdListView.rating);
            _dvds[dvd.DVDID] = dvd;
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
