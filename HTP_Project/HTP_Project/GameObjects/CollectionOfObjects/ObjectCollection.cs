using HTP_Project.GameObjects.Objects;
using PacmanEngine.Components.Actors;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.CollectionOfObjects
{
    sealed class ObjectCollection
    {

        static private List<IGameObject> list;

        public static IEnumerable<IGameObject> CreateObjects()
        {
            list = new List<IGameObject>();

            Pacman pacman = new Pacman();
            Background background = new Background();
            Blinky blinky = new Blinky();
            BigCoin bigCoin = new BigCoin();

            pacman.bigCoinEaten += background.ChangeFromBlueToWhite;
            pacman.bigCoinEaten += blinky.MakeVulnerable;
            pacman.bigCoinEaten += bigCoin.GetTime;


            list.Add(pacman);
            list.Add(background);
            list.Add(blinky);
            list.Add(bigCoin);
            list.Add(blinky);
            list.Add(new Coin());

            return list;
        }
    }
}
