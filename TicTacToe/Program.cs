using System;

namespace TicTacToe
{
    //CREATED BY TEAM - 5 (REP NAME, NAME, THAR LIN HTET......... )
    class Program
    {
                                    //Game Rules
        //Input must be exactly the same as the following format with 'X' or 'O' instead '.'
        //>>>{{'.','.','.'},{'.','.','.'},{'.','.','O'}}<<<
        // X has to start the game, followed by O and go on alternatively
        //Invalid inputs includes wrong format, skipping turn, replacing 'X' or 'O'
        //and putting more than one changes in an input
        //Invalid inputs will be ignored and won't take count into the game
        //The game will end when there is a winner or no more '.' to be replaced by 'X' or 'O'
        //Have Fun Playing TicTacToe :)

        static void Main()
        {
            Console.Write("Please insert a TicTacToe pattern:");
            string input = Console.ReadLine();

            while (!TicTacToe.isInputValid(input))
            {
                Console.Write("Please insert a TicTacToe pattern:");
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

            TicTacToe.changeState(newState);
            
            if (TicTacToe.isThereWinner() || TicTacToe.isTheGameDraw())
            {
                TicTacToe.OutputState();
                Console.WriteLine("Game Over");
                return;
            }
            TicTacToe.checkTurn();
            TicTacToe.OutputState();
            Main();
        }
    }
}
