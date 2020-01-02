using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.Objects
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
