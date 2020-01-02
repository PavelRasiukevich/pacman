using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Graphics;

namespace HTP_Project.GameObjects.BaseObjects
{
   public abstract class BaseGameObject : IGameObject
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; } = true;

        public Animation Animation { get; set; }

        public abstract void Update();
    }
}
