using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Pinky : BaseGameObject, IAntagonist

    {

        private DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }

        public Pinky()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.PinkyLeft);
        }

        public void BecomeVulnerable()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;
        }
    }
}
