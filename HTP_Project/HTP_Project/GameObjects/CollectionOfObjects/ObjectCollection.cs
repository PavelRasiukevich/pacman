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

            list.Add(new BigCoin());
            list.Add(new Pacman());
            list.Add(new Coin());
            list.Add(new Background());
            list.Add(new Blinky());

            return list;
        }
    }
}
