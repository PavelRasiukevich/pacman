﻿using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Objects
{
    class Pacman : BaseGameObject, IProtagonist
    {
        const float XRight = 19.58f;
        const float Y = 13f;
        const float XLeft = 0.35f;

        public Coordinate rightPassage = new Coordinate(XRight, Y);
        public Coordinate leftPassage = new Coordinate(XLeft, Y);

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
                        obj.IsEnabled = false;

                        break;
                    case "Blinky":

                        if (Animation.AnimationType == AnimationType.PacmanRight)
                        {
                            Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDeathRight);
                        }
                        Animation.Location = CurrentCoordinate;

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
            CurrentCoordinate = Animation.Location;

            bool RightKeyPressed = (PressedKeys & DirectionKeys.Right) == DirectionKeys.Right;
            bool LeftKeyPressed = (PressedKeys & DirectionKeys.Left) == DirectionKeys.Left;
            bool UpKeyPressed = (PressedKeys & DirectionKeys.Up) == DirectionKeys.Up;
            bool DownKeyPressed = (PressedKeys & DirectionKeys.Down) == DirectionKeys.Down;



            if (CurrentCoordinate.X < 19.7f)
            {
                //change animation to demanded
                if (RightKeyPressed & (Animation.AnimationType != AnimationType.PacmanRight))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                    Animation.Location = CurrentCoordinate;

                }
                //change location if condition is true
                if ((CurrentCoordinate.X > rightPassage.X) & (CurrentCoordinate.Y == rightPassage.Y))
                {

                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

                    Animation.Location = new Coordinate(leftPassage.X, leftPassage.Y);

                }
                //move right
                if (RightKeyPressed)
                {
                    Animation.Location += MoveRight;
                }

            }





            if (CurrentCoordinate.X > 0.2f)
            {
                //change animation to demanded
                if (LeftKeyPressed & (Animation.AnimationType != AnimationType.PacmanLeft))
                {
                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                    Animation.Location = CurrentCoordinate;

                }
                //change location if condition is true
                if ((CurrentCoordinate.X < leftPassage.X) & (CurrentCoordinate.Y == leftPassage.Y))
                {

                    Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanLeft);

                    Animation.Location = new Coordinate(rightPassage.X, rightPassage.Y);

                }
                //move right
                if (LeftKeyPressed)
                {
                    Animation.Location -= MoveRight;
                }
            }



            //move up
            if (UpKeyPressed & (Animation.AnimationType != AnimationType.PacmanUp))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanUp);

                Animation.Location = CurrentCoordinate;

            }
            else if (UpKeyPressed)
            {
                Animation.Location -= MoveUp;
            }

            //move down
            if (DownKeyPressed & (Animation.AnimationType != AnimationType.PacmanDown))
            {

                Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanDown);

                Animation.Location = CurrentCoordinate;

            }
            else if (DownKeyPressed)
            {
                Animation.Location += MoveDown;
            }
        }


    }
}

