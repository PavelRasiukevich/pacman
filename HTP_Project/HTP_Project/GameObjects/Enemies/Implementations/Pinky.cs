using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Pinky : BaseGameObject
    {
        public Pinky()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.PinkyLeft);
        }
    }
}
