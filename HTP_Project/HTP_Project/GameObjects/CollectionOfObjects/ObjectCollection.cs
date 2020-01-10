using HTP_Project.Data.Creators;
using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Objects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace HTP_Project.GameObjects.CollectionOfObjects
{
    sealed class ObjectCollection
    {
        static private List<IGameObject> list;

        public static IEnumerable<IGameObject> InitCollection()
        {
            
            list = new List<IGameObject>();

            list.Add(BaseGameObject.CreateStaticObject(AnimationType.MazeBlue, 0, 0));

            list.AddRange(PointCreator.CreatePoints().Select(GameObjectCreator.CreateOGameObject).Where(x => x != null));

            //Pacman pacman = new Pacman();
            //Background background = new Background();
            //Blinky blinky = new Blinky();
            //BigCoin bigCoin = new BigCoin();

            //pacman.bigCoinEaten += background.ChangeFromBlueToWhite;
            //pacman.bigCoinEaten += blinky.MakeVulnerable;
            //pacman.bigCoinEaten += bigCoin.GetTime;


            //list.Add(pacman);
            //list.Add(background);
            //list.Add(blinky);
            //list.Add(bigCoin);
            //list.Add(blinky);


            return list;
        }

    }
}
