using System;

namespace TicTacToe
{
    public static class TicTacToe
    {
        static char[,] previousState = new char[3, 3];

        public static void maintainState(char[,] state)
        {
            //there we make a deep-copy of the state 
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    previousState[i, j] = state[i, j];
                }
            }
        }

        public static void rollBack(char[,] state)
        {
            for (int i = 0; i < previousState.GetLength(0); i++)
            {
                for (int j = 0; j < previousState.GetLength(1); j++)
                {
                    state[i, j] = previousState[i, j];
                }
            }
        }

        public static void changeState(char[,] state, char[,] newState)
        {
            //we should maintain our state first before any changes occur
            maintainState(state);

            int stateChangeCount = 0;

            for (int i = 0; i < newState.GetLength(0); i++)
            {
                for (int j = 0; j < newState.GetLength(1); j++)
                {
                    //check the difference between two state and detect invalid change
                    // the changes that change from 'X' to 'O' or 'X','O' to '.' are considered invalid
                    if (state[i, j] != '.' && state[i, j] == '.' || state[i, j] != '.' && newState[i, j] != state[i, j])
                    {
                        Console.WriteLine("Wait, What? Invalid Input");
                    }
                    //it will detect the number of change that changes from '.' to 'X' or 'O' and assign to state
                    else if (state[i, j] == '.' && state[i, j] != newState[i, j])
                    {
                        state[i, j] = newState[i, j]; //assign to the state
                        stateChangeCount++; // the stateChangeCount increase as the state change
                    }
                }
            }

            //if there is more than one change, state is maintained back to previous state
            if (stateChangeCount > 1)
            {
                Console.WriteLine("Wait, What? Invalid Input");
                rollBack(state);
            }
            else if(stateChangeCount == 0) //if there is no change...
            {
                Console.WriteLine("Wait, What? Pls make a change");
            }
        }

        public static void OutputState(char[,] state)
        {
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    Console.Write(state[i,j] + " ");
                }
                Console.Write("\n");
            }
        }

        public static void checkTurn(char[,] state)
        {
            int countX = 0;
            int countO = 0;

            // count the number of X and O in array
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    if (state[i, j].Equals('X'))
                    {
                        countX++;
                    }
                    if (state[i, j].Equals('O'))
                    {
                        countO++;
                    }
                }
            }

            if (countX == countO) // if number of X and O are same, it should be X's turn since X started the game first
            {
                Console.WriteLine("X’s turn.");
            }
            else if (countX > countO && countX - countO == 1) // if number of X is greater by one, it should be O's turn
            {
                Console.WriteLine("O’s turn.");
            }
            else if(countX== 0 && countO == 1) // it means O start the game first which isn't supposed to be
            {
                //the state will be maintained back
                rollBack(state);
                Console.WriteLine("Wait, What? X must start the game first!");
            }
            else if(countX - countO > 1)
            {
                rollBack(state);
                Console.WriteLine("Wait What? Isn't it supposed to be O's turn?");
            }
            else if(countO > countX)
            {
                rollBack(state);
                Console.WriteLine("Wait What? Isn't it supposed to be X's turn?");
            }
            else // all other conditions are invalid
            {
                rollBack(state);
                Console.WriteLine("Wait What? Input Invalid");
            }
        }

        public static bool isThereWinner(char[,] state)
        {
            //(0,0)(0,1)(0,2)
            //(1,0)(1,1)(1,2)
            //(2,0)(2,1)(2,2)

            if (
                state[0, 0] == state[0, 1] && state[0, 1] == state[0, 2] ||
                state[0, 0] == state[1, 0] && state[1, 0] == state[2, 0]
            )
            {
                //the system need to ignore '.'
                if (state[0, 0] != '.')
                {
                    Console.WriteLine("{0} won", state[0, 0]);
                    return true;
                }
            }
            else if
                (
                state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2] ||
                state[2, 0] == state[1, 1] && state[1, 1] == state[0, 2] ||
                state[0, 1] == state[1, 1] && state[1, 1] == state[2, 1] ||
                state[1, 0] == state[1, 1] && state[1, 1] == state[1, 2]
                )
            {
                if (state[1, 1] != '.')
                {
                    Console.WriteLine("{0} won", state[1, 1]);
                    return true;
                }
            }
            else if (state[2, 2] == state[1, 2] && state[1, 2] == state[0, 2] ||
                state[2, 2] == state[2, 1] && state[2, 1] == state[2, 0])
                
            
            {
                if (state[2, 2] != '.')
                {
                    Console.WriteLine("{0} won", state[2, 2]);
                    return true;
                }
            }
            return false;
        }

        public static bool isInputValid(string input) {

            string inputFormat = "{{'.','.','.'},{'.','.','.'},{'.','.','.'}}";

            if(input.Length == inputFormat.Length)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if(input[i] != inputFormat[i])
                    {
                        Console.Write(i);
                        if(i == 3 || i == 7 || i == 11 || i == 17 || i == 21 || i == 25 || i == 31 || i == 35 || i == 39)
                        {
                            if(input[i] == 'X' || input[i] == 'O' || input[i] == '.')
                            {
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, Try again!!");
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            Console.WriteLine("Invalid Input, Try again!!");
            return false;
        }
    }
}
