using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Inky : BaseGameObject
    {
        public Inky()
        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.InkyLeft);
        }
    }
}
