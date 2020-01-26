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

        public Coordinate Step;


        public int Speed { get; set; } = Coordinate.Multiplier / 10;

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

                        obj.IsEnabled = false;

                        break;

                    case "BigCoin":

                        obj.IsEnabled = false;

                        Arbiter.Blinky.BecomeVulnerable();

                        Arbiter.Maze.ChangeFromBlueToWhite();

                        break;

                    case "Blinky":

                        if (Arbiter.Blinky.IsVulnerable)
                        {
                            switch (Arbiter.Blinky.Animation.AnimationType)
                            {
                                case AnimationType.BlueGhost:
                                   // Arbiter.Blinky.BecomeEyes();
                                    break;
                            }
                        }
                        else
                        {
                            
                            Animation deathAnimation = null;

                            Speed = 0;

                            switch (Animation.AnimationType)
                            {
                                case AnimationType.PacmanRight:
                                    deathAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathRight);
                                   
                                    deathAnimation.Location = Animation.Location;
                                    break;

                                case AnimationType.PacmanLeft:
                                    deathAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathLeft);
                                    deathAnimation.Location = Animation.Location;
                                    break;

                                case AnimationType.PacmanUp:
                                    deathAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathUp);
                                    deathAnimation.Location = Animation.Location;
                                    break;

                                case AnimationType.PacmanDown:
                                    deathAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathDown);
                                    deathAnimation.Location = Animation.Location;
                                    break;

                            }
                            
                            Animation = deathAnimation;
                            deathAnimation.Location = Animation.Location;


                        }

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

            if ((PressedKeys & DirectionKeys.Right) == DirectionKeys.Right & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier + 1, Animation.Location.Y / Coordinate.Multiplier])
            {
                newDirection = DirectionKeys.Right;
            }

            else if ((PressedKeys & DirectionKeys.Left) == DirectionKeys.Left & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier - 1, Animation.Location.Y / Coordinate.Multiplier])
            {
                newDirection = DirectionKeys.Left;
            }

            else if ((PressedKeys & DirectionKeys.Up) == DirectionKeys.Up & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, Animation.Location.Y / Coordinate.Multiplier - 1])
            {
                newDirection = DirectionKeys.Up;
            }

            else if ((PressedKeys & DirectionKeys.Down) == DirectionKeys.Down & GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, Animation.Location.Y / Coordinate.Multiplier + 1])
            {
                newDirection = DirectionKeys.Down;
            }


            if (CurrentDirection != newDirection && newDirection != DirectionKeys.None & (Animation.Location.X % Coordinate.Multiplier == 0 & Animation.Location.Y % Coordinate.Multiplier == 0))
            {
                Animation newAnimation = null;


                switch (newDirection)
                {
                    case DirectionKeys.Right:

                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                        Step = new Coordinate(Speed, 0);

                        break;

                    case DirectionKeys.Left:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);
                        Step = new Coordinate(-Speed, 0);
                        break;

                    case DirectionKeys.Up:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);
                        Step = new Coordinate(0, -Speed);
                        break;

                    case DirectionKeys.Down:
                        newAnimation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);
                        Step = new Coordinate(0, Speed);
                        break;

                }

                newAnimation.Location = Animation.Location;
                Animation = newAnimation;
                CurrentDirection = newDirection;

            }



            switch (CurrentDirection)
            {


                case DirectionKeys.Right:


                    if (GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier + 1, Animation.Location.Y / Coordinate.Multiplier])
                    {
                        Animation.Location += Step;
                    }
                    break;

                case DirectionKeys.Left:


                    if (GridCreator.Grid[(int)Math.Ceiling((double)Animation.Location.X / Coordinate.Multiplier - 1), Animation.Location.Y / Coordinate.Multiplier])
                    {
                        Animation.Location += Step;
                    }

                    break;

                case DirectionKeys.Up:

                    if (GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, (int)Math.Ceiling((double)Animation.Location.Y / Coordinate.Multiplier - 1)])
                    {
                        Animation.Location += Step;
                    }
                    break;

                case DirectionKeys.Down:

                    if (GridCreator.Grid[Animation.Location.X / Coordinate.Multiplier, Animation.Location.Y / Coordinate.Multiplier + 1])
                    {
                        Animation.Location += Step;
                    }
                    break;
            }

        }

    }
}

