using System.Collections.Generic;

namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<string> subdirectories = new List<string>();
            List<(string, uint)> files = new List<(string, uint)>();
            List<(string,string, List<string>, List<(string, uint)>)> fileSystems = new List<(string,string, List<string>, List<(string, uint)>)>();
            List<(string, uint)> filesSizesWithPath = new List<(string, uint)>();
         
            string mainDirectory=string.Empty;
            string path=string.Empty;
            uint sumTotalPart1 = 0;
            bool isListing = false;
            int counter = 0;
            foreach(string line in lines)
            {
                counter++;
                if (line.Contains("$ cd "))
                {
                    if (isListing)
                    {
                        fileSystems.Add((mainDirectory, path, subdirectories.ToList(), files.ToList()));
                        subdirectories.Clear();
                        files.Clear();
                        isListing = false;
                    }
                    if (line.Contains(".."))
                    {
                        path = path.Substring(0, path.LastIndexOf("/"));
                        isListing = false;
                        continue;
                    }
                    else
                    {
                        if (line.Split(" ")[2] == "/")
                        {
                            path = "";
                        }
                        else
                        {
                            path = path + "/" + line.Split(" ")[2];
                        }

                        mainDirectory = line.Replace("$ cd ", "");
                    }
                }
                else if (line.Contains("$ ls"))
                {
                    isListing = true;
                }

                else if (isListing)
                {
                    if (line.StartsWith("dir "))
                    {
                        subdirectories.Add(line.Split(" ")[1]);
                    }
                    else if (UInt32.TryParse(line.Split(" ")[0], out uint result))
                    {
                        files.Add((line.Split(" ")[1], result));
                        filesSizesWithPath.Add((path, result));
                    }

                }
                if(counter==lines.Length)
                {
                    fileSystems.Add((mainDirectory, path, subdirectories.ToList(), files.ToList()));
                }
            }
            uint totalDiskUsage = Convert.ToUInt32(filesSizesWithPath.Sum(x => x.Item2));
            uint availableSpace = 70000000 - totalDiskUsage;
            uint requiredSpace = 30000000 - availableSpace;
            uint leastsizeDirectoryForDeletion=0;
            foreach (var item in fileSystems.Skip(1))
            {
                uint sumTotalFiles = 0;
                

                sumTotalFiles = Convert.ToUInt32(filesSizesWithPath.FindAll(e => e.Item1.Contains(item.Item2)).Sum(x => x.Item2));
                if(sumTotalFiles<=100000)
                {
                    sumTotalPart1 += sumTotalFiles;
                }
                if(sumTotalFiles>= requiredSpace && ((leastsizeDirectoryForDeletion>0 && sumTotalFiles< leastsizeDirectoryForDeletion) || leastsizeDirectoryForDeletion==0))
                {
                    leastsizeDirectoryForDeletion = sumTotalFiles;
                }


            }


        }
    }

   

  


}