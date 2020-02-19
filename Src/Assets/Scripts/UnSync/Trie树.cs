public class TrieNode
{
    public char data;
    public TrieNode[] children = new TrieNode[26];
    public bool isEndingChar = false;

    public TrieNode(char data)
    {
        this.data = data;
    }
}

public class Trie
{
    private TrieNode root = new TrieNode('/');

    public void Insert(char[] text)
    {
        var p = root;
        for (int i = 0; i < text.Length; i++)
        {
            var index = text[i] - 'a';
            if (p.children[index] == null)
            {
                var newNode = new TrieNode(text[i]);
                p.children[index] = newNode;
            }

            p = p.children[index];
        }

        p.isEndingChar = true;
    }

    public bool Find(char[] pattern)
    {
        var p = root;
        for (int i = 0; i < pattern.Length; i++)
        {
            var index = pattern[i] - 'a';
            if (p.children[index] == null)
            {
                return false;
            }

            p = p.children[index];
        }

        if (p.isEndingChar == false)
        {
            return false; // 不能完全匹配，只是前缀  
        }
        else
        {
            return true;
        }
    }
}