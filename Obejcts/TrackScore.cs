namespace Brickleken
{
    class TrackScore
    {
        List<Score> lst = new List<Score>();
        public void AddScore(int moves, string username)
        {
            lst.Add(new Score(moves, username));
        }

        public void getHighScore()
        {
            var t = lst.Where(s => s.moves == lst.Min(s => s.moves)); //using linq and lambda
            
            foreach (var item in t)
            {
                Console.Clear();
                Console.WriteLine($"Best score: {item.moves}, by user: {item.username}");
            }
        }
    }
}