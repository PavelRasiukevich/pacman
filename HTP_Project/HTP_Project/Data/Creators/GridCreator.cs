using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;

namespace HTP_Project.Data.Creators
{
    class GridCreator
    {
        public static bool[,] CreateGrid(PointData[] data)
        {
            var GRID = new bool[21, 27];

            foreach (var d in data)
            {
                GRID[(int)d.Crdnt.X, (int)d.Crdnt.Y] = d.InitData != InitialData.Wall;
            }
            return GRID;
        }

    }
}
