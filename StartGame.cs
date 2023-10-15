namespace SnakeGame
{

        class StartGame {
            private (int,int) fieldSize = default;
            private char[,] field = default;
            private (int,int) foodPos = default;
            private (int,int) headPos = default;
            private Queue<(int,int)> snake = default;
            private DirMove move = default;
            (int, int) tempCoords;
            public void Start() {
                InitVars();
                while (true) {
                    
                        Console.Clear();

                    if (Console.KeyAvailable) {
                        move = ReadMove(Console.ReadKey(true).Key,move);
                    }
                    SnakeMove(move);
                    switch (field[headPos.Item1,headPos.Item2]) {
                        case '#':
                        case '%':
                            Console.WriteLine("Game over");
                            return ;
                        case '$':
                            break;
                        default:
                            tempCoords = snake.Dequeue();
                            field[tempCoords.Item1,tempCoords.Item2] = ' ';
                            snake.Enqueue((headPos.Item1,headPos.Item2));
                            field[headPos.Item1,headPos.Item2] = '@';
                            break;
                    }
                        
                    for (int i = 0; i < field.GetLength(0); i++)
                    {
                        for (int j = 0; j < field.GetLength(1); j++)
                        {
                            Console.Write(field[i,j]);
                        }
                        Console.WriteLine();
                    }

                    Thread.Sleep(250);
                        
                    
                }
            }
            private DirMove ReadMove(ConsoleKey key, DirMove prevMove) {
                switch (key) {
                    case ConsoleKey.UpArrow:
                        if (prevMove == DirMove.Down) goto default;
                        return DirMove.Up;
                    case ConsoleKey.LeftArrow:
                        if (prevMove == DirMove.Right) goto default;
                        return DirMove.Left;
                    case ConsoleKey.RightArrow:
                        if (prevMove == DirMove.Left) goto default;
                        return DirMove.Right;
                    case ConsoleKey.DownArrow:
                        if (prevMove == DirMove.Up) goto default;
                        return DirMove.Down;
                    default:
                        return prevMove;
                    }
            }
            private void SnakeMove(DirMove move) {
                switch (move)
                {
                    case DirMove.Up:
                        --headPos.Item1;
                        break;
                    case DirMove.Left:
                        --headPos.Item2;

                        break;
                    case DirMove.Right:
                        ++headPos.Item2;

                        break;
                    case DirMove.Down:
                        ++headPos.Item1;
                        break;
                    default:
                        break;
                }
            }
            private void InitVars() {
                fieldSize = (20+2,50+2);
                field = new char[fieldSize.Item1,fieldSize.Item2];
                MakeField(field);
                headPos = ((fieldSize.Item1+1)/2,(fieldSize.Item2+1)/2);
                snake = new Queue<(int, int)>();
                snake.Enqueue(headPos);
                move = DirMove.Left;
            }
            private void MakeField(char[,] field) {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (i == 0 || j == 0 || i == field.GetLength(0) -1 || j == field.GetLength(1) -1) field[i,j] = '#';
                        else field[i,j] = ' ';
                    }
                }
                // for (int i = 0; i < field.GetLength(0); i++)
                // {
                //     for (int j = 0; j < field.GetLength(1); j++)
                //     {
                //         Console.Write(field[i,j]);
                //     }
                //     Console.WriteLine();
                // }
            }
            public StartGame() {
                
            }
        }
}