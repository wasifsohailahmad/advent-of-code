using System;
using System.Diagnostics.Metrics;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> FileContent = File.ReadAllLines("input.txt").ToList();
            int sumPriorityPart1 = 0;
            int counter = 0;
            int sumPriorityPart2 = 0;
            List<string> grp = new List<string>();
            foreach (string line in FileContent)
            {
                int length = line.Length;
                string[] items = line.Chunk(line.Length / 2)
                .Select(s => new string(s))
                .ToArray();
                sumPriorityPart1 += GetCommonCharPriorityPart1(items[0], items[1]);
                counter++;
                grp.Add(line);
                if(counter == 3)
                {
                    sumPriorityPart2 += GetCommonCharPriorityPart2(grp[0], grp[1], grp[2]);
                    grp.Clear();
                    counter = 0;
                }
            }

            Console.WriteLine("Total PriorityPart1 : " + sumPriorityPart1);
            Console.WriteLine("Total PriorityPart2 : " + sumPriorityPart2);


        }

        static int GetCommonCharPriorityPart1(string unit1, string unit2)
        {
            int commonCharPriority = 0;
            try
            {
                
                char[] commonArray = unit1.ToCharArray().Intersect(unit2.ToCharArray()).ToArray();
                if(commonArray.Count() != 1)
                {
                    throw new Exception();
                }
                else
                {
                    int charVal = Convert.ToChar(commonArray[0]);
                    if(charVal>=97 && charVal<=122)
                    {
                        commonCharPriority = charVal - 96;
                    }
                    else if(charVal>=65 && charVal<=90)
                    {
                        commonCharPriority = (charVal - 64)+26;

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
            return commonCharPriority;
        }

        static int GetCommonCharPriorityPart2(string group1, string group2, string group3)
        {
            int commonCharPriority = 0;
            try
            {

                char[] commonArray = group1.ToCharArray().Intersect(group2.ToCharArray()).Intersect(group3.ToCharArray()).ToArray();
                if (commonArray.Count() != 1)
                {
                    throw new Exception();
                }
                else
                {
                    int charVal = Convert.ToChar(commonArray[0]);
                    if (charVal >= 97 && charVal <= 122)
                    {
                        commonCharPriority = charVal - 96;
                    }
                    else if (charVal >= 65 && charVal <= 90)
                    {
                        commonCharPriority = (charVal - 64) + 26;

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return commonCharPriority;
        }
    }
}