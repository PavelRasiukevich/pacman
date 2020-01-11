using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Clyde : BaseGameObject, IAntagonist

    {

        private DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }

        public Clyde()
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.ClydeLeft);

        }

        public void BecomeVulnerable()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;
        }

    }
}
