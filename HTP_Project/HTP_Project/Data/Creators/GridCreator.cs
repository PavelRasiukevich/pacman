using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using PacmanEngine.Components.Base;

namespace HTP_Project.Data.Creators
{
    class GridCreator
    {
       
        public static bool[,] Grid { get; set; }

        public static bool[,] CreateGrid(PointData[] data)
        {
            var Grid = new bool[21, 27];

            foreach (var d in data)
            {
                Grid[d.Crdnt.X / Coordinate.Multiplier, d.Crdnt.Y / Coordinate.Multiplier] = d.InitData != InitialData.Wall;
            }
            return Grid;
        }

    }
}
