namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> FileContent = File.ReadAllLines("input.txt").ToList();
            int countIsSubset = 0;
            int countIsOverlap = 0;
            foreach(string fileItem in FileContent)
            {
                if (IsListASubsetPart1(fileItem.Split(',').ToArray()[0], fileItem.Split(',').ToArray()[1]))
                {
                    countIsSubset++;
                }
                if(IsListOverLapPart2(fileItem.Split(',').ToArray()[0], fileItem.Split(',').ToArray()[1]))
                {
                    countIsOverlap++;
                }
                
            }
            Console.WriteLine("Subset Part 1 Count: " +countIsSubset);
            Console.WriteLine("Overlap Part 2 Count: " + countIsOverlap);
        }

        static bool IsListASubsetPart1(string firstSetJobIds, string secondSetJobIds)
        {
            List<string> firstsetIds = firstSetJobIds.Split('-').ToList().Distinct().ToList();
            List<string> secondsetIds = secondSetJobIds.Split('-').ToList().Distinct().ToList();
            bool IsSubset=false;
            if(firstsetIds.Count==1 && secondsetIds.Count ==1)
            {
                IsSubset = firstsetIds.Contains(secondsetIds[0]);
            }
            else if(firstsetIds.Count == 1 && secondsetIds.Count == 2)
            {
                if(Convert.ToInt32(firstsetIds[0]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[0]) <= Convert.ToInt32(secondsetIds[1]))
                {
                    IsSubset = true;
                }
                
            }
            else if(firstsetIds.Count == 2 && secondsetIds.Count == 1)
            {
                if (Convert.ToInt32(secondsetIds[0]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[0]) <= Convert.ToInt32(firstsetIds[1]))
                {
                    IsSubset = true;
                }
                
            }
            else
            {
                if ((Convert.ToInt32(secondsetIds[0]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[0]) <= Convert.ToInt32(firstsetIds[1])
                    && Convert.ToInt32(secondsetIds[1]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[1]) <= Convert.ToInt32(firstsetIds[1]))
                    || (Convert.ToInt32(firstsetIds[0]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[0]) <= Convert.ToInt32(secondsetIds[1])
                    && Convert.ToInt32(firstsetIds[1]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[1]) <= Convert.ToInt32(secondsetIds[1])))
                {
                    IsSubset = true;
                }

            }
            return IsSubset;
        }

        static bool IsListOverLapPart2(string firstSetJobIds, string secondSetJobIds)
        {
            List<string> firstsetIds = firstSetJobIds.Split('-').ToList().Distinct().ToList();
            List<string> secondsetIds = secondSetJobIds.Split('-').ToList().Distinct().ToList();
            bool IsSubset = false;
            if (firstsetIds.Count == 1 && secondsetIds.Count == 1)
            {
                IsSubset = firstsetIds.Contains(secondsetIds[0]);
            }
            else if (firstsetIds.Count == 1 && secondsetIds.Count == 2)
            {
                if (Convert.ToInt32(firstsetIds[0]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[0]) <= Convert.ToInt32(secondsetIds[1]))
                {
                    IsSubset = true;
                }

            }
            else if (firstsetIds.Count == 2 && secondsetIds.Count == 1)
            {
                if (Convert.ToInt32(secondsetIds[0]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[0]) <= Convert.ToInt32(firstsetIds[1]))
                {
                    IsSubset = true;
                }

            }
            else
            {
                if ((Convert.ToInt32(secondsetIds[0]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[0]) <= Convert.ToInt32(firstsetIds[1]))
                    || (Convert.ToInt32(secondsetIds[1]) >= Convert.ToInt32(firstsetIds[0]) && Convert.ToInt32(secondsetIds[1]) <= Convert.ToInt32(firstsetIds[1]))
                    || (Convert.ToInt32(firstsetIds[0]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[0]) <= Convert.ToInt32(secondsetIds[1]))
                    || (Convert.ToInt32(firstsetIds[1]) >= Convert.ToInt32(secondsetIds[0]) && Convert.ToInt32(firstsetIds[1]) <= Convert.ToInt32(secondsetIds[1])))
                {
                    IsSubset = true;
                }

            }
            return IsSubset;
        }

    }
}