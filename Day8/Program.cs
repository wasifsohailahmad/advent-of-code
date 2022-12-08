namespace Day8
{
    internal class Program
    {
/*30373
25512
65332
33549
35390*/
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Input.txt");
            int counterVisible = 0;
            int outerTreesCount = (2*input.Length) + (2*input[0].ToCharArray().Length) - 4;
            int[,] inputTrees = new int[input[0].ToCharArray().Length, input.Length];
            for (int i = 0;i<inputTrees.GetLength(0);i++)
            {
                for(int j =0; j<inputTrees.GetLength(1); j++)
                {
                    inputTrees[i, j] = Convert.ToInt32(input[i].Substring(j, 1));
                }
            }
            int highestScenicScore = 0;
            for (int i = 1; i < inputTrees.GetLength(0)-1; i++)
            {
                for (int j = 1; j < inputTrees.GetLength(1)-1; j++)
                {
                    if(CheckIfTreeIsVisible(inputTrees,i,j))
                    {
                        counterVisible++;
                    }
                    int scenicScore = TreeScenicScore(inputTrees, i, j);
                    if (highestScenicScore< scenicScore)
                    {
                        highestScenicScore = scenicScore;
                    }

                }
            }
            Console.WriteLine("Total Visible Trees : " + (counterVisible + outerTreesCount));
            Console.WriteLine("Highest Scenic Score : " + highestScenicScore);

        }

        static bool CheckIfTreeIsVisible(int[,] inputTrees,int rowIndex, int columnIndex)
        {
            bool isHiddenFromTop = false;
            bool isHiddenFromLeft=false;
            bool isHiddenFromRight=false;
            bool isHiddenFromBottom =false;
            if(columnIndex == 0 || columnIndex == inputTrees.GetLength(1) || rowIndex == 0 || rowIndex == inputTrees.GetLength(0))
            {
                return true;
            }
            for(int i=0;i< rowIndex; i++)
            {
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[i,columnIndex])
                {
                    isHiddenFromTop = true;
                    break;
                }
            }
            if(!isHiddenFromTop)
            {
                return true;
            }
            for (int j = 0; j < columnIndex; j++)
            {
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[rowIndex, j])
                {
                    isHiddenFromLeft = true;
                    break;
                }
            }
            if (!isHiddenFromLeft)
            {
                return true;
            }
            for (int k = columnIndex + 1; k < inputTrees.GetLength(1); k++)
            {
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[rowIndex, k])
                {
                    isHiddenFromRight = true;
                    break;
                }
            }
            if (!isHiddenFromRight)
            {
                return true;
            }
            for (int k = rowIndex + 1; k < inputTrees.GetLength(0); k++)
            {
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[k, columnIndex])
                {
                    isHiddenFromBottom = true;
                    break;
                }
            }
            if (!isHiddenFromBottom)
            {
                return true;
            }
            return false;
        }

        static int TreeScenicScore(int[,] inputTrees, int rowIndex, int columnIndex)
        {
            int topScenicScore = 0;
            int bottomScenicScore = 0;
            int leftScenicScore = 0;
            int rightScenicScore = 0;
            if (columnIndex == 0 || columnIndex == inputTrees.GetLength(1) || rowIndex == 0 || rowIndex == inputTrees.GetLength(0))
            {
                return 0;
            }
            for (int i = rowIndex-1; i >= 0; i--)
            {
                topScenicScore++;
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[i, columnIndex])
                {
                    break;
                }

            }

            for (int j = columnIndex-1; j >= 0; j--)
            {
                leftScenicScore++;
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[rowIndex, j])
                {
                    break;
                }
            }
            for (int k = columnIndex + 1; k < inputTrees.GetLength(1); k++)
            {
                rightScenicScore++;
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[rowIndex, k])
                {
                    break;
                }
            }

            for (int k = rowIndex + 1; k < inputTrees.GetLength(0); k++)
            {
                bottomScenicScore++;
                if (inputTrees[rowIndex, columnIndex] <= inputTrees[k, columnIndex])
                {
                    break;
                }
            }

            return topScenicScore*bottomScenicScore*leftScenicScore*rightScenicScore;
        }
    }
}