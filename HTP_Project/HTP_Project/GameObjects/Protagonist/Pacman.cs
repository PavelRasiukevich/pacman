using HTP_Project.Data.Creators;
using HTP_Project.Data.PointDataClass;
using HTP_Project.Enums;
using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Protagonist
{
    class Pacman : BaseGameObject, IProtagonist
    {
        internal delegate void BigCoinEaten();
        internal event BigCoinEaten bigCoinEaten;

        //...
        private DirectionKeys CurrentDirection = DirectionKeys.None;



        public float Speed { get; set; } = 0.1f;

        public DirectionKeys PressedKeys { get; set; }

        public Coordinate CurrentCoordinate { get; set; }

        //constructor
        public Pacman()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

        }

        public void Collide(IEnumerable<IGameObject> collisions)
        {
            foreach (var obj in collisions)
            {
                if (obj.Name == AnimationType.SmallCoin.ToString())
                    obj.IsEnabled = false;
            }
        }

        public override void Update()
        {

            DirectionKeys newDirection = DirectionKeys.None;

            if ((PressedKeys & DirectionKeys.Right) == DirectionKeys.Right & GridCreator.Grid[(int)Animation.Location.X + 1, (int)Animation.Location.Y])
            {
                newDirection = DirectionKeys.Right;
            }
            else if ((PressedKeys & DirectionKeys.Left) == DirectionKeys.Left & GridCreator.Grid[(int)Animation.Location.X - 1, (int)Animation.Location.Y])
            {
                newDirection = DirectionKeys.Left;
            }
            else if ((PressedKeys & DirectionKeys.Up) == DirectionKeys.Up & GridCreator.Grid[(int)Animation.Location.X, (int)Animation.Location.Y - 1])
            {
                newDirection = DirectionKeys.Up;
            }
            else if ((PressedKeys & DirectionKeys.Down) == DirectionKeys.Down & GridCreator.Grid[(int)Animation.Location.X, (int)Animation.Location.Y + 1])
            {
                newDirection = DirectionKeys.Down;
            }

            if (CurrentDirection != newDirection && newDirection != DirectionKeys.None)
            {
                Animation newAnimation = null;

                switch (newDirection)
                {
                    case DirectionKeys.Right:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);
                        break;
                    case DirectionKeys.Left:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);
                        break;
                    case DirectionKeys.Up:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);
                        break;
                    case DirectionKeys.Down:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);
                        break;

                }

                newAnimation.Location = Animation.Location;
                Animation = newAnimation;
                CurrentDirection = newDirection;
                
            }
           
            switch (CurrentDirection)
            {
                

                case DirectionKeys.Right:
                    if(GridCreator.Grid[(int)Animation.Location.X + 1, (int)Animation.Location.Y])
                        Animation.Location += new Coordinate(Speed, 0.0f);
                    break;

                case DirectionKeys.Left:
                    if (GridCreator.Grid[(int)Animation.Location.X - 1, (int)Animation.Location.Y])
                        Animation.Location -= new Coordinate(Speed, 0.0f);
                    break;

                case DirectionKeys.Up:
                    if (GridCreator.Grid[(int)Animation.Location.X, (int)Animation.Location.Y - 1])
                        Animation.Location -= new Coordinate(0.0f, Speed);
                    break;

                case DirectionKeys.Down:
                    if (GridCreator.Grid[(int)Animation.Location.X, (int)Animation.Location.Y + 1])
                        Animation.Location += new Coordinate(0.0f, Speed);
                    break;
            }

        }

    }
}

