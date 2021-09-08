using System;

namespace TicTacToe
{
    public static class TicTacToe
    {
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
    }
}
