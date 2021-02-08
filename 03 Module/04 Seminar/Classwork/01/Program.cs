using System;

namespace _01
{
    public class PlayIsStartedEventArgs : EventArgs
    {
        public int NumberOfComposition { get; private set; }
        public PlayIsStartedEventArgs(int n)
        {
            NumberOfComposition = n;
        }
    }

    class BandMaster
    {
        public event EventHandler<PlayIsStartedEventArgs> PlayIsStartedEvent;
        public void StartPlay(int n)
        {
            PlayIsStartedEvent?.Invoke(this, new PlayIsStartedEventArgs(n));
        }
    }

    abstract public class OrchestraPlayer
    {
        public string Name { get; set; }
        public OrchestraPlayer(string name) { Name = name; }
        public abstract void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e);
    }

    internal class Violinist : OrchestraPlayer
    {
        public Violinist(string name) : base(name) { }
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"Violinist {Name} plays composition #{e.NumberOfComposition}: La-la!");
        }
    }

    internal class Hornist : OrchestraPlayer
    {
        public Hornist(string name) : base(name) { }
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"Hornist {Name} plays composition #{e.NumberOfComposition}: Du-du-du!");
        }
    }

    class Program
    {
        public static Random rand = new Random();
        static void Main()
        {
            BandMaster master = new BandMaster();
            OrchestraPlayer[] orc = new OrchestraPlayer[10];
            for (int i = 0; i < orc.Length; i++)
            {
                if (rand.Next(2) == 0)
                    orc[i] = new Violinist($"P{i}");
                else
                    orc[i] = new Hornist($"P{i}");
                master.PlayIsStartedEvent += orc[i].PlayIsStartedEventHandler;
            }
            int numberOfCompositions = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCompositions; i++)
            {
                int composition = rand.Next(2, 6);
                Console.WriteLine($"\nComposition {composition} started!");
                master.StartPlay(composition);
            }
        }
    }
}
