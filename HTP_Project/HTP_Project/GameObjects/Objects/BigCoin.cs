using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Objects
{
    class BigCoin : BaseGameObject
    {
        DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }
        
        public BigCoin()
        {
            
            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);
        }

        public override void Update()
        {

            if (DateTime.Now > threeSecondsLater)
            {
                SpawnBigCoin();
            }
        }

        private void SpawnBigCoin()
        {
            //works
            IsEnabled = true;
        }

        public void GetTime()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(3d);

            IsEnabled = false;
        }
    }
}
