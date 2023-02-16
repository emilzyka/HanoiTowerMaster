namespace Brickleken
{
    class Configuration
    {
        /*
        The configuration arrays holds essential data for how the game should be generated. 
        Refer to the documentation below:

        numberConfig = 
        [
            0 = Number_towers, 
            1 = Number_bricks:
        ]

        towerAssembly: will always be of size Number_towers and represent which towers to create. Recommended is below
        [
            "1" => new OnePush(),
            "2" => new AleternatingPush(),
            "3" => new NormalPush(),

            3, 2, 1, 3
        ]

        brickAssembly: will always be of size Number_towers and represent which towers to create. Recommended is below
        [
            "1" => new AlwaysTruePopBehavior(),
            "2" => new TwoFrontOneBackPopBehavior(),
            "3" => new OneFrontTwoBackPopBehavior(),

            1, 2, 3, 1, 2, 3
        ]

        repConfig
        [
            0 = NPtower rep, default "NT", 
            1 = ALTower rep, default "AT", 
            2 = ONtower rep, default "OT"

            3 = Normalbrick rep, default "-", 
            4 = ballbrick rep default, "o", 
            5 = trianglebrick rep default, "x"
        ]
        */
        public int[] numberConfig = {4, 4};
        public int[] towerAssembly = {3, 2, 1, 3};
        public int[] brickAssembly = {1, 2, 3, 1};
        public string[] repConfig = {"NT", "AT", "OT", "-", "o", "x"};


        //FIXME: Write functions to be able to change the configurations arrays
        public void ChangeNumberConfig(int nt, int nb)//change number of towers and bricks
        {
            numberConfig[0] = nt;
            numberConfig[1] = nb;
        }

        public void changeTower(int[] newAssembly)
        {
            towerAssembly = newAssembly;       
        }

        public void changeBricks(int[] newAssembly)
        {
            brickAssembly = newAssembly;       
        }

        public void changeRep(int command, string newRep)
        {
            switch(command)
            {
                case 0:
                    repConfig[0] = newRep; //change rep of "NT"
                    break;
                case 1:
                    repConfig[1] = newRep; //"AT"
                    break;
                case 2:
                    repConfig[2] = newRep; //"OT"
                    break;
                case 3:
                    repConfig[3] = newRep; //"-"
                    break;
                case 4:
                    repConfig[4] = newRep; //"o"
                    break;
                case 5:
                    repConfig[5] = newRep; //"x"
                    break;
            }
        }

        public string CreateTowerRep(int command)
        {
            //The representation of a tower is decided based on its behavior
            switch(command)
            {
                case 1:
                    return repConfig[2]; //1 is OnePush which maps to repConfing index = 2
                case 2:
                    return repConfig[1];
                case 3:
                    return repConfig[0]; 
                default:
                    throw new ArgumentException("Invalid command value");
            }  
        }

        public string CreateBrickRep(int command, int size)
        {
             switch(command)
            {
                case 1:
                    return baseBrickRep(size, repConfig[3]); //AlwaysTrue maps to index = 3
                case 2:
                    return baseBrickRep(size, repConfig[4]); 
                case 3:
                    return baseBrickRep(size, repConfig[5]); 
                default:
                    throw new ArgumentException("Invalid command value");
            }  
        }

        public string baseBrickRep(int size, string input)
        {
            string baseString = "[";
            for (int i = 0; i < size; i++)
            {
                baseString += input;             
            }
            baseString += "]";
            return baseString;
        }

        public void TowerWrite(string rep)
        {
            //public string[] repConfig = {"NT", "AT", "OT" (...)}; 0, 1, 2,
            if(rep == repConfig[0]) 
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write(rep);
            }
            else if(rep == repConfig[1]) 
            {
                Console.ForegroundColor = ConsoleColor.Blue; //alternationtower yellow
                Console.Write(rep);
            }
            else if(rep == repConfig[2])
            { 
                Console.ForegroundColor = ConsoleColor.Magenta; //onepushtower magenta
                Console.Write(rep);
            }
        }

        public void TowerWriteMap(string rep)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.Write(rep);
        }

        public void PredeterminedConfigs(int command)
        {
            List<List<int>> nConfig = new List<List<int>>()
            {
                new List<int>{3, 3}, //normal tower of hanoi
                new List<int>{4, 4}, //vår egna
                new List<int>{4, 12}, //vår egna fast svår
            };

            List<List<int>> tConfig = new List<List<int>>()
            {
                new List<int>{3, 3, 3},
                new List<int>{3, 2, 1, 3},
                new List<int>{3, 2, 1, 3},
            };

            List<List<int>> bConfig = new List<List<int>>()
            {
                new List<int>{1, 1, 1},
                new List<int>{1, 2, 3, 1},
                new List<int>{1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3},
            };

            numberConfig = nConfig[command-1].ToArray();
            towerAssembly = tConfig[command-1].ToArray();
            brickAssembly = bConfig[command-1].ToArray();
        }
    }
}