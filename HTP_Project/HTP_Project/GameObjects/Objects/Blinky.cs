using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Objects
{
    class Blinky : BaseGameObject
    {
        private DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }

        public Blinky() 
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);
            
        }

        public override void Update()
        {

            CurrentCoordinate = Animation.Location;

            if (DateTime.Now > threeSecondsLater)
            {
                Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);

                Animation.Location = CurrentCoordinate;
            }

        }
        public void MakeVulnerable()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;

        }
    }
}
