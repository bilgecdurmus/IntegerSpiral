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
        List<Layout> GetLayouts();
        int GetValueOfLayout(int id, int X, int Y);
        int CreateLayout(int X, int Y);
    }
}
