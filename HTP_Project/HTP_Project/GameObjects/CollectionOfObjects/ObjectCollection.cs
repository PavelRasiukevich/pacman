using HTP_Project.GameObjects.Classes;
using PacmanEngine.Components.Actors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.GameObjects.CollectionOfObjects
{
    class ObjectCollection
    {
      static private List<IGameObject> list;

        public static IEnumerable<IGameObject> Get
        {
            get => list;
        }

        public static IEnumerable<IGameObject> CreateObjects()
        {
            list = new List<IGameObject>();

            list.Add(new BigCoin());
            list.Add(new Pacman());
            list.Add(new Coin());
            list.Add(new Background());

            return list;
        }
    }
}
