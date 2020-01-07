using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;
using System;

namespace HTP_Project.GameObjects.Objects
{
    class BigCoin : BaseGameObject
    {
        private DateTime threeSecondsLater;

        public Coordinate CurrentCoordinate { get; set; }

        private readonly string name = "BigCoin";

        public BigCoin()
        {
            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);

            Animation.Location = new Coordinate(10, 10);
        }

        public override void Update()
        {

            if (DateTime.Now > threeSecondsLater)
            {
                //doesen't work
                //doesen't appear after 5 seconds
                IsEnabled = true;
                
            }
        }

        public void SpawnBigCoin()
        {
            threeSecondsLater = DateTime.Now.AddSeconds(5d);

            //works
            IsEnabled = false;
        }
    }
}
