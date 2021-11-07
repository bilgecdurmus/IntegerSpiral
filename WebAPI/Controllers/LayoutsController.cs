using Business.Abstract;
using Business.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutsController : ControllerBase
    {
        private ILayoutService _layoutservice;
        public LayoutsController(ILayoutService layoutService)
        {
            _layoutservice = layoutService;
        }

        /// <summary>
        /// Get All Layouts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLayouts()
        {
            var layouts = await _layoutservice.GetLayouts();
            return Ok(layouts); // 200 + data
        } 
        /// <summary>
        /// Get Value Of [X,Y] Coordinate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id,x,y}")]
        public async Task<IActionResult> GetValueOfLayout([FromQuery]int id, [FromQuery] int X, [FromQuery] int Y)
        {
            if (id >0 && X > 0 && Y > 0 )
            {
            var layout = await _layoutservice.GetValueOfLayout(id, X, Y);
            if (layout != null)
            {
                return Ok(layout); // 200 + data
            }
            return NotFound(); // 404
            }
            return BadRequest(); // 400
        }
        /// <summary>
        /// Create Layout
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]/{x,y}")]
        public async Task<IActionResult> CreateLayout([FromQuery] int X , [FromQuery] int Y)
        {
            if (X > 0 && Y > 0)
            {
                    var layout = await _layoutservice.CreateLayout(X, Y);
                    return Ok(layout); // 200 + data 
            }
            return BadRequest(); //400
        }
    }
}
