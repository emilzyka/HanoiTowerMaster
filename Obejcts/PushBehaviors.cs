namespace Brickleken
{
    class NormalPush : IPushBehavior //Normal pushbehavior only smaller on larger accepted
    {
        public bool Push(Bricka input, int index, List<Bricka> lst, int maxSize) 
        {
            if(index + 1 == 0 || lst[index].size > input.size && index < maxSize){
                return true;
            }
            else return false; 
        }
    }
    class AleternatingPush : IPushBehavior //Alternating pushbehavior smaller on larger, then larger on smallet and so on...
    {
        public bool Push(Bricka input, int index, List<Bricka> lst, int maxSize) 
        {
            if(index + 1 == 0 || index + 1 == 1) //tower has less than two objects we can just add
            {
                return true;
            }
            else if(lst[index-1].size > lst[index].size) //smaller on larger
            {
                if(input.size > lst[index].size) //accept larger on smaller
                {
                    return true;
                } 
                else return false; 
            }
            else if(lst[index-1].size < lst[index].size) //larger on smaller
            {
                if(input.size < lst[index].size) //accept smaller on larger
                {
                    return true;
                } 
                else return false; 
            } 
            return false;
        }
    }   
    class OnePush : IPushBehavior
    {
        public bool Push(Bricka input, int index, List<Bricka> lst, int maxSize)
        {
            if(index == 0) return false;
            else return true;
        }
    }
    

}