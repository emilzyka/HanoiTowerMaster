namespace Brickleken
{
    /*interface IStack<T> where T : Bricka
    {
        //Towers are like stacks they follow "Last In - First out {LIFO} principle"
        public T Peek();
        public bool Push(Bricka input);
        public T Pop();

        //För generics och parametrisk polymorfism skulle fler typer än brickor kunna läggas på pinnarna
        //Olika typer t.ex. boll och triangle, skulle kunna ha lite olika förflyttningsegenskaper.
    }*/
    interface IPushBehavior
    {
        public bool Push(Bricka obj, int index, List<Bricka> lst, int maxSize);
    }
    
}