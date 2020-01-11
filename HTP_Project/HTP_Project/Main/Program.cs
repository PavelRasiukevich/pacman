using HTP_Project.CollectionInitializator;
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
