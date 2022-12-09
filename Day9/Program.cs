using System.Data;
using System.Diagnostics;

namespace Day9
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> input = File.ReadAllLines("Input.txt").ToList();

            List<(int, int)> listOfTailCoOrdinatesPart1 = new List<(int, int)>();
            List<(int, int)> listOfTailCoOrdinatesPart2 = new List<(int, int)>();
          
            CalculateUniquePositionsForTail(input, 2);

            CalculateUniquePositionsForTail(input, 10);

        }

        public static void CalculateUniquePositionsForTail(List<string> input, int lengthOfRope)
        {
            List<(int, int)> listOfTailCoOrdinatesPart1 = new List<(int, int)>();
            var ropePart1 = Enumerable.Repeat(new Coordinate(0, 0), lengthOfRope).ToArray();
            foreach (string line in input)
            {
                string Direction = line.Split(' ')[0];
                int movementStep = Convert.ToInt32(line.Split(' ')[1]);
                for (int i = 1; i <= movementStep; i++)
                {
                    MoveHead(ref ropePart1, Direction);
                    if (!listOfTailCoOrdinatesPart1.Contains((ropePart1[lengthOfRope-1].x, ropePart1[lengthOfRope-1].y)))
                    {
                        listOfTailCoOrdinatesPart1.Add((ropePart1[lengthOfRope-1].x, ropePart1[lengthOfRope - 1].y));
                    }

                }

            }
            Console.WriteLine("When Rope length is " + lengthOfRope + " knots. Then unique positions for tail :" + listOfTailCoOrdinatesPart1.Count);
        }


        public static void MoveHead(ref Coordinate[] positions, string direction)
        {
            switch (direction)
            {
                case "L":
                    positions[0].x--;
                    break;
                case "R":
                    positions[0].x++;
                    break;
                case "U":
                    positions[0].y++;
                    break;
                case "D":
                    positions[0].y--;
                    break;
            }
            for (int i = 1; i < positions.Length; i++)
            {
                var dx = positions[i - 1].x - positions[i].x;
                var dy = positions[i - 1].y - positions[i].y;

                if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                {
                    positions[i] = new Coordinate(
                        positions[i].x + Math.Sign(dx),
                        positions[i].y + Math.Sign(dy)
                    );
                }
            }
        }
    }
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

}

   
