namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;

    internal class Maze
    {
        //TODO: Set maze exit cell. Integrate with Player and CommandExecutor classes.
        private static readonly Random globalRandomGenerator = new Random();

        private const int MazeDefaultRows = 15;
        private const int MazeDefaultColumns = 25;
        private const int PlayerDefaultStartRow = 0;
        private const int PlayerDefaultStartColumns = 0;

        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';
        private const char BorderSymbol = '\u2593';
        private const char PlayerSymbol = '\u263a';


        private MazeCell[,] mazeCells;

        public Maze()
            : this(MazeDefaultRows, MazeDefaultColumns, PlayerDefaultStartRow, PlayerDefaultStartColumns)
        {
        }

        public Maze(int maxRows, int maxCols)
            : this(maxRows, maxCols, PlayerDefaultStartColumns, PlayerDefaultStartRow)
        {
        }

        public Maze(int startRow, int startCol, int maxRows, int maxCols)
        {
            this.mazeCells = GenerateRandomMaze(startRow, startCol, maxRows, maxCols);
        }

        public int Rows
        {
            get
            {
                return this.mazeCells.GetLength(0);
            }
        }

        public int Columns 
        {
            get
            {
                return this.mazeCells.GetLength(1);
            } 
        }

        public void PrintMazeOnConsole(Player player)
        {
            Console.WriteLine(new string(BorderSymbol, this.Columns + 2));

            for (int r = 0; r < this.Rows; r++)
            {
                Console.Write(BorderSymbol);

                for (int c = 0; c < this.Columns; c++)
                {
                    if (r == player.Row && c == player.Column)
                    {
                        Console.Write(PlayerSymbol);
                    }
                    else if (this.mazeCells[r, c].IsWall)
                    {
                        Console.Write(WallSymbol);
                    }
                    else
                    {
                        Console.Write(PathSymbol);
                    }
                }

                Console.Write(BorderSymbol);
                Console.WriteLine();
            }

            Console.WriteLine(new string(BorderSymbol, this.Columns + 2));
        }

        /// <summary>
        /// Generates random maze using interative Depth First Search algorithm. From a specified entry point
        /// in the matrix of MazeCell objects(initially all cells marked as walls), 
        /// an unvisited neigbour cell is randomly chosen, then it is marked as visited.
        /// If it has less than two neighbours that are path cells - that cell is made a path.
        /// The process goes on until there is no unvisited cell. 
        /// When so, the algorithms "tracks back" until it finds an unvisited cell. If there is no such cell, 
        /// it assumes that the maze is complete.
        /// </summary>
        /// <param name="startRow">Enrty cell row.</param>
        /// <param name="startCol">Entry cell column.</param>
        /// <param name="maxRows">Maze width, as number of rows.</param>
        /// <param name="maxCols">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of MazeCell objects.</returns>
        private MazeCell[,] GenerateRandomMaze(int maxRows, int maxCols, int startRow, int startCol)
        {
            var generatedMaze = new MazeCell[maxRows, maxCols];

            for (int row = 0; row < maxRows; row++)
            {
                for (int col = 0; col < maxCols; col++)
                {
                    generatedMaze[row, col] = new MazeCell(row, col);
                }
            }

            var pathSoFar = new Stack<MazeCell>();
            var currCell = generatedMaze[startRow, startCol];
            currCell.IsVisited = true;
            currCell.IsWall = false;

            do
            {
                generatedMaze[currCell.Row, currCell.Col].IsVisited = true;
                generatedMaze[currCell.Row, currCell.Col].IsWall = false;

                var unvisitedNeighbours = GetUnvisitedNeighbours(generatedMaze, currCell.Row, currCell.Col);

                if (unvisitedNeighbours.Count > 0)
                {
                    var nextCellIndex = globalRandomGenerator.Next(0, unvisitedNeighbours.Count);
                    var nextCell = unvisitedNeighbours[nextCellIndex];

                    if (HasLessThanTwoNeighbouringPathCells(generatedMaze, nextCell))
                    {
                        pathSoFar.Push(currCell);
                        currCell = nextCell;
                    }
                    else
                    {
                        generatedMaze[nextCell.Row, nextCell.Col].IsVisited = true;
                    }
                }
                else
                {
                    currCell = pathSoFar.Pop();
                }
            } while (pathSoFar.Count > 0);

            return generatedMaze;
        }

        private IList<MazeCell> GetUnvisitedNeighbours(MazeCell[,] maze, int row, int col)
        {
            var unvisitedNeighbours = new List<MazeCell>();

            if (row - 1 >= 0 && !maze[row - 1, col].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row - 1, col]);
            }

            if (row + 1 < maze.GetLength(0) && !maze[row + 1, col].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row + 1, col]);
            }

            if (col - 1 >= 0 && !maze[row, col - 1].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row, col - 1]);
            }

            if (col + 1 < maze.GetLength(1) && !maze[row, col + 1].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row, col + 1]);
            }

            return unvisitedNeighbours;
        }

        private bool HasLessThanTwoNeighbouringPathCells(MazeCell[,] maze, MazeCell nextCell)
        {
            int neighbouringPaths = 0;

            if (nextCell.Row - 1 >= 0 && !maze[nextCell.Row - 1, nextCell.Col].IsWall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Row + 1 < maze.GetLength(0) && !maze[nextCell.Row + 1, nextCell.Col].IsWall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Col - 1 >= 0 && !maze[nextCell.Row, nextCell.Col - 1].IsWall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Col + 1 < maze.GetLength(1) && !maze[nextCell.Row, nextCell.Col + 1].IsWall)
            {
                neighbouringPaths++;
            }

            return neighbouringPaths <= 1;
        }
    }
}
