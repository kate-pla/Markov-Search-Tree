

/*
* Markov Text Generation 
* Create a story
*
*file: MarkovSearchTree.cs
* author: Dylan Fox, Teagan Algarra, Madeline Stokes, Kate Pla
*/
using System.Linq;
    using System.Text.RegularExpressions;
    using TreeSymbolTable;

    public class MarkovEntry
    {
        private TreeSymbolTable<string, int> nextWords;
        private string root;
        private int count;
        private Random rng;
 
        public MarkovEntry(string root)
        {

            this.root = root;
            count = 0;
            nextWords = new TreeSymbolTable<string, int>();
            rng = new Random();
        }
        public void Add(string str)
        {
            if (nextWords.Contains(str))
            {
                nextWords[str]++;
            }
            else
            {
                nextWords.Add(str, 1);
            }
            count++;
        }

        public string RandomWord()
        {
            int index = rng.Next(count);
            return nextWords.ElementAt(index);
        }

        public string WeightedRandomWord()
        {
            List<string> options = new List<string>();

            foreach (string pair in nextWords)
            {
                for (int x = 0; x < count; x++)
                {
                    options.Add(pair);
                }
            }

            int index = rng.Next(options.Count);

            return options[index];
        }
     
    public override string ToString()
    {
        string output = $"'{root}' ({count}) : ";

        foreach (string pair in nextWords)
        {
            output += $"'{pair}' {count}, ";
        }

        return output;
    }
}
