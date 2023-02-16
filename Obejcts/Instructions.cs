namespace Brickleken
{
    class Instructions
    {
        public void PrintInstructions()
        {
            string fstexplanation = @"

                The goal of the game is very simple. You have to move all bricks from the starting tower 
                to the final tower. However, you can only move the topmost brick of the tower. You do 
                this by selecting a tower to move the topmost brick FROM, 
                and then selecing a tower to move the brick TO. 
            ";
                
            string important = @"   
            
                IMPORTANT, below you can see the how the key input maps to the different tower. You can at most play with 8 towers.
                Meaning towers are always accessed by pressing a button from 'q' to 'i' 
                
                                    T1  T2  T3  T4  T5  T6  T7  T8
                                    
                                    ^   ^   ^   ^   ^   ^   ^   ^
                                    |   |   |   |   |   |   |   |
                                    |   |   |   |   |   |   |   |
                                        
                                    Q   W   E   R   T   Y   U   I
                
            ";
            string sndexplanation = @" 
                There are three types of towers in the game:
            
                A Nomral tower, by default represented with 'NT', which behaves such that it only accepts smaller bircks on top of a larger brick.
                A Alternating tower, by default represented with 'AT'. which behaves such that it alternates between accepting a larger on smaller and smaller on larger.
                A One tower, by default represented with 'OT', which behaves such that it can at most take one brick.

                There are three types of bricks in the game: 
                
                A Normal brick, by default represented with '-', can move anywhere.
                A Ball brick, by default represented with 'o', can move two steps ahead but only one step back.  
                A Triangle brick, by default represented with 'x', can move one step ahead and two steps back.       
            ";

            Console.WriteLine(fstexplanation);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(important);
            Console.ResetColor();
            Continue();
            Console.WriteLine(sndexplanation);
            Continue();

        }

        private void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();  
            Console.Clear();
        }
    }    
}