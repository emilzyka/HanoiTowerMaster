namespace Brickleken
{
    class Bricka
    {
        public int size {get; private set;}
        public int x {get; private set;}
        public int y {get; private set;}
        public IPopBehavior popBehavior {get; private set;}
        public string rep {get; private set;} //how the brick will be represented in the console

        public Bricka(int size, string rep, IFactory<int, IPopBehavior> factory, int command)
        {
            this.size = size;
            this.popBehavior = factory.create(command); //FIXME: abstract-injicerad objektkomposition 
            this.rep = rep;
        }
        public void updatePos(int x, int y) //updates postion of brick 
        {
            this.x = x;
            this.y = y;
        }
        //
    }
}