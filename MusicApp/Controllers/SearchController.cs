using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController:ControllerBase
    {
        private ISearchTrackService searchTrackService;
        
        public SearchController(ISearchTrackService searchTrackService)
        {
            this.searchTrackService = searchTrackService;
        }

        [HttpGet]
        public async Task<ActionResult> GetSearchTrackResult([FromQuery]string q,
            [FromQuery] string types,[FromQuery] string market,[FromQuery]int limit,[FromQuery]int offset)
        {
            var result = await searchTrackService.GetTracks(q, types);
            return Ok(result);
        }

    }
}
