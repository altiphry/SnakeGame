
namespace SnakeGame
{
        class Program {
            static void Main(string[] args) {
                StartGame game = new StartGame();
                while (true) {
                    game.Start();
                    Console.WriteLine("Press Q to quit or any key to restart the game");
                    if(Console.ReadKey().Key == ConsoleKey.Q) break;
                }
            }
        }
}