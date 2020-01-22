using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Blinky : BaseGameObject, IAntagonist
    {
        readonly Animation currentA;

        public bool IsVulnerable { get; set; }
        
        public Coordinate CurrentCoordinate { get; set; }

        public DateTime SecondsLater { get; set; }

        public Blinky()
        {
          currentA =  Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);
            
        }

        public override void Update()
        {
            if (DateTime.Now > SecondsLater)
            {
                IsVulnerable = false;

                Animation = currentA;

                CurrentCoordinate = Animation.Location;
            }
        }

        public void BecomeVulnerable()
        {

            IsVulnerable = true;

            SecondsLater = DateTime.Now.AddSeconds(7d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;


        }

        public void BecomeEyes()
        {

            
            SecondsLater = DateTime.Now.AddSeconds(7d);

            //becomes eyes oriented in direction were move to
            Animation = AnimationFactory.CreateAnimation(AnimationType.EyesLeft);

            Animation.Location = CurrentCoordinate;


        }



    }
}
