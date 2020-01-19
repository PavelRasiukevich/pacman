using HTP_Project.Data.Creators;
using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Global;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Protagonist
{
    class Pacman : BaseGameObject, IProtagonist
    {
        private DirectionKeys CurrentDirection = DirectionKeys.None;

        public int Speed { get; set; } = Coordinate.Multiplier;

        public GrandArbiter Arbiter { get; set; }

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

                switch (obj.Name)
                {
                    case "SmallCoin":

                        break;

                    case "BigCoin":
                        Arbiter.Blinky.BecomeVulnerable();
                        break;

                    case "Blinky":

                        break;

                    case "Inly":
                        break;

                    case "Pinky":
                        break;

                    case "Clyde":
                        break;
                    default:

                        break;
                }
            }
        }

        public override void Update()
        {

            DirectionKeys newDirection = DirectionKeys.None;

            if ((PressedKeys & DirectionKeys.Right) == DirectionKeys.Right & GridCreator.Grid[(int)Math.Ceiling((double)Animation.Location.X / Coordinate.Multiplier + 1), (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier)])
            {
                newDirection = DirectionKeys.Right;
            }

            else if ((PressedKeys & DirectionKeys.Left) == DirectionKeys.Left & GridCreator.Grid[(int)Math.Ceiling((double)Animation.Location.X / Coordinate.Multiplier - 1), (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier)])
            {
                newDirection = DirectionKeys.Left;
            }

            else if ((PressedKeys & DirectionKeys.Up) == DirectionKeys.Up & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier - 1)])
            {
                newDirection = DirectionKeys.Up;
            }

            else if ((PressedKeys & DirectionKeys.Down) == DirectionKeys.Down & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier + 1)])
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

                    if (GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier + 1, (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier)])

                        Animation.Location += new Coordinate(Speed / 10, 0);
                    break;

                case DirectionKeys.Left:

                    if (GridCreator.Grid[(int)Math.Ceiling((double)Animation.Location.X / Coordinate.Multiplier - 1), Animation.Location.Y / Coordinate.Multiplier])
                    {
                        Animation.Location -= new Coordinate(Speed / 10, 0);
                    }

                    break;

                case DirectionKeys.Up:
                    if (GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier - 1)])
                        Animation.Location -= new Coordinate(0, Speed / 10);
                    break;

                case DirectionKeys.Down:
                    if (GridCreator.Grid[(int)Math.Ceiling((double)Animation.Location.X / Coordinate.Multiplier), Animation.Location.Y / Coordinate.Multiplier + 1])
                        Animation.Location += new Coordinate(0, Speed / 10);
                    break;
            }

        }

    }
}

