using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.Classes
{
    class Coin : BaseGameObject
    {

        public Coin()
        {
          
            Animation = AnimationFactory.CreateAnimation(AnimationType.SmallCoin);

            Animation.Location = new Coordinate(1, 1);
          
        }

        public override void Update()
        {
            
        }
    }
}
