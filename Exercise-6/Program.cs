using System;

namespace GameOfLife
{
    public class LifeSimulation
    {
        private int _height;
        private int _width;
        private bool[,] cells;

        
        public LifeSimulation(int Height, int Width)
        {
            _height = Height;
            _width = Width;
            cells = new bool[Height, Width];
            GenerateField();
        }

        
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

       
        private void Grow()
        {
            bool[,] newCells = new bool[_height, _width];

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        newCells[i, j] = numOfAliveNeighbors == 2 || numOfAliveNeighbors == 3;
                    }
                    else
                    {
                        newCells[i, j] = numOfAliveNeighbors == 3;
                    }
                }
            }

            cells = newCells;
        }

        
        private int GetNeighbors(int x, int y)
        {
            int numOfAliveNeighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < _height && j < _width && !(i == x && j == y))
                    {
                        if (cells[i, j]) numOfAliveNeighbors++;
                    }
                }
            }

            return numOfAliveNeighbors;
        }

        
        private void DrawGame()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(cells[i, j] ? "X" : " ");
                    if (j == _width - 1) Console.WriteLine();
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

       
        private void GenerateField()
        {
            Random generator = new Random();
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    cells[i, j] = generator.Next(2) == 1;
                }
            }
        }
    }

    internal class Program
    {
        private const int Height = 20;
        private const int Width = 40;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Height, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}