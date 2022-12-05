using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> FileContent = File.ReadAllLines("Input.txt").ToList();

            var maximum = FileContent.Select(e => e.Count(ee => ee == '[')).DefaultIfEmpty().Max();
            List<List<string>> listsStack = new List<List<string>>();
            List<List<string>> listsStackPart2 = new List<List<string>>();

            for (int z = 0; z < maximum; z++)
            {
                listsStack.Add(new List<string>());
                listsStackPart2.Add(new List<string>());
            }
            
            int startIndexForInstructions = 0;
            startIndexForInstructions = FileContent.FindIndex(s => String.IsNullOrWhiteSpace(s));
            listsStack = GetStacks(listsStack,FileContent);
            string resultPart1 = ArrangeForPart1(listsStack, FileContent);
            resultPart1 = resultPart1.Replace("[", "").Replace("]", "");
            Console.WriteLine("Part 1 Result: " + resultPart1);
            listsStack = GetStacks(listsStackPart2,FileContent);
            string resultPart2 = ArrangeForPart2(listsStack, FileContent);
            resultPart2 = resultPart2.Replace("[", "").Replace("]", "");
            Console.WriteLine("Part 2 Result: " + resultPart2);







        }

        static List<List<string>> GetStacks(List<List<string>> listsStack, List<string> FileContent)
        {
            int startIndexForInstructions = 0;
            startIndexForInstructions = FileContent.FindIndex(s => String.IsNullOrWhiteSpace(s));
            string cratesPerRow;
            int localstackIndex = 0;
            for (int i = startIndexForInstructions - 2; i >= 0; i--)
            {
                localstackIndex = 0;
                cratesPerRow = FileContent[i];
                for (int j = 1; j < cratesPerRow.Length; j = j + 4)
                {
                    if (!string.IsNullOrWhiteSpace(Convert.ToString((cratesPerRow[j]))))
                    {
                        listsStack[localstackIndex].Add(cratesPerRow[j].ToString().Replace("[", "").Trim());
                    }
                    localstackIndex++;


                }
            }
            return listsStack;
        }

        static string ArrangeForPart1(List<List<string>> listsStack, List<string> FileContent)
        {
            int itemsCountToMove, from, to;
            List<string> localFrom;
            List<string> localTo;
            int startIndexForInstructions = 0;
            startIndexForInstructions = FileContent.FindIndex(s => String.IsNullOrWhiteSpace(s));
            for (int m = startIndexForInstructions + 1; m < FileContent.Count; m++)
            {
                string[] items = FileContent[m].Split(' ');
                itemsCountToMove = Convert.ToInt32(items[1]);
                from = Convert.ToInt32(items[3]);
                to = Convert.ToInt32(items[5]);
                localFrom = listsStack[from - 1];
                localTo = listsStack[to - 1];
                if (localFrom.Count < itemsCountToMove)
                {
                    itemsCountToMove = 0;
                }
                for (int c = 0; c < itemsCountToMove; c++)
                {

                    localTo.Add(localFrom[localFrom.Count - 1]);
                    localFrom.RemoveAt(localFrom.Count - 1);
                    listsStack[from - 1] = localFrom;
                    listsStack[to - 1] = localTo;
                }
            }
            string result = String.Empty;
            foreach (List<string> listStack in listsStack)
            {
                if (listStack.Count > 0)
                {
                    result = result + listStack[listStack.Count - 1];
                }
            }
            return result;
        }

        static string ArrangeForPart2(List<List<string>> listsStack, List<string> FileContent)
        {
            int itemsCountToMove, from, to;
            List<string> localFrom;
            List<string> localTo;
            int startIndexForInstructions = 0;
            startIndexForInstructions = FileContent.FindIndex(s => String.IsNullOrWhiteSpace(s));
            for (int m = startIndexForInstructions + 1; m < FileContent.Count; m++)
            {
                string[] items = FileContent[m].Split(' ');
                itemsCountToMove = Convert.ToInt32(items[1]);
                from = Convert.ToInt32(items[3]);
                to = Convert.ToInt32(items[5]);
                localFrom = listsStack[from - 1];
                localTo = listsStack[to - 1];
                localTo.AddRange(localFrom.TakeLast(itemsCountToMove));
                localFrom.RemoveRange(localFrom.Count - itemsCountToMove, itemsCountToMove);
            }
            string result = String.Empty;
            foreach (List<string> listStack in listsStack)
            {
                if (listStack.Count > 0)
                {
                    result = result + listStack[listStack.Count - 1];
                }
            }
            return result;
        }
    }
}