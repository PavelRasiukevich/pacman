using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;

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
                Grid[(int)d.Crdnt.X, (int)d.Crdnt.Y] = d.InitData != InitialData.Wall;
            }
            return Grid;
        }

    }
}
