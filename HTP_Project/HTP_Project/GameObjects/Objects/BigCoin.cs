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

        private readonly string name = "BigCoin";

        public BigCoin()
        {
            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);

            Animation.Location = new Coordinate(10, 10);
        }

        public override void Update()
        {

            if (DateTime.Now.CompareTo(threeSecondsLater) == 0)
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
