namespace FlightBookingSystem.Core.DataStructures
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEndOfWord;
        public string? FullName; 
    }
    public class MyTrie
    {
        private TrieNode root = new TrieNode();

        public void Insert(string airportCode, string FullName)
        {
            TrieNode current = root;
            foreach (char c in airportCode.ToUpper())
            {
                if (!char.IsLetter(c)) continue; 
                int index = c - 'A';
                if (current.Children[index] == null) current.Children[index] = new TrieNode();
                current = current.Children[index];
            }
            current.IsEndOfWord = true;
            current.FullName = FullName; 
        }

        public MyLinkedList<string> AutoComplete(string prefix)
        {
            MyLinkedList<string> results = new MyLinkedList<string>();
            TrieNode? current = root;

            foreach (char c in prefix.ToUpper())
            {
                if (!char.IsLetter(c)) continue;
                int index = c - 'A';
                if (current.Children[index] == null) return results;
                current = current.Children[index];
            }

            CollectWords(current, results);
            return results;
        }

        private void CollectWords(TrieNode node, MyLinkedList<string> results)
        {
            if (node.IsEndOfWord) results.AddLast(node.FullName!);
            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null) CollectWords(node.Children[i], results);
            }
        }
    }
}
