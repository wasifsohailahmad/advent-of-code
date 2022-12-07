using System.Diagnostics;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileContent = File.ReadAllText("input.txt");
            bool isUniqueStringPart1;
            int indexPart1 = 0;
            int indexPart2 = 0;

            indexPart1 = GetMarkerIndex(FileContent, 4);
            indexPart2 = GetMarkerIndex(FileContent, 14);

            Console.WriteLine("Part 1: "+ indexPart1 +" & Part 2: " + indexPart2);
        }

        public static bool IsUnique(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (d.ContainsKey(c))
                    return false;
                else
                    d.Add(c, 1);
            }
            return true;
        }

        public static int GetMarkerIndex(string inputText, int uniqueCharLength)
        {
            bool isUniqueString;
            int UniqueMarker=0;
            for (int i = 0; i < inputText.Length; i++)
            {
                isUniqueString = IsUnique(inputText.Substring(i, uniqueCharLength));
                if (isUniqueString)
                {
                    UniqueMarker = i + uniqueCharLength;
                    break;
                }

            }
            return UniqueMarker;
        }
    }
}