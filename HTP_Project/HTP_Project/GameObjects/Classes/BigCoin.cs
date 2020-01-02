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
    class BigCoin : BaseGameObject
    {
        private readonly string name = "BigCoin";

        public BigCoin()
        {
            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);

            Animation.Location = new Coordinate(10, 10);
        }

        public override void Update()
        {
            
        }
    }
}
