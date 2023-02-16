namespace Brickleken
{
    class PopFactory : IFactory<int, IPopBehavior>
    {
        //Use pattern matching to decide which behavior to create based on a command string 
        public IPopBehavior create(int command) =>
            command switch
        {
            1 => new AlwaysTruePopBehavior(),
            2 => new TwoFrontOneBackPopBehavior(),
            3 => new OneFrontTwoBackPopBehavior(),
            _ => throw new ArgumentException("Invalid value for pushbehavior") //discard pattern throws exception
        };

    }

}