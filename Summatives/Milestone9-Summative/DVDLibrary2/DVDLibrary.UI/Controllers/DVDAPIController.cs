using DVDLibary.Models.Models;
using DVDLibrary.Data.Factories;
using DVDLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibrary.UI.Controllers
{   
    public class DVDAPIController : ApiController
    {   

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult InsertDVD(DVDListView dvdListView)
        {
            var repo = DVDRepositoryFactory.GetRepository();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.InsertDVD(dvdListView);
            return Created($"dvds/get/{dvdListView.dvdId}", dvdListView);
        }

        [Route("dvd/{dvdid}")]
        [AcceptVerbs("PUT")]
        public void UpdateDVD(DVDListView dvdListView)
        {
            var repo = DVDRepositoryFactory.GetRepository();

                repo.UpdateDVD(dvdListView);
        }


        [Route("dvd/{dvdid}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDVD(int dvdId)
        {
            var repo = DVDRepositoryFactory.GetRepository();

            try
            {
                repo.DeleteDVD(dvdId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DVDAll()
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            { 
                return Ok(repo.AllDVD());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/title/{dvdTitle}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDTitle(string dvdTitle)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                List<DVDListView> titleList = repo.DVDTitle(dvdTitle);
                return Ok(titleList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDYear(int releaseYear)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                List<DVDListView> yearList = repo.DVDReleaseYear(releaseYear);
                return Ok(yearList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDDirector(string directorName)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                List<DVDListView> directorList = repo.DVDDirector(directorName);
                return Ok(directorList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDRating(string rating)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                List<DVDListView> ratingList = repo.DVDByRating(rating);
                return Ok(ratingList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvd/{dvdid}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDById(int dvdid)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                DVDListView dvdList = repo.DVDByID(dvdid);
                return Ok(dvdList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}