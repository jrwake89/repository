using DVDLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public interface IDVDRepository
    {
        List<DVDListView> AllDVD();
        DVDListView DVDByID(int dvdId);
        List<DVDListView> DVDTitle(string dvdTitle);
        List<DVDListView> DVDReleaseYear(int releaseYear);
        List<DVDListView> DVDDirector(string director);
        List<DVDListView> DVDByRating(string rating);
        void UpdateDVD(DVDListView dvd);
        void InsertDVD(DVDListView dvd);
        void DeleteDVD(int dvdId);
    }
}
