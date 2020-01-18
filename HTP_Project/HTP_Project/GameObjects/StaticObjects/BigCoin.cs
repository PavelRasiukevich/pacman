using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Base;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.StaticObjects
{
    class BigCoin : BaseGameObject
    {
        public BigCoin()
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.BigCoin);
        }

        public override void Update()

        {

        }

    }
}
