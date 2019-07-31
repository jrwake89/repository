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
    public class SalesReportAPIController : ApiController
    {
        [Route("api/reports/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReport(string userName, string fromDate, string toDate)
        {
            var repo = SalesFactory.GetSalesRepository();
            var parameters = new SalesSearchParameters();

            parameters.UserName = userName;

            var date = new DateTime();

           if(DateTime.TryParse(fromDate, out date))
           {
                parameters.FromDate = date;
           }
            else
            {
                parameters.FromDate = null;
            }

            date = new DateTime();

            if (DateTime.TryParse(toDate, out date))
            {
                parameters.ToDate = date;
            }
            else
            {
                parameters.ToDate = null;
            }

            try
            {
                var sales = repo.GetSalesSearchResults(parameters);

                if(sales.Count() != 0)
                {
                    return Ok(sales);
                }
                else
                {
                    return NotFound();
                }
                
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}