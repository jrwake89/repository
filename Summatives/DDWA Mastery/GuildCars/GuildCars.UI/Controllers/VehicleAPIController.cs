using GuildCar.Data.Factory;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class VehicleAPIController : ApiController
    {
        [Route("api/inventory/new")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetNew(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string search)
        {
            var repo = VehicleFactory.GetVehicleRepository();
            var parameters = new VehicleSearchParameters();

            parameters.maxPrice = maxPrice;
            parameters.minPrice = minPrice;
            parameters.minYear = minYear;
            parameters.maxYear = maxYear;
            parameters.search = search;

            try
            {
                var vehicles = repo.GetSearchResults(parameters);
                vehicles = vehicles.Where(v => v.IsNew == true);
                vehicles = vehicles.Where(v => v.IsDeleted == false);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("api/inventory/used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsed(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string search)
        {
            var repo = VehicleFactory.GetVehicleRepository();
            var parameters = new VehicleSearchParameters();

            parameters.maxPrice = maxPrice;
            parameters.minPrice = minPrice;
            parameters.minYear = minYear;
            parameters.maxYear = maxYear;
            parameters.search = search;

            try
            {
                var vehicles = repo.GetSearchResults(parameters);
                vehicles = vehicles.Where(v => v.IsNew == false);
                vehicles = vehicles.Where(v => v.IsDeleted == false);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/details/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVehicleById(int id)
        {
            var repo = VehicleFactory.GetVehicleRepository();

            try
            {
                var vehicle = repo.GetVehicleDetails(id);
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}