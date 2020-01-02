using HTP_Project.GameObjects.Classes;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;

namespace HTP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Run(new IGameObject[] { new Background(), new Coin(), new Pacman() });


        }
    }
}
