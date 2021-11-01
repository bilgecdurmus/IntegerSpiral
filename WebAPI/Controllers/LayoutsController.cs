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

        [HttpGet]
        public List<Layout> GetLayouts()
        {
            return _layoutservice.GetLayouts();
        } 

        [HttpGet("{id,x,y}")]
        public int GetValueOfLayout(int id,int X,int Y)
        {
            return _layoutservice.GetValueOfLayout(id,X,Y);
        }

        [HttpPost("{x,y}")]
        public int CreateLayout(int X , int Y)
        {
            return _layoutservice.CreateLayout(X,Y);
        }
    }
}
