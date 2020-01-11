using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Inky : BaseGameObject, IAntagonist
    {

        private DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }

        public Inky()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.InkyLeft);
        }

        public void BecomeVulnerable()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;
        }
    }
}
