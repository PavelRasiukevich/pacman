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
        
        //...
        private DirectionKeys CurrentDirection = DirectionKeys.None;

        

        public  float Speed { get; set; } = 0.1f;

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

            if((PressedKeys & DirectionKeys.Right) == DirectionKeys.Right)
            {
                newDirection = DirectionKeys.Right;
            }
            else if ((PressedKeys & DirectionKeys.Left) == DirectionKeys.Left)
            {
                newDirection = DirectionKeys.Left;
            }
            else if((PressedKeys & DirectionKeys.Up) == DirectionKeys.Up)
            {
                newDirection = DirectionKeys.Up;
            }
           else if ((PressedKeys & DirectionKeys.Down) == DirectionKeys.Down)
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
                        Animation.Location += new Coordinate(Speed, 0.0f);
                        break;
                    case DirectionKeys.Left:
                        Animation.Location -= new Coordinate(Speed, 0.0f);
                        break;
                    case DirectionKeys.Up:
                        Animation.Location -= new Coordinate(0.0f, Speed);
                        break;
                    case DirectionKeys.Down:
                        Animation.Location += new Coordinate(0.0f, Speed);
                        break;
                }
            


           // var MoveRight = new Coordinate(0.1f, 0f);
            //var MoveLeft = MoveRight;

            //var MoveUp = new Coordinate(0f, 0.1f);
            //var MoveDown = MoveUp;

           // Move(MoveRight, MoveLeft, MoveUp, MoveDown);

        }

       /* private void Move(Coordinate MoveRight, Coordinate MoveLeft, Coordinate MoveUp, Coordinate MoveDown)
        {
            //represents current location
            CurrentCoordinate = Animation.Location;

            bool RightKeyPressed = (PressedKeys & DirectionKeys.Right) == DirectionKeys.Right;
            bool LeftKeyPressed = (PressedKeys & DirectionKeys.Left) == DirectionKeys.Left;
            bool UpKeyPressed = (PressedKeys & DirectionKeys.Up) == DirectionKeys.Up;
            bool DownKeyPressed = (PressedKeys & DirectionKeys.Down) == DirectionKeys.Down;

            //MoveAlongAxis_X(MoveRight, RightKeyPressed, LeftKeyPressed);

            //MoveAlongAxis_Y(MoveUp, UpKeyPressed, DownKeyPressed);
        }*/

        /*private void MoveAlongAxis_X(Coordinate MoveRight, bool RightKeyPressed, bool LeftKeyPressed)
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
        }*/


    }
}

