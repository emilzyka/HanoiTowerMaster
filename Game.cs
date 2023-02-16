using System.Linq;

namespace Brickleken
{
    class Game
    {
        List<StackTower> towers;
        List<Bricka> bricks;
        Configuration config;
        UserSettings us;
        UserInput ui;
        TrackScore ts; 
        Instructions i;
        IFactory<Configuration, List<StackTower>> towerfactory;
        IFactory<Configuration, List<Bricka>> brickfactory;

        public Game(Configuration config, UserSettings us, UserInput ui, TrackScore ts, Instructions i, 
        IFactory<Configuration, List<StackTower>> towerfactory,
        IFactory<Configuration, List<Bricka>> brickfactory)
        {
            this.config = config;
            this.us = us;
            this.ui = ui;
            this.ts = ts;
            this.i = i;
            this.towerfactory = towerfactory;
            this.brickfactory = brickfactory;
            towers = towerfactory.create(config); //factory method, we inject factory and decide how the towers will be created based on config
            bricks = brickfactory.create(config);
        }

        public void OnStartUp()
        {
            i.PrintInstructions();
        }
        public void Play()
        { 
            
            settings();           
            for (int i = bricks.Count - 1; i >= 0; i--)
            {
                towers[0].Push(bricks[i]);
            }
            Draw();
            
            int moves = 0;
            while(towers[towers.Count()-1].bricks.Count() != config.numberConfig[1])
            {
                ui.ntower = config.numberConfig[0]; //updates userinput with correct data for number of towers
                Console.WriteLine();
                (int, int) move = ui.GetUserInput();
                if(towers[move.Item1].PopPush(towers[move.Item2])) moves++;
                Draw();
                Console.WriteLine($"\n\nCurrent moves: {moves}");

            }
            Console.WriteLine();
            Console.WriteLine($"Congratulations you win!\nYou solved the game in {moves} moves");
            Console.WriteLine("Enter your username to save your score!");
            
            string? name = Console.ReadLine();
            if(name != null) ts.AddScore(moves, name);
            ts.getHighScore();
            
            Console.WriteLine("Do you want to play again? Y/N");
            ConsoleKeyInfo key = Console.ReadKey();
            if(key.Key.ToString().ToUpper() == "Y") Play();
        }

        private void settings()
        {
            us.UpdateSettings();
            towers = towerfactory.create(config);
            bricks = brickfactory.create(config);
        }

        private void Draw()
        {
            Console.Clear();
            towers.ForEach(x => x.DrawObjects()); //linq
        }
    }
    
}