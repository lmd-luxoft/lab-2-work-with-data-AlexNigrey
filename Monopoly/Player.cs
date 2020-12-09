
namespace Monopoly
{
    class Player
    {
        public Player(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }

        public string Name { get; private set; }

        public int Cash { get; private set; }

        public void Pay(int cash) => Cash -= cash;

        public void Sell(int cash) => Cash += cash;
    }
}
