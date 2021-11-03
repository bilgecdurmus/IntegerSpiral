using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Models;

namespace DataAccess.Extension
{
    public class FillLayout
    {
        public static int[,] Fill_Layout(int X, int Y)
        {

            int[,] matrix = new int[X, Y]; //Create Matrix
            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = (X) * (Y);
            for (int i = 1; i <= maxRotations; i++)
            {
                if ((direction == "right") && (col > (Y - 1) || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if ((direction == "down") && (row > (X - 1) || matrix[row, col] != 0))
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
            return matrix;
        }
    }
}
