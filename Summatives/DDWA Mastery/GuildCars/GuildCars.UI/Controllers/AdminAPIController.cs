using GuildCar.Data.Factory;
using GuildCars.Model;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class AdminAPIController : ApiController
    {
        [Route("api/ModelsbyMakes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ModelsbyMakes(int makeId)
        {
            var modelsRepo = VehicleFactory.GetVehicleRepository().GetAllModels();

            try
            {
                var models = (from model in modelsRepo
                              where model.MakeId == makeId
                              select new GuildCars.Model.Model
                              {
                                  ModelName = model.ModelName,
                                  ModelId = model.ModelId
                              }).ToArray();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSearch(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string search)
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
                vehicles = vehicles.Where(v => v.IsDeleted == false);
                vehicles = vehicles.Where(v => v.IsSold == false);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/delete/special/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult RemoveSpecial(int id)
        {
            var repo = SpecialFactory.GetSpecialRepository();

            try
            {
                repo.DeleteSpecials(id);
                var model = repo.GetSpecials();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}