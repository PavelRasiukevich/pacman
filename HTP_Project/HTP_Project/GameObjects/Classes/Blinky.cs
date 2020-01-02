using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.GameObjects.Classes
{
    class Blinky : BaseGameObject
    {
        private readonly string name = "Blinky";

        public Blinky()
        {

            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.BlinkyLeft);

            Animation.Location = new Coordinate(7f, 8f);
        }

        public override void Update()
        {
            
        }
    }
}
