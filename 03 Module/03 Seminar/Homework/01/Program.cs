using System;

namespace _01
{
    class VetoEventArgs : EventArgs
    {
        public string Proposal { get; private set; }
        public VetoVoter VetoBy { get; set; }
        public VetoEventArgs(string proposal) { Proposal = proposal; }
    }

    class VetoVoter
    {
        public string Name { get; private set; }
        public void Veto(object sender, VetoEventArgs e)
        {
            Random rand = new Random();
            if (e.VetoBy == null && rand.Next(5) == 0)
                e.VetoBy = this;
        }
        public VetoVoter(string name) { Name = name; }
        public override string ToString() { return Name; }
    }

    class VetoComission
    {
        public event EventHandler<VetoEventArgs> OnVote;
        public VetoEventArgs Vote(string proposal)
        {
            VetoEventArgs veto = new VetoEventArgs(proposal);
            OnVote?.Invoke(this, veto);
            return veto;
        }
    }

    class Program
    {
        static void Main()
        {
            VetoComission comission = new VetoComission();
            VetoVoter[] voters = new VetoVoter[5];
            for (int i = 0; i < voters.Length; i++)
            {
                voters[i] = new VetoVoter($"Voter{i + 1}");
                comission.OnVote += voters[i].Veto;
            }
            VetoEventArgs veto = comission.Vote(Console.ReadLine());
            if (veto.VetoBy != null)
                Console.WriteLine($"Vetoed by {veto.VetoBy}");
            else
                Console.WriteLine("Not vetoed");
        }
    }
}
