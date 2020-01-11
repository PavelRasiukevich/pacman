using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using PacmanEngine.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.Data.Creators

{
    class PointCreator
    {

        private const string str = "000000000000000000000 022222222202222222220 020002000202000200020 030002000202000200030 020002000202000200020 022222222222222222220 020002020000020200020 020002020000020200020 022222022202220222220 000002000101000200000 000002011111110200000 000002010010010200000 000002010151010200000 111112110678011211111 000002010000010200000 000002011111110200000 000002010000010200000 000002010000010200000 022222222202222222220 020002000202000200020 032202222242222202230 000202020000020202000 000202020000020202000 022222022202220222220 020000000202000000020 022222222222222222220 000000000000000000000";

        public static PointData[] CreatePoints()
        {

            var rows = str.Split(' ');

            PointData[] pointDataArray =
                //str was parsed to ints from string
                rows.Select(x => x.Select(element => int.Parse(element.ToString())).ToArray()).
                //arr - array of arrays of ints; Coordinate_Y - index of each array 
                Select((arr, Coordinate_Y) =>
                //NumberInEachArray - each element in array; Coordinate_X - index of each element in array
                arr.Select((NumberInEachArray, Coordinate_X)
                //
                => new PointData() { Crdnt = new Coordinate(Coordinate_X, Coordinate_Y), InitData = (InitialData)NumberInEachArray }))
                .SelectMany(e => e).ToArray();

            return pointDataArray;
        }
    }
}
