using HTP_Project.CollectionInitializer;
using PacmanEngine.Components.Base;

namespace HTP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Run(ObjectCollection.InitCollection());
        }

    }
}
