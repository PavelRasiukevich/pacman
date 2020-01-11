using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Blinky : BaseGameObject, IAntagonist
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
        
        public void BecomeVulnerable()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;
        }
    }
}
