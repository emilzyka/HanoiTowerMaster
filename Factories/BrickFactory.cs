namespace Brickleken
{
    class BrickFactory : IFactory<Configuration, List<Bricka>>
    {
        public List<Bricka> create(Configuration config)
        {
            IFactory<int, IPopBehavior> popfactory = new PopFactory();
            List<Bricka> lst = new List<Bricka>();

            int size = 2;
            for (int i = 0; i < config.brickAssembly.Length; i++)
            {
                lst.Add(new Bricka(size, 
                config.CreateBrickRep(config.brickAssembly[i], size), 
                popfactory, 
                config.brickAssembly[i]));
                size+=2;
            }
            return lst;
        }
    }
}