using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Implementations;
using HTP_Project.GameObjects.Protagonist;
using HTP_Project.GameObjects.StaticObjects;

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
                    res.Name = InitialData.Pacman.ToString();
                    
                    break;

                case InitialData.Blinky:
                    res = new Blinky();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.Blinky.ToString();
                    break;

                /*case InitialData.Inky:
                    res = new Inky();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.Inky.ToString();
                    break;

                case InitialData.Pinky:
                    res = new Pinky();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.Pinky.ToString();
                    break;

                case InitialData.Clyde:
                    res = new Clyde();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.Clyde.ToString();
                    break;*/

                case InitialData.BigCoin:
                    res = new BigCoin();
                    res.Animation.Location = point.Crdnt;
                    res.Name = InitialData.BigCoin.ToString();
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
