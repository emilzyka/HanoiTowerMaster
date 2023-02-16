namespace Brickleken
{
    class PushFactory : IFactory<int, IPushBehavior> 
    {
        //Use pattern matching to decide which behavior to create based on a command string 
        public IPushBehavior create(int command) =>
            command switch
        {
            1 => new OnePush(),
            2 => new AleternatingPush(),
            3 => new NormalPush(),
            _ => throw new ArgumentException("Invalid value for pushbehavior") //discard pattern throws exception
        };
    }
}