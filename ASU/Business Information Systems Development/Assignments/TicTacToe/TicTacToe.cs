using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
        // Assignment  4, Renata Tiepo Fonseca, CIS 345, Monday/Wednesday 3:00 PM

        //Parts 1, 2
        // array of strings needed to store names of players
        // 2D array of integers needed to store TicTacToe game values

        // stores if the game is won or not
        static bool gameWon = false; 

        //flag to indicate current player (0 or 1)
        static int currentPlayer = 0;

        //array to store the value that will appear on screen (0, X or _)
        static string[] nameArray = new string[3];

        //matrix that will store the values of the game
        static int[,] gameMatrix = new int[3, 3];

        static void Main(string[] args)
        {
            // Part 3.1
            // Call GetNames
            GetNames();
            // Call ResetGame
            ResetGame();
            // Call DrawGameBoard
            DrawGameBoard();

            do
            {
                // Part 3.2
                // Call PlayNextMove
                PlayNextMove();
                // Draw GameBoard again (since it has changed after the move)
                DrawGameBoard();
                // Call TestforWin to see if the user has won the game
                TestForWin();

            } while (gameWon == false);

            Console.ReadLine();
        } // end main


        private static void ResetGame()
        {
            
            // ResetGame resets the Game to its starting position

            // Part 4
            // Loop through the ENTIRE 2 dimensional array using nested loops
            // for....
            for (int i = 0; i < gameMatrix.GetLength(0); i++)
            {
                //     for....
                for (int j = 0; j < gameMatrix.GetLength(1); j++)
                {
                    //         set the element to -1
                    gameMatrix[i, j] = -1;
                }
            }

        } //end ResetGame

        private static bool GameWonByCols(int playerNumber)
        {
            // This method loops through all the columns
            // and determines if one of the columns has been completed
            // It will look for the value indicated by the playerNumber
            // For player 0, it will look for 0s in the Matrix
            // For player 1, it will look for 1s in the Matrix


            // stores if a column has been "completed", which would indicate that the game has been won
            bool colsComplete = false; 
            
            // stores the number of cells in a row that have been "completed"
            int columnsTotal = 0;

            for (int j = 0; j < 3; j++)
            {// loop through the COLUMNS

                // set the total to zero since we are starting with a new column
                columnsTotal = 0;

                for (int i = 0; i < 3; i++)
                {// loop through the ROWS

                    // test if the element in the array belongs to the current player
                    // e.g. for player 0, we are only interested in a 0 on the TicTacToe board
                    // if we find 1, that does not count for Player 0.
                    if (gameMatrix[i, j] == playerNumber)
                        columnsTotal++; // increment the total since the cell has been completed by player zero

                } // end inner for
        
                // test if all three cells of the column were filled in.
                if (columnsTotal == 3)
                {
                    // all 3 cells were filled! The column has been completed!
                    colsComplete = true;

                    // We can stop looking through more columns! The game has been won!
                    break;
                } // end if

            } // end outer for

            // return the value of the boolean variable.
            // it will contain true if one of columns was found completed.
            //otherwise, it will contain false.

            return colsComplete;
        } // end GameWonByCols


        private static bool GameWonByRows(int playerNumber)
        {
            // This method goes through all the ROWS one by one
            // to see if any of the rows have been completed.
            // If even one of the rows has been completed, it returns true.

            // Part 5
            // Complete this method in a manner similar to GameWonByCols
            // Note, however, that your outer loop will be for rows
            // and your inner loop will be for columns.
            // This is because we are evaluating rows here rather than columns.
           
            bool rowsComplete = false;
            int rowsTotal = 0;

            for (int i = 0; i < 3; i++)
            {
                rowsTotal = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (gameMatrix[i, j] == playerNumber)
                    {
                        rowsTotal++;
                    }
                }

                if (rowsTotal == 3)
                {
                    rowsComplete = true;
                    break;
                }
            }

            return rowsComplete;
            
        } // end GameWonByRows

        private static bool GameWonByDiag1(int playerNumber)
        {
            //this method loops through the matrix to see if the
            // diagonal has been completed for the given player number
            // and returns true if it has.

            // stores if the Diagonal has been completed
            bool diagsComplete = false;
            // stores numbers of completed cells in the diagonal
            int diagsTotal = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Part 6.1
                    
                    // If the cell is on the diagonal AND
                    // if the current element equals the Player Number
                    //     increment the diagonal total
                    // the diagonal consists of the cells (0,0) (1,1) (2,2)
                    // compare the row and column numbers to find out if the cell is on the diagonal
                    // Cell locations should NOT be hardcoded into your statements.

                    if ((i == j) && (gameMatrix[i, j] == playerNumber))
                    {
                        diagsTotal++;
                    }

                } // end inner for
            } // end outer for
            
            if (diagsTotal == 3)
            {
                diagsComplete = true;

            } // end if

            return diagsComplete;

        } // end GameWonByDiag1

        private static bool GameWonByDiag2(int playerNumber)
        {   //this method loops through the matrix to see if the
            // reverse diagonal has been completed for the given player number
            // and returns true if it has.

            bool diagsComplete = false;
            int diagsTotal = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If the cell is on the reverse diagonal
                    // AND if the current element equals the Player Number
                    //     increment the diagonal total

                    // Part 6.2
                    // To find out if a cell is on the reverse diagonal
                    //    ( Reverse diagonal is indicated by (0,2) (1,1) (2,0) )
                    // One needs to compare the sum of the row and column number with a value
                    // What value will it be?
                    // Cell locations should NOT be hardcoded into your statements

                    if (((i + j == 2)) && (gameMatrix[i, j] == playerNumber))
                        diagsTotal++;

                } // end inner for
            
            } // end outer for
       
            if (diagsTotal == 3)
            {
                diagsComplete = true;
            } // end if

            return diagsComplete;

        } // end GameWonByDiag2



        private static void GetNames()
        {
            Console.Clear();

            Console.WriteLine("\t\t\tTic Tac Toe!\n\n");
            
            // Read two names and store them in the array
            Console.Write("Enter name for player 1: ");
            nameArray[0] = Console.ReadLine();

            Console.Write("Enter name for player 2: ");
            nameArray[1] = Console.ReadLine();

            // Give user instructions on program usage
            Console.WriteLine("\nPlay by providing the address of the cell location.");
            Console.WriteLine("e.g., row 1, column 1 will put an X or a O in cell (1,1)");
            Console.WriteLine("\nAny value other than 0-2 will exit the program.");
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey(false);

        } // end GetNames


        private static void TestForWin()
        {

            // Test if the current player has won either by completing one of the diagonals
            // store the result in gameWonByDiags
            bool gameWonByDiags = (GameWonByDiag1(currentPlayer) || GameWonByDiag2(currentPlayer));

            // Part 7.1
            // Declare a boolean variable called gameWonByRowCols
            // Test if the current player has won either by completing one of the columns
            // or by completing one of the rows
            // store the result in gameWonByRowCols
            // Utilize the same format as used above for gameWonByDiags
            bool gameWonByRowCols = (GameWonByRows(currentPlayer) || GameWonByCols(currentPlayer));

            // Part 7.2
            // gameWon = Either game won by row/cols OR game won by diagonals
            // Use the boolean variables above to create an expression
            // Assign the expression to gameWon
            bool gameWon = gameWonByDiags || gameWonByRowCols;

            if (gameWon)
            {
                // game has been won. Tell the user
                Console.Write("\n{0}, You're awesome!\n\nPress any key to exit...", nameArray[currentPlayer]);
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            else
                // game was not won. Change players and continue game.
                ChangePlayers();
        } // End TestForWin

        private static void PlayNextMove()
        {
            // this method prompts the current player to play the next move
            // it assumes that last turn has ended
            // and currentPlayer has already been changed.

            // variables to store location of new move
            int rowNumber;
            int columnNumber;

           Console.Write("Your move, {0}! Mark {1} at...\n\n", nameArray[currentPlayer], ToXO(currentPlayer));
           
           Console.Write("Row#: ");
           rowNumber = Convert.ToInt32(Console.ReadLine());

           Console.Write("Col#: ");
           columnNumber = Convert.ToInt32(Console.ReadLine());
           
            // Call ValidLocation and supply it with the row and column numbers
            // if it returns true, assign the currentPlayer number to the 
            // gameMatrix using the row and column numbers as the indices

            if (ValidLocation(rowNumber, columnNumber))
            {
                // Part 8.2
                // user entered a valid location.
                // we can use the location to store the player's move.
                // currentPlayer has the value that should go in the matrix
                gameMatrix[rowNumber, columnNumber] = currentPlayer;
                
            }
            else
            {
                // User entered an invalid location
                // either outside of matrix or unavailable cell
                Console.WriteLine("That was a bad move! Good bye!");
                Console.ReadKey(false);
                System.Environment.Exit(0);
            } // end else

         } // end PlayNextMove

        private static void ChangePlayers()
        {
            // changes the currentPlayer flag to the other player

            if (currentPlayer == 0 )
                currentPlayer = 1;
            else if (currentPlayer == 1)
                currentPlayer = 0;
            
        } // end ChangePlayers

        private static bool ValidLocation(int row, int col)
        {
            // if the row and column are valid positions
            // and if the element location is empty, return true.
            if ((row < 3) && (col < 3) && (gameMatrix[row, col] == -1))
                return true;
            else
                return false;
        } // end ValidLocation

        private static string ToXO(int number)
        {
            // Part 9
            // this method should return a string based on the number that was provided to it.

            // declare strReturnString as a string. Initialize it to "".
            string strReturnString = "";

            // Use a switch statement and evaluate number
            // if number is 0, set the return string to the letter O (as a string)
            // if number is 1, set the return string to X (as a string)
            // if number is -1, set the return string to _ (as a string)

            switch (number)
            {
                case -1:
                    strReturnString = "_";
                    break;
                case 0:
                    strReturnString = "O";
                    break;
                case 1:
                    strReturnString = "X";
                    break;
            }

            // use the return keyword and return the string. 
            return strReturnString;

        } // end ToXO

        private static void DrawGameBoard()
        {   //this method clears the console and
            // redraws the TicTacToe board
            Console.Clear();

            Console.WriteLine("\t\t\tTic Tac Toe!\n\n");

            Console.WriteLine(" \t0\t1\t2\n\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" {0}", i);
                
                for (int j = 0; j < 3; j++)
                {
                       Console.Write("\t{0}", ToXO(gameMatrix[i,j]));
                } // for
                Console.WriteLine("\n");

            } // for
        } // end DrawGameBoard

    } // class
} // namespace
