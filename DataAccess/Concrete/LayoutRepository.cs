using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class LayoutRepository : ILayoutRepository
    {
        public int CreateLayout(int X, int Y)
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                Layout data = new Layout();
                data.X = X;
                data.Y = Y;
                integerSpiralDbContext.Layouts.Add(data);
                integerSpiralDbContext.SaveChanges();
                return data.LayoutID;
            }
        }

        public List<Layout> GetLayouts()
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                return integerSpiralDbContext.Layouts.ToList();
            }
        }

        public int GetValueOfLayout(int id, int X, int Y)
        {
            using (var integerSpiralDbContext = new IntegerSpiralDbContext())
            {
                var data = integerSpiralDbContext.Layouts.FirstOrDefault(x => x.LayoutID == id);
                int xCoordinate = data.X ; // 8 
                int yCoordinate = data.Y; // 10
				int[,] matrix = new int[xCoordinate, yCoordinate];  // [7,9]
				int row = 0;
				int col = 0;
				string direction = "right";
				int maxRotations = (xCoordinate) * (yCoordinate);
				for (int i = 1; i <= maxRotations; i++)
				{
					if ((direction == "right") && (col > (yCoordinate - 1) || matrix[row, col] != 0))
					{
						direction = "down";
						col--;
						row++;
					}
					if ((direction == "down") && (row > (xCoordinate - 1) || matrix[row, col] != 0))
					{
						direction = "left";
						row--;
						col--;
					}
					if ((direction == "left") && (col < 0 || matrix[row, col] != 0))
					{
						direction = "up";
						col++;
						row--;
					}
					if ((direction == "up") && (row < 0 || matrix[row, col] != 0))
					{
						direction = "right";
						row++;
						col++;
					}
					matrix[row, col] = i;
					if (direction == "right")
					{
						col++;
					}
					if (direction == "down")
					{
						row++;
					}
					if (direction == "left")
					{
						col--;
					}
					if (direction == "up")
					{
						row--;
					}
				}
				return matrix[X-1, Y-1];
                //return integerSpiralDbContext.Layouts.FirstOrDefault(x => x.LayoutID == id && x.X == X && x.Y == Y);
            }
        }
    }
}
