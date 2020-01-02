using HTP_Project.GameObjects.Objects;
using HTP_Project.GameObjects.CollectionOfObjects;
using PacmanEngine.Components.Actors;
using PacmanEngine.Components.Base;

namespace HTP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Run(ObjectCollection.CreateObjects());


        }
    }
}
