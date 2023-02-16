namespace Brickleken
{
    class Program
    {
        static void Main(string[] args)
        {   
            Configuration c = new Configuration();
            Game g = new Game(c, 
            new UserSettings(c),
            new UserInput(0), 
            new TrackScore(), 
            new Instructions(),
            new TowerFactory(),
            new BrickFactory());
            g.OnStartUp();
            g.Play();
        }
    }
     
}