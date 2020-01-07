using HTP_Project.GameObjects.CollectionOfObjects;
using HTP_Project.GameObjects.Objects;
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
