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
            list = new List<IGameObject>

            {
                new BigCoin(),
                new Pacman(),
                new Coin(),
                new Background(),
                new Blinky()
            };

            return list;
        }
    }
}
