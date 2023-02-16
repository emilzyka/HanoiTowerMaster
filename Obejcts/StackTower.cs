using System.Linq;

namespace Brickleken 
{
    class StackTower 
    {        
        public List<Bricka> bricks {get; private set;} //List of object placed ontop of tower
        IPushBehavior pushbehavior; //Defines how the tower accepts new objects ontop of itself
        public int x {get; private set;} 
        public int y {get; private set;} 
        public int constDist; //constant distance between towers
        public int maxSize {get; private set;} //maxSize of the tower
        public int i {get; private set;} //tracks current top element in List<bricks>, bricks.length > i >= -1
        string rep; //how the "tower" is represented in the console
        Action<string> towerWrite;
        public StackTower(int x, int y, string rep, List<Bricka> bricks, IFactory<int, IPushBehavior> factory, int command, 
        Action<string> towerWrite)       
        {
            this.x = (x*2+2)/2;
            this.y = y; 
            this.constDist = y * 2 + 3; //formula to get constant distance
            this.rep = rep;
            this.bricks = bricks;
            this.i = -1;
            this.maxSize = y - 1; //Y is always the number of obj in play therefore we can use it to decide upon maxSize
            this.pushbehavior = factory.create(command); //FIXME: Vi använder en factory för att skapa en pushbehavior.
            this.towerWrite = towerWrite;                  
        }

        public Bricka Peek()
        {
            return bricks[i]; //returns the rightmost element of brick collection
        }
        public bool Push(Bricka b)
        {
            if(pushbehavior.Push(b, i, bricks, maxSize)) //Utnyttjar dynamic dispatch för att avgöra vilken implementation av Push som kommer anropas under körtid
            {
                i++;
                bricks.Add(b);
                return true;
            }
            return false;
        }

        public Bricka Pop()
        {
            Bricka b = Peek();
            return b;
        }

        public bool PopPush(StackTower des)
        {
            if(i == -1) return false;
            Bricka b = Peek();
            int towerBrickX = b.x + (b.size / 2); //tower.x = brick x + (brick.size / 2)
            if(b.popBehavior.ValidPop(towerBrickX, des, constDist))
            {
                if(des.Push(b))
                {
                    bricks.RemoveAt(i);
                    i--;
                    return true;
                }
            }
            return false;
        } 

        public void DrawObjects()
        {
            int tmpY = y;
            foreach (var item in bricks)
            {
                item.updatePos(x - (item.size / 2), tmpY - 1); //x
                try
                {
                    Console.SetCursorPosition(item.x, item.y);
                }
                catch(SystemException)
                { 
                    throw new ArgumentOutOfRangeException("Terminal buffer size to small. Please make terminal window larger");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(item.rep);
                tmpY--;
            }
            Console.SetCursorPosition(x, y);
            towerWrite(rep);
            Console.ResetColor();
        }
    }
}