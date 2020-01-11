using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.Enemies.Implementations
{
    class Clyde : BaseGameObject
    {
        public Clyde()
        {

            Animation = AnimationFactory.CreateAnimation(AnimationType.ClydeLeft);

        }
    }
}
