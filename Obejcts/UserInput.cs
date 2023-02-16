namespace Brickleken
{
    class UserInput
    {
        public int ntower;

        public UserInput(int ntower) => this.ntower = ntower;
        private ConsoleKey takeUserKey()
        {
            ConsoleKeyInfo input;           
            input = Console.ReadKey(true);
            return input.Key;
        }

        private int isValidKey(ConsoleKey key)
        {
            int tmp = 0;
            if(key == ConsoleKey.Q && tmp < ntower){
                return 0;
            }tmp++;
            if(key == ConsoleKey.W && tmp < ntower){
                return 1;
            }tmp++;
            if(key == ConsoleKey.E && tmp < ntower){
                return 2;
            }tmp++;
            if(key == ConsoleKey.R && tmp < ntower){
                return 3;
            }tmp++;
            if(key == ConsoleKey.T && tmp < ntower){
                return 4;
            }tmp++;
            if(key == ConsoleKey.Y && tmp < ntower){
                return 5;
            }tmp++;
            if(key == ConsoleKey.U && tmp < ntower){
                return 6;
            }tmp++;
            if(key == ConsoleKey.I && tmp < ntower){
                return 7;
            }tmp++;
            return -1;
        }

        private int GetOneKey() //get a valid input from user or exit environment
        {
            ConsoleKey key1 = takeUserKey();
            while(isValidKey(key1) == -1)
            {
                if(key1 == ConsoleKey.Escape) Environment.Exit(0);
                key1 = takeUserKey();
                Console.WriteLine("Invalid key please try again.");

            };
            return isValidKey(key1);
        }
    
        public (int, int) GetUserInput() //gets a valid tower to pop and a valid tower to push
        {
            Console.WriteLine("Press Esc to exit.");
            Console.WriteLine("Select a tower you want to move a brick from:");
            int start = GetOneKey();
            Console.WriteLine("Select a destination tower:");
            int des = GetOneKey();
            return (start, des);
        }

    }
}