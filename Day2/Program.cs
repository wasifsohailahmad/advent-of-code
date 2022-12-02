using System.Diagnostics;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalScorePart1=0;
            int totalScorePart2 = 0;
            List<string> FileContent = File.ReadAllLines("input.txt").ToList();
            foreach(string line in FileContent)
            {
                totalScorePart1 += ScoreOfRockPaperScissorRoundAsPerPart1(line);
                totalScorePart2 += ScoreAsPerPart2(line);
            }
            Console.WriteLine("Total Score for Part 1: " + totalScorePart1);
            Console.WriteLine("Total Score for Part 2: " + totalScorePart2);
        }

        public static int ScoreOfRockPaperScissorRoundAsPerPart1(string roundInput)
        {
            try
            {
                int myRoundScore = 0;
                int OppnSignScore;
                int MySignScore;
                string[] inputs = roundInput.Split(' ');
                string OpponentSign = ConvertEncryptedInputToRockPaperScissor(Convert.ToChar(inputs[0]), out OppnSignScore);
                string MySign = ConvertEncryptedInputToRockPaperScissor(Convert.ToChar(inputs[1]), out MySignScore);

                switch (MySign)
                {
                    case "Rock": 
                        if(OpponentSign == "Rock")
                        {
                            myRoundScore = MySignScore + 3;
                            break;
                        }
                        else if(OpponentSign == "Paper")
                        {
                            myRoundScore = MySignScore;
                            break;
                        }
                        else
                        {
                            myRoundScore = MySignScore + 6;
                            break;
                        }
                    case "Paper":
                        if (OpponentSign == "Rock")
                        {
                            myRoundScore = MySignScore + 6;
                            break;
                        }
                        else if (OpponentSign == "Paper")
                        {
                            myRoundScore = MySignScore + 3;
                            break;
                        }
                        else
                        {
                            myRoundScore = MySignScore;
                            break;
                        }
                    case "Scissor":
                        if (OpponentSign == "Rock")
                        {
                            myRoundScore = MySignScore;
                            break;
                        }
                        else if (OpponentSign == "Paper")
                        {
                            myRoundScore = MySignScore + 6;
                            break;
                        }
                        else
                        {
                            myRoundScore = MySignScore + 3;
                            break;
                        }

                }
                return myRoundScore;
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static string ConvertEncryptedInputToRockPaperScissor(char a, out int signScore)
        {
            signScore = 0;
            string decryptedVal = string.Empty;
            switch(a)
            {
                case 'A':
                case 'X':
                    decryptedVal = "Rock";
                    signScore = 1;
                    break;
                case 'B':
                case 'Y':
                    decryptedVal = "Paper";
                    signScore = 2;
                    break;
                case 'C':
                case 'Z':
                    decryptedVal = "Scissor";
                    signScore = 3;
                    break;

            }
            return decryptedVal;
        }



        public static int ScoreAsPerPart2(string roundInput)
        {
            try 
            {
                int myRoundScore = 0;
                string[] inputs = roundInput.Split(' ');
                ConvertEncryptedInputToWinLoseDraw(Convert.ToChar(inputs[0]), Convert.ToChar(inputs[1]), out myRoundScore);
                return myRoundScore;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static void ConvertEncryptedInputToWinLoseDraw(char opponentSignChar,char resultChar, out int roundScore)
        {
            roundScore = 0;
            string decryptedVal = string.Empty;
            switch (opponentSignChar)
            {
                case 'A':
                    if (resultChar == 'X') 
                    {
                        roundScore = 3 + 0;
                        break;
                    }
                    else if (resultChar == 'Y')
                    {
                        roundScore = 1 + 3;
                        break;
                    }
                    else if (resultChar == 'Z')
                    {
                        roundScore = 2 + 6;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 'B':
                    if (resultChar == 'X')
                    {
                        roundScore = 1 + 0;
                        break;
                    }
                    else if (resultChar == 'Y')
                    {
                        roundScore = 2 + 3;
                        break;
                    }
                    else if (resultChar == 'Z')
                    {
                        roundScore = 3 + 6;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 'C':
                    if (resultChar == 'X')
                    {
                        roundScore = 2 + 0;
                        break;
                    }
                    else if (resultChar == 'Y')
                    {
                        roundScore = 3 + 3;
                        break;
                    }
                    else if (resultChar == 'Z')
                    {
                        roundScore = 1 + 6;
                        break;
                    }
                    else
                    {
                        break;
                    }

            }
        }

    }
}