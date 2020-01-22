namespace HTP_Project.GameObjects.Enemies.Interfaces
{
    interface IAntagonist
    {
        void BecomeVulnerable();

        bool IsVulnerable { get; set; } 
    }
}
