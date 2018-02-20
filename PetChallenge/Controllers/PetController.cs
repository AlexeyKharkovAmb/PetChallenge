using System;
using System.Net;
using System.Web.Http;
using PetChallenge.Models;
using PetChallenge.BusLogic;

namespace PetChallenge.Controllers
{
    public class ApiController : System.Web.Http.ApiController
    {       
        [HttpGet]
        [Route("api/cats/get", Name = "get-cats")]
        public IHttpActionResult GetCats()
        {
            var json_data = string.Empty;
            
            //fetch data
            using (var webClient = new WebClient())
            {     
                try
                {
                    json_data = webClient.DownloadString(System.Configuration.ConfigurationManager.AppSettings["JsonSourceAddress"]);
                }
                catch
                {
                    return BadRequest("Error retrieving Json feed");
                }
            }

            GenderViewModel genderModel;

            try
            {
                genderModel = CatsFetcher.FetchCats(json_data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
               
            return Ok(genderModel);
        }       
    }
}
