using System;
using System.Threading;

namespace MiniGame
{

    class Program
    {
        static int windowWidth = Console.WindowWidth;
        static int windowHeight = Console.WindowHeight;

        static int playerX = windowWidth / 2;
        static int playerY = windowHeight / 2;

        static int foodX;
        static int foodY;

        static string[] states = { "O", "X", "@", "#" };
        static string[] foods = { "*", "!", "$", "%" };

        static string player = states[0];
        static string currentFood = foods[0];

        static bool isFrozen = false;
        static int movementSpeed = 200; // Intervalo em milissegundos

        static void Main()
        {
            // Configuração inicial
            SetupGame();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    // Verifica se a tecla de movimentação é suportada
                    if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                    {
                        MovePlayer(key);
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        // Encerra o jogo ao pressionar ESC
                        break;
                    }
                }

                // Verificar se o jogador consumiu o alimento
                if (playerX == foodX && playerY == foodY)
                {
                    ConsumeFood();
                    RegenerateFood();
                }

                Thread.Sleep(movementSpeed);
            }
        }

        static void SetupGame()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Exibe o jogador e o alimento inicial
            DisplayPlayer();
            RegenerateFood();
        }

        static void DisplayPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        static void RegenerateFood()
        {
            Random random = new Random();
            foodX = random.Next(0, windowWidth - 1);
            foodY = random.Next(0, windowHeight - 1);
            currentFood = foods[random.Next(foods.Length)];

            Console.SetCursorPosition(foodX, foodY);
            Console.Write(currentFood);
        }

        static void MovePlayer(ConsoleKey direction)
        {
            if (!isFrozen)
            {
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(" "); // Limpar a posição anterior do jogador

                switch (direction)
                {
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0) playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerX < windowWidth - 1) playerX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (playerY > 0) playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerY < windowHeight - 1) playerY++;
                        break;
                }

                DisplayPlayer();
            }
        }

        static void ConsumeFood()
        {
            // Mudar a aparência do jogador para a do alimento consumido
            player = currentFood;

            // Congelar o jogador temporariamente se o alimento tiver um efeito de congelamento
            if (currentFood == "*")
            {
                isFrozen = true;
                Thread.Sleep(1000); // Congela o jogador por 1 segundo
                isFrozen = false;
            }
            // Aumentar a velocidade de movimento se o alimento aumentar a velocidade
            else if (currentFood == "!")
            {
                movementSpeed = Math.Max(50, movementSpeed - 50); // Aumenta a velocidade, limite mínimo de 50ms
            }
        }
    }
}
