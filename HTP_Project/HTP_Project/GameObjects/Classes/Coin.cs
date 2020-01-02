using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.Classes
{
    class Coin : BaseGameObject
    {
        private readonly string name = "Coin";

        public Coin()
        {

            Name = name;

            Animation = AnimationFactory.CreateAnimation(AnimationType.SmallCoin);

            Animation.Location = new Coordinate(1, 1);
          
        }

        public override void Update()
        {
            
        }
    }
}
