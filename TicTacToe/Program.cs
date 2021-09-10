using System;

namespace TicTacToe
{
    class Program
    {
        //This program will check for the format of the input
        //It must be in the following format with 'X' or 'O' instead '.'
        //>>>{{'.','.','.'},{'.','.','.'},{'.','.','X'}}<<<
        // X has to start the game and only one changes allow per input

        //state is declared at the class-level
        static char[,] state = { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };

        static void Main()
        {
            Console.Write("Please insert a TicTacToe pattern:");
            string input = Console.ReadLine();

            while (!TicTacToe.isInputValid(input))
            {
                Console.Write("Please insrt a TicTacToe pattern:");
                input = Console.ReadLine();
            }

            char[,] newState = new char[3, 3];

            int secondIndexOfFirstArray = 0;
            int secondIndexOfSecondArray = 0;
            int secondIndexOfThirthArray = 0;

            //The input are inserted into the newState array
            for (int i = 0; i < input.Length; i++)
            {
                //The program will detect "X" and "O" and try to insert the array!!
                if (input[i].Equals('X') || input[i].Equals('O') || input[i].Equals('.'))

                {
                    try
                    {
                        newState[0, secondIndexOfFirstArray++] = input[i];
                        //The int-operator keep increase as the loop continue and eventually it will invoke IndexOutOfRangeException
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //As the exception is invoked, the value will be assigned to the next array.
                        try
                        {
                            newState[1, secondIndexOfSecondArray++] = input[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //Same thing goes here
                            try
                            {
                                newState[2, secondIndexOfThirthArray++] = input[i];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Wait What");
                            }
                        }
                    }
                }
            }

            TicTacToe.changeState(state,newState);
            
            if (TicTacToe.isThereWinner(state))
            {
                TicTacToe.OutputState(state);
                Console.WriteLine("Game Over");
                return;
            }
            TicTacToe.checkTurn(state);
            TicTacToe.OutputState(state);
            Main();
        }
    }

}
