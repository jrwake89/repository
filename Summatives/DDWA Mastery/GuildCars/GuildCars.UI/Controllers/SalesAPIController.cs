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
    public class SalesAPIController : ApiController
    {
        [Route("api/sales/index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SalesSearch(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string search)
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
                vehicles = vehicles.Where(v => v.IsSold == false);
                vehicles = vehicles.Where(v => v.IsDeleted == false);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}