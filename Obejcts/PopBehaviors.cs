namespace Brickleken
{
    class AlwaysTruePopBehavior : IPopBehavior
    {
        public bool ValidPop(int BrickX, StackTower des, int constDistTower) => true;
    }

    class TwoFrontOneBackPopBehavior : IPopBehavior //accepts movements of +2 and -1
    {
        public bool ValidPop(int BrickX, StackTower des, int constDistTower)   
        { 
            if(BrickX + constDistTower  * 2  == des.x) return true;
            else if(BrickX - constDistTower == des.x) return true;
            else return false;
        }    
    }
    class OneFrontTwoBackPopBehavior : IPopBehavior //accepts movements of +1 and -2
    {
        public bool ValidPop(int BrickX, StackTower des, int constDistTower) 
        { 
            if(BrickX + constDistTower == des.x) return true;
            else if(BrickX - constDistTower * 2 == des.x) return true;
            else return false;
        }    
    }
}