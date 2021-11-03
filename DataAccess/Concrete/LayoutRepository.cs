using DataAccess.Abstract;
using DataAccess.Extension;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class LayoutRepository : ILayoutRepository
    {
        public async Task<int> CreateLayout(int X, int Y)
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                
                Layout data = new Layout();
                data.X = X;
                data.Y = Y;
                int[,] values = FillLayout.Fill_Layout(X, Y);
                string lvalues = JsonConvert.SerializeObject(values);
                data.Layout_Values = lvalues;
                integerSpiralDbContext.Layouts.Add(data);
                await integerSpiralDbContext.SaveChangesAsync();

                return data.LayoutID;
            }
        }

        public async Task<List<Layout>> GetLayouts()
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                return await integerSpiralDbContext.Layouts.ToListAsync();
            }
        }
       
        public async Task<int> GetValueOfLayout(int id, int X, int Y)
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                var data = await integerSpiralDbContext.Layouts.FirstOrDefaultAsync(x => x.LayoutID == id);
                int[,] values = JsonConvert.DeserializeObject<int[,]>(data.Layout_Values);          
                //var data = await integerSpiralDbContext.Values.FirstOrDefaultAsync(x => x.LayoutId == id && x.XCoordinate == X && x.YCoordinate == Y);
                int layoutValue = values[X-1,Y-1];
                return layoutValue;

            }
        }
    }
}
