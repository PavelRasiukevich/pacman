using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Objects
{
    class Pacman : BaseGameObject, IProtagonist
    {

        private Animation animation;

        private string name;


        public DirectionKeys PressedKeys { get; set; }

        public new Animation Animation
        {
            get
            {
                return animation;
            }

            set
            {
                animation = value;
            }
        }



        public new string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }




        public Pacman()
        {

            animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

            animation.Location = new Coordinate(0.5f, 13f);

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


            bool RightKeyPressed = (PressedKeys & DirectionKeys.Right) == DirectionKeys.Right;
            bool LeftKeyPressed = (PressedKeys & DirectionKeys.Left) == DirectionKeys.Left;
            bool UpKeyPressed = (PressedKeys & DirectionKeys.Up) == DirectionKeys.Up;
            bool DownKeyPressed = (PressedKeys & DirectionKeys.Down) == DirectionKeys.Down;


            //move right
            if (RightKeyPressed & (animation.AnimationType != AnimationType.PacmanRight))
            {
                animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

            }
            else if (RightKeyPressed)
            {
                animation.Location += MoveRight;
            }

            //move left
            if (LeftKeyPressed & (animation.AnimationType != AnimationType.PacmanLeft))
            {
                animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                
            }
            else if (LeftKeyPressed)
            {
                animation.Location -= MoveLeft;
            }

            //move up
            if (UpKeyPressed & (animation.AnimationType != AnimationType.PacmanUp))
            {
                animation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);


            }
            else if (UpKeyPressed)
            {
                animation.Location -= MoveUp;
            }

            //move down
            if (DownKeyPressed & (animation.AnimationType != AnimationType.PacmanDown))
            {
                animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);


            }
            else if (DownKeyPressed)
            {
                animation.Location += MoveDown;
            }
        }
    }
}

