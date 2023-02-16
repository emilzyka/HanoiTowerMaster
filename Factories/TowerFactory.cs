namespace Brickleken
{
    class TowerFactory : IFactory<Configuration, List<StackTower>>
    {
        public List<StackTower> create(Configuration config)
        {
            IFactory<int, IPushBehavior> pushfactory = new PushFactory();
            List<StackTower> lst = new List<StackTower>(); //List of all towers

             //first tower has to be created differently
            lst.Add(new StackTower(config.numberConfig[1], 
                config.numberConfig[1], 
               config.CreateTowerRep(config.towerAssembly[0]), 
                new List<Bricka>(), 
                pushfactory, config.towerAssembly[0], config.TowerWrite));

            //create remaining towers
            for (int i = 1; i < config.towerAssembly.Length; i++)
            {   
                lst.Add(new StackTower(Dist(lst[i-1], config.numberConfig[1]), 
                config.numberConfig[1], 
                config.CreateTowerRep(config.towerAssembly[i]), 
                new List<Bricka>(), 
                pushfactory, config.towerAssembly[i], config.TowerWrite));
            }
            return lst;
        }

        private int Dist(StackTower tower, int nBricks) //calculates correct distance between towers
        {
            int tmp = (tower.x + 1) + ((nBricks * 2) + 2);
            return (tmp * 2 - 2) / 2;
        }

    }
}