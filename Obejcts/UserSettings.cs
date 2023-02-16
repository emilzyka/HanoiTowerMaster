namespace Brickleken
{
    class UserSettings
    {
        Configuration config;
        public UserSettings(Configuration config) => this.config = config;

        public void UpdateSettings()
        {
            Console.Clear();
            Console.WriteLine("If it's your first time playing we recommend not changing the settings");
            if(DoMore("Do you want to change the settings for the game? Y/N"))
            {
                updateNumberConfig();
                updateTowers();
                updateBricks();
                Console.Clear();
                if(DoMore("Do you want to change the represenation of towers and bricks? Y/N")) updateRep();
            }
            else
            {
                Console.WriteLine("Please select one of the preconfigured game modes");
                GameModes();
            }
        }

        public void updateNumberConfig()
        {
            int[] val = {0, 0};
            int x = 0;
            int high = 9;
            string[] text = 
            {"towers", "bricks", "Max is: 8\nMin is: 3", "Max is: 12\nMin is: 3"};
            
            while(x <= 1)
            {
                Console.Clear();
                Console.WriteLine($"Enter how many {text[x]} you want to play with: ");
                Console.WriteLine($"{text[x+2]}");
                if(int.TryParse(Console.ReadLine(), out int number) && number > 2 && number < high) 
                {
                    val[x] = number;
                    x++;
                    high += 4;
                }
                else Console.WriteLine("Invalid input please try again");

            }
            config.ChangeNumberConfig(val[0], val[1]);
        }

        public void updateTowers()
        {
            
            int[] output = new int[config.numberConfig[0]]; //length of towers in play
            output[0] = 3;
            Console.Clear();
            Console.WriteLine("First and last towers are always 'Normal Towers' but you are free to change the towers inbetween");
            Console.WriteLine("To change tower simply press 1, 2 or 3 based on which tower you desire...");
            Console.WriteLine("1 => One Tower \n2 => Alternating Tower\n3 => Normal Tower");
            
            int x = 1; 
            while(x < output.Length - 1)
            {
                Console.WriteLine($"Enter a number to decide which tower the {x+1} tower should be: ");
                if(int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < 4) 
                {
                    output[x] = number;
                    x++;
                }
                else Console.WriteLine("Invalid input please try again");
            }
            output[output.Length - 1] = 3;
            config.changeTower(output);
        }

        public void updateBricks()
        {
            int[] output = new int[config.numberConfig[1]]; //length of bricks in play
            Console.Clear();
            Console.WriteLine("To change brick simply press 1, 2 or 3 based on which brick you desire...");
            Console.WriteLine("1 => Normal Brick (can move anywhere)\n2 => Ball brick (can move 2 front 1 back)\n3 => Triangle Brick(can move 1 front 2 back)");
            
            int x = 0; 
            while(x < output.Length)
            {
                Console.WriteLine($"Enter a number to decide which brick the {x+1} should be: ");
                if(int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < 4) 
                {
                    output[x] = number;
                    x++;
                }
                else Console.WriteLine("Invalid input please try again");
            }
            config.changeBricks(output);
        }

        public void updateRep()
        {
            string mapping = @"
NT  AT  OT  -   o   x 

^   ^   ^   ^   ^   ^
|   |   |   |   |   |
|   |   |   |   |   |
    
0   1   2   3   4   5
";          
            Console.Clear();
            Console.WriteLine("Enter a number to select which representation to change, refer to the scheme below:");
            Console.WriteLine("Tower represenations can only be 2 characters.\nBrick represenatations can only be 1 character:");
            Console.WriteLine(mapping);
            
            do
            {
                Console.WriteLine("Enter a number");
                if(int.TryParse(Console.ReadLine(), out int number) && number >= 0 && number < 6)
                {
                    int x = 1;
                    if(number >= 0 && number < 3) x = 2;
                    Console.WriteLine("Enter a new represenation:");
                    string? s = Console.ReadLine(); 
                    if(s != null && s.Length == x)
                    {
                        config.changeRep(number, s);
                        Console.Clear();
                        Console.WriteLine("Successfully changed representation");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid representation");
                    }
                }
                else Console.WriteLine("Invalid input please try again");
            }while(DoMore("Do you want to change something else Y/N"));

        }
        private void GameModes()
        {
            Console.Clear();
            Console.WriteLine("Enter: 1 for Normal 'Towers of Hanoi'\n\nEnter: 2 for Challange mode\n\nEnter: 3 for Expert mode");
            
            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < 4)
                {
                   config.PredeterminedConfigs(number);
                   break; 
                }
                else Console.WriteLine("Invalid input, enter a number between 1-3"); 
            }
        }
        private bool DoMore(string str)
        {
            Console.WriteLine(str);
            ConsoleKeyInfo key = Console.ReadKey();
            if(key.Key.ToString().ToUpper() == "Y") return true;
            return false;
        }
    }
}       