using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.StaticObjects
{
    class Background : BaseGameObject
    {
      
        private DateTime threeSecondsLater;

        private Animation whiteMaze = AnimationFactory.CreateAnimation(AnimationType.MazeWhite);

        public Background()
        {

            
        }

        public override void Update()
        {
            if(DateTime.Now > threeSecondsLater)
            {
                Animation = AnimationFactory.CreateAnimation(AnimationType.MazeBlue);
            }
        }

        public void ChangeFromBlueToWhite()
        {

            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = whiteMaze;


        }
    }
}
