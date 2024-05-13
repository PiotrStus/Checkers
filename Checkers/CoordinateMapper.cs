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
        /// <summary>
        /// Prepare coordinate map
        /// Fill coordinateMap & reverseCoordinateMap dictionary.
        /// </summary>
        protected void InitializeCoordinateMap()
        {
            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int col = 0; col < Columns.Length; col++)
                {
                    string key = $"{Columns[col]}{row + 1}";
                    coordinateMap[key] = (row, col);
                    reverseCoordinateMap[(row, col)] = key;
                }
            }
        }
        /// <summary>
        /// Get coordinates for a specific checker, e.g A0 returns (0,0).
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public (int, int) GetCoordinates(string key)
        {
            return coordinateMap[key];
        }
        /// <summary>
        /// Get an index of a specific checker, e.g. (0,0) returns A0.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public string GetIndex((int, int) coordinates)
        {
            return reverseCoordinateMap[coordinates];
        }
    }
}
