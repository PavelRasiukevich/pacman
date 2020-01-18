using HTP_Project.GameObjects.BaseObjects;
using HTP_Project.GameObjects.Enemies.Interfaces;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Blinky : BaseGameObject, IAntagonist
    {
       
        public Coordinate CurrentCoordinate { get; set; }

        public Blinky() 
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);
            
        }

        public void BecomeVulnerable()
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlueGhost);

            Animation.Location = CurrentCoordinate;
        }
    }
}
