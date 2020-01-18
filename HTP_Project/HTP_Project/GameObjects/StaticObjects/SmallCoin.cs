using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.StaticObjects
{
    class SmallCoin : BaseGameObject
    {
        public SmallCoin()

        {
            Animation = AnimationFactory.CreateAnimation(AnimationType.SmallCoin);
        }

        public override void Update()

        {

        }
    }
}
