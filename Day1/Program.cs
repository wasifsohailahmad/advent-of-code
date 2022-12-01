using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> FileContent = File.ReadAllLines("input.txt").ToList();
            int countElfs = 0;
            countElfs = FileContent.FindAll(s => String.IsNullOrWhiteSpace(s)).Count;
            List<int> elfCalories = new List<int>();
            int calForElf = 0;
            foreach (string i in FileContent)
            {
                
                if(!String.IsNullOrWhiteSpace(i))
                {
                    calForElf += Convert.ToInt32(i);
                }
                else
                {
                    if(calForElf!=0)
                    {
                        elfCalories.Add(calForElf);
                        calForElf = 0;

                    }
                }

            }
            elfCalories.Sort((a, b) => b.CompareTo(a));
            int sumOfTopThreeElfCalories = elfCalories.Take(3).Sum();


            Console.WriteLine("Max Calories : " + elfCalories.Max().ToString());
        }

    }
}