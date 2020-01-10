using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.Data.Creators
{
    class GameObjectCreator
    {
        public static BaseGameObject CreateOGameObject(PointData point)
        {
            BaseGameObject res = null;

            switch (point.InitData)
            {
                case InitialData.Pacman:
                    res = new Pacman();
                    res.Animation.Location = point.Crdnt;
                    break;

                case InitialData.Blinky:
                    res = new Blinky();
                    res.Animation.Location = point.Crdnt;
                    break;

                case InitialData.BigCoin:
                    res = new BigCoin();
                    res.Animation.Location = point.Crdnt;
                    break;

                case InitialData.SmallCoin:
                    res = new SmallCoin();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.SmallCoin.ToString();
                    break;


            }
            
            return res;
        }
    }
}
