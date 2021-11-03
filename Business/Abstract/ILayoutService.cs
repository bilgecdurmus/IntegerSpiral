using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILayoutService
    {
        Task<List<Layout>> GetLayouts();
        Task<int> GetValueOfLayout(int id, int X, int Y);
        Task<int> CreateLayout(int X, int Y);
    }
}
