using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Objects
{
    class Blinky : BaseGameObject
    {
        private DateTime threeSecondsLater;

        private readonly string name = "Blinky";

        public Coordinate CurrentCoordinate { get; set; }

        public Blinky()
        {

            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);

            Animation.Location = new Coordinate(7f, 8f);
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
            threeSecondsLater = DateTime.Now.AddSeconds(3);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;

        }
    }
}
