using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class CoordinateMapper
    {
        private Dictionary<string, (int, int)> coordinateMap;
        private Dictionary<(int, int), string> reverseCoordinateMap;
        public char[] Columns { get; private set; }
        public int NumberOfRows { get; private set; }
        public CoordinateMapper(char[] columns, int rows)
        {
            coordinateMap = new Dictionary<string, (int, int)>();
            reverseCoordinateMap = new Dictionary<(int, int), string>();
            InitializeCoordinateMap();
            Columns = columns;
            NumberOfRows = rows;
        }
        protected void InitializeCoordinateMap()
        {
            //char[] columns = "ABCDEFGH".ToCharArray();
            //int rows = 8;

            for (int row = 0; row < NumberOfRows; row++)
            {
                //Console.WriteLine($"row: {row}");
                for (int col = 0; col < Columns.Length; col++)
                {
                    string key = $"{Columns[col]}{row + 1}";
                    //Console.WriteLine($"colum: {col}");
                    //Console.WriteLine($"key: {key}");
                    coordinateMap[key] = (row, col);
                    reverseCoordinateMap[(row, col)] = key;
                }
            }
        }
        public (int, int) GetCoordinates(string key)
        {
            return coordinateMap[key];
        }
        public string GetIndex((int, int) coordinates)
        {
            return reverseCoordinateMap[coordinates];
        }
    }
}
