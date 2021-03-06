﻿using HTP_Project.Data.Creators;
using HTP_Project.Enums;
using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Implementations;
using HTP_Project.GameObjects.Global;
using HTP_Project.GameObjects.Protagonist;
using HTP_Project.GameObjects.StaticObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace HTP_Project.CollectionInitializer
{
    sealed class ObjectCollection
    {

        static private List<IGameObject> list;

        public static IEnumerable<IGameObject> InitCollection()
        {

            list = new List<IGameObject>();
            
            GridCreator.Grid = GridCreator.CreateGrid(PointCreator.CreatePoints());

            var background = BaseGameObject.CreateStaticObject(AnimationType.MazeBlue, 0, 0);

            var tempList = PointCreator.CreatePoints().Select(GameObjectCreator.CreateOGameObject).Where(x => x != null).ToList();

            var pac = tempList.OfType<Pacman>().First();

            GrandArbiter grandArbiter = new GrandArbiter

            {
                Maze = (Background)background,

                Blinky = tempList.OfType<Blinky>().First()
                
            };
            
            pac.Arbiter = grandArbiter;
            
            list.Add(background);
            
            list.AddRange(tempList);

            return list;
        }

    }
}
