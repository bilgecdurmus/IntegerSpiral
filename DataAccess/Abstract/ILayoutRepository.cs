using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILayoutRepository
    {
        Task<List<Layout>> GetLayouts();
        Task<int> GetValueOfLayout(int id, int X, int Y);
        Task<int> CreateLayout(int X, int Y);
    }
}
