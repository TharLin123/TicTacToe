using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            char[,] state1 = new char[3,3];

            Console.Write("Please insrt a TicTacToe pattern:");
            string input = Console.ReadLine();
            Console.Write("\n");

            int secondIndexOfFirstArray = 0;
            int secondIndexOfSecondArray = 0;
            int secondIndexOfThirthArray = 0;

            for (int i = 0; i < input.Length; i++)
            {
                //The program will detect "X" and "O" and try to insert the array!!
                if (input[i].Equals('X')   || input[i].Equals('O') || input[i].Equals('.'))
                {
                    try
                    {
                        state1[0, secondIndexOfFirstArray++] = input[i];
                        //The int-operator keep increase as the loop continue and eventually it will invoke IndexOutOfRangeException
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //As the exception is invoked, the value will be assigned to the next array.
                        try
                        {
                            state1[1, secondIndexOfSecondArray++] = input[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //Same thing goes here
                            try
                            {
                                state1[2, secondIndexOfThirthArray++] = input[i];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Wait What");
                            }
                        }
                    }
                }
            }

            TicTacToe.OutputState(state1);
            checkWinner(state1);
            Main();
        }

        public static void checkWinner(char[,] state)
        {
            //(0,0)(0,1)(0,2)
            //(1,0)(1,1)(1,2)
            //(2,0)(2,1)(2,2)

            int countWinner = 0;
            
            if (
                state[0, 0] == state[0, 1] && state[0, 1] == state[0, 2] ||
                state[0, 0] == state[1, 0] && state[1, 0] == state[2, 0]
            )
            {
                //the system need to ignore '.'
                if(state[0,0] != '.')
                {
                    countWinner++;
                    Console.WriteLine("{0} won", state[0, 0]);
                }
            }
            if
                (
                state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2] ||
                state[2, 0] == state[1, 1] && state[1, 1] == state[0, 2] ||
                state[0, 1] == state[1, 1] && state[1, 1] == state[2, 1] ||
                state[1, 0] == state[1, 1] && state[1, 1] == state[1, 2]
                )
            {
                if (state[1, 1] != '.')
                {
                    countWinner++;
                    Console.WriteLine("{0} won", state[1, 1]);
                }
            }
            if (
                state[2, 2] == state[1, 2] && state[1, 2] == state[0, 2] ||
                state[2, 2] == state[2, 1] && state[1, 0] == state[2, 0]
            )
            {
                if (state[2, 2] != '.')
                {
                    countWinner++;
                    Console.WriteLine("{0} won", state[2, 2]);
                }
            }

            // If there is more than one winner, the game is considered invalid!
            if (countWinner > 1) {
                Console.WriteLine("Wait! What");
            }
            else if(countWinner == 0)
            {
                //if there is no winner, the program wil check turn! 
                checkTurn(state);
            }
        }

        public static void checkTurn(char[,] state)
        {
            int countX = 0;
            int countO = 0;

            // check the number of X and O in array
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    if (state[i, j].Equals('X')  )
                    {
                        countX++;
                    }
                    if(state[i, j].Equals('O'))
                    {
                        countO++;
                    }
                }
            }

            if(countX == countO) // if number of X and O are same, it should be X's turn since X started the game first
            {
                Console.WriteLine("X’s turn.");
            }
            else if(countX > countO && countX - countO == 1) // if number of X is greater by one, it should be O's turn
            {
                Console.WriteLine("O’s turn.");
            }
            else // all other conditions are invalid
            {
                Console.WriteLine("Wait What");
            }
        }
    }

}
