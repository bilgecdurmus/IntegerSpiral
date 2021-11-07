using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Models;
using Moq;
using System;
using WebAPI.Controllers;
using Xunit;

namespace UnitTest
{
    public class LayoutsControllerTests
    {
        
        [Fact]
        public async System.Threading.Tasks.Task CreateLayout_IsValid()
        {
            LayoutRepository _layoutrepository = new LayoutRepository();
            LayoutManager layoutManager = new LayoutManager(_layoutrepository);
            int Layouts = await _layoutrepository.CreateLayout(5,8);
            Assert.NotNull(Layouts);
        }
        [Fact]
        public async System.Threading.Tasks.Task GetValueOfLayout_IsRanged()
        {
            LayoutRepository _layoutrepository = new LayoutRepository();
            LayoutManager layoutManager = new LayoutManager(_layoutrepository);
            int Layouts = await _layoutrepository.GetValueOfLayout(2,4,4);
            Assert.Equal(11,Layouts);
        }

    }
}
