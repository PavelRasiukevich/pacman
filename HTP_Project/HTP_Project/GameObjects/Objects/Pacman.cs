using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Objects
{
    class Pacman : BaseGameObject, IProtagonist
    {
        internal delegate void BigCoinEaten();
        internal event BigCoinEaten bigCoinEaten;



        const float XRight = 19.58f;
        const float Y = 13f;
        const float XLeft = 0.35f;

        

        public Coordinate rightSpot = new Coordinate(XRight, Y);
        public Coordinate leftSpot = new Coordinate(XLeft, Y);

        public DirectionKeys PressedKeys { get; set; }

        public Coordinate CurrentCoordinate { get; set; }

        //constructor
        public Pacman()
        {
            Name = "Pacman";

            Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

            Animation.Location = new Coordinate(0.5f, 13f);

        }

        public void Collide(IEnumerable<IGameObject> collisions)
        {
            foreach (var obj in collisions)
            {
                switch (obj.Name)
                {
                    case "BigCoin":

                        //event invokation
                        bigCoinEaten();

                        break;

                        //test
                        /*case "Blinky":

                            if (Animation.AnimationType == AnimationType.PacmanRight)
                            {
                                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathRight);
                            }
                            Animation.Location = CurrentCoordinate;

                            break;*/
                }

            }
        }

        public override void Update()
        {

            var MoveRight = new Coordinate(0.1f, 0f);
            var MoveLeft = MoveRight;

            var MoveUp = new Coordinate(0f, 0.1f);
            var MoveDown = MoveUp;

            Move(MoveRight, MoveLeft, MoveUp, MoveDown);

        }

        private void Move(Coordinate MoveRight, Coordinate MoveLeft, Coordinate MoveUp, Coordinate MoveDown)
        {
            //represents current location
            CurrentCoordinate = Animation.Location;

            bool RightKeyPressed = (PressedKeys & DirectionKeys.Right) == DirectionKeys.Right;
            bool LeftKeyPressed = (PressedKeys & DirectionKeys.Left) == DirectionKeys.Left;
            bool UpKeyPressed = (PressedKeys & DirectionKeys.Up) == DirectionKeys.Up;
            bool DownKeyPressed = (PressedKeys & DirectionKeys.Down) == DirectionKeys.Down;

            MoveAlongAxis_X(MoveRight, RightKeyPressed, LeftKeyPressed);

            MoveAlongAxis_Y(MoveUp, UpKeyPressed, DownKeyPressed);
        }

        private void MoveAlongAxis_X(Coordinate MoveRight, bool RightKeyPressed, bool LeftKeyPressed)
        {
            //if we are not out of bounds of background
            if (CurrentCoordinate.X < 19.7f)
            {
                //change animation to demanded
                if (RightKeyPressed & (Animation.AnimationType != AnimationType.PacmanRight))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                    Animation.Location = CurrentCoordinate;

                }
                //change location if condition is true
                if ((CurrentCoordinate.X > rightSpot.X) & (CurrentCoordinate.Y == rightSpot.Y))
                {

                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                    Animation.Location = new Coordinate(leftSpot.X, leftSpot.Y);

                }
                //move right
                if (RightKeyPressed)
                {
                    Animation.Location += MoveRight;
                }

            }
            //if we are not out of bounds of background
            if (CurrentCoordinate.X > 0.2f)
            {
                //change animation to demanded
                if (LeftKeyPressed & (Animation.AnimationType != AnimationType.PacmanLeft))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                    Animation.Location = CurrentCoordinate;

                }
                //change location if condition is true
                if ((CurrentCoordinate.X < leftSpot.X) & (CurrentCoordinate.Y == leftSpot.Y))
                {

                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                    Animation.Location = new Coordinate(rightSpot.X, rightSpot.Y);

                }
                //move left
                if (LeftKeyPressed)
                {
                    Animation.Location -= MoveRight;
                }
            }
        }

        private void MoveAlongAxis_Y(Coordinate MoveUp, bool UpKeyPressed, bool DownKeyPressed)
        {
            //if we are not out of bounds of background
            if (CurrentCoordinate.Y > 0.35f)
            {
                //change animation to demanded
                if (UpKeyPressed & (Animation.AnimationType != AnimationType.PacmanUp))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);

                    Animation.Location = CurrentCoordinate;
                }

                //move up
                if (UpKeyPressed)
                {
                    Animation.Location -= MoveUp;
                }

            }

            //if we are not out of bounds of background
            if (CurrentCoordinate.Y < 25.5f)
            {
                //change animation to demanded
                if (DownKeyPressed & (Animation.AnimationType != AnimationType.PacmanDown))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);

                    Animation.Location = CurrentCoordinate;
                }

                //move up
                if (DownKeyPressed)
                {
                    Animation.Location += MoveUp;
                }

            }
        }


    }
}

