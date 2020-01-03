using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Objects
{
    class Pacman : BaseGameObject, IProtagonist
    {
        public DirectionKeys PressedKeys { get; set; }

        public Coordinate CurrentPlace { get; set; }

        //constructor
        public Pacman()
        {

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
                        obj.IsEnabled = false;
                        break;
                    case "Blinky":

                        Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathRight);

                        Animation.Location = new Coordinate(obj.Animation.Location.X, obj.Animation.Location.Y);

                        break;
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
            //current coordinate of object
            CurrentPlace = Animation.Location;

            bool RightKeyPressed = (PressedKeys & DirectionKeys.Right) == DirectionKeys.Right;
            bool LeftKeyPressed = (PressedKeys & DirectionKeys.Left) == DirectionKeys.Left;
            bool UpKeyPressed = (PressedKeys & DirectionKeys.Up) == DirectionKeys.Up;
            bool DownKeyPressed = (PressedKeys & DirectionKeys.Down) == DirectionKeys.Down;

            //move right
            if (RightKeyPressed & (Animation.AnimationType != AnimationType.PacmanRight))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                Animation.Location = CurrentPlace;

            }
            else if (RightKeyPressed)
            {
                Animation.Location += MoveRight;
            }

            //move left
            if (LeftKeyPressed & (Animation.AnimationType != AnimationType.PacmanLeft))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                Animation.Location = CurrentPlace;

            }
            else if (LeftKeyPressed)
            {
                Animation.Location -= MoveLeft;
            }

            //move up
            if (UpKeyPressed & (Animation.AnimationType != AnimationType.PacmanUp))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);

                Animation.Location = CurrentPlace;

            }
            else if (UpKeyPressed)
            {
                Animation.Location -= MoveUp;
            }

            //move down
            if (DownKeyPressed & (Animation.AnimationType != AnimationType.PacmanDown))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);

                Animation.Location = CurrentPlace;

            }
            else if (DownKeyPressed)
            {
                Animation.Location += MoveDown;
            }
        }
    }
}

