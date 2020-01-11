using System;
using HTP_Project.Enums;
using HTP_Project.GameObjects.StaticObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.BaseObjects
{
    public class BaseGameObject : IGameObject
    {

        public string Name { get; set; }

        public bool IsEnabled { get; set; } = true;

        public Animation Animation { get; set; }

        public virtual void Update() { }

        public static BaseGameObject CreateStaticObject(AnimationType type, int X, int Y)
        {

            BaseGameObject result = null; ;

            switch (type)
            {
                case AnimationType.MazeBlue:

                    result = new BaseGameObject()
                    {
                        Animation = AnimationFactory.CreateAnimation(AnimationType.MazeBlue)
                    };

                    break;
            }

            if (result != null)

                result.Name = type.ToString();

            result.Animation.Location = new Coordinate(X, Y);

            return result;
        }
        
    }
}
