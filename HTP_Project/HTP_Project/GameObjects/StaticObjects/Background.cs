using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.StaticObjects
{
    class Background : BaseGameObject
    {
      
        private DateTime SecondsLater;

        private Animation whiteMaze = AnimationFactory.CreateAnimation(AnimationType.MazeWhite);

        public Background()
        {

            
        }

        public override void Update()
        {
            if(DateTime.Now > SecondsLater)
            {
                Animation = AnimationFactory.CreateAnimation(AnimationType.MazeBlue);
            }
        }

        public void ChangeFromBlueToWhite()
        {

            SecondsLater = DateTime.Now.AddSeconds(5d);

            Animation = whiteMaze;


        }
    }
}
