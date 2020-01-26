using HTP_Project.GameObjects.Enemies.Implementations;
using HTP_Project.GameObjects.StaticObjects;
using System;

namespace HTP_Project.GameObjects.Global
{
    class GrandArbiter 
    {

        public Background Maze { get; set; }

        public Blinky Blinky { get; set; }

        public Inky Inky { get; set; }

        public Pinky Pinky { get; set; }

        public Clyde Clyde { get; set; }
        
        public BigCoin BigCoin { get; set; }

        public DateTime CurrentTime { get; set; }

        //hold value of small coin eaten
        //public int Counter { get; set; }

        public GrandArbiter()
        {
           
        }

        
    }
}
