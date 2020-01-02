using HTP_Project.GameObjects.BaseObjects;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.Classes
{
    class Background : BaseGameObject
    {
        public Background()
        {
           
            Animation = AnimationFactory.CreateAnimation(AnimationType.MazeBlue);
        }

        public override void Update()
        {

        }
    }
}
