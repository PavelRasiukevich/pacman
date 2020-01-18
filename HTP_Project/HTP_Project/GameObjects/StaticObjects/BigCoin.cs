using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.StaticObjects
{
    class BigCoin : BaseGameObject
    {

        public Coordinate CurrentCoordinate { get; set; }
        
        public BigCoin()
        {
            
            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);
        }
       
    }
}
