using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System.Collections.Generic;

namespace HTP_Project.GameObjects.Classes
{
    class Pacman : BaseGameObject, IProtagonist
    {
        

        public Pacman()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.PacmanRight);

            Animation.Location = new Coordinate(0.5f, 13f);
           

        }

        public DirectionKeys PressedKeys { get; set; }

        public void Collide(IEnumerable<IGameObject> collisions)
        {
            foreach (var obj in collisions)
            {
                switch (obj.Name)
                {
                    case "BigCoin":
                        obj.IsEnabled = false;
                        break;
                    
                }
               
                   
                
            }
        }

        public override void Update()
        {
         

            var MoveRight = new Coordinate(0.1f, 0.0f);
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

            if (RightKeyPressed)
            {
                Animation.Location += MoveRight;
            }

            if (LeftKeyPressed)
            {

                Animation.Location -= MoveLeft;
            }

            if (UpKeyPressed)
            {
                Animation.Location -= MoveUp;
            }

            if (DownKeyPressed)
            {
                Animation.Location += MoveDown;
            }
        }
    }
}
