using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variáveis para suporte de entrada de dados
            int maxPets = 8;
            string menuSelection = "";

            // Matriz usada para armazenar dados em tempo de execução, não há dados persistidos
            string[,] ourAnimals = new string[maxPets, 6];

            // Dados iniciais para teste
            ourAnimals[0, 0] = "dog"; ourAnimals[0, 1] = "d2"; ourAnimals[0, 2] = "9";
            ourAnimals[0, 3] = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            ourAnimals[0, 4] = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            ourAnimals[0, 5] = "loki";

            ourAnimals[1, 0] = "cat"; ourAnimals[1, 1] = "c3"; ourAnimals[1, 2] = "1";
            ourAnimals[1, 3] = "small white female weighing about 8 pounds. litter box trained.";
            ourAnimals[1, 4] = "friendly";
            ourAnimals[1, 5] = "Puss";

            ourAnimals[2, 0] = "cat"; ourAnimals[2, 1] = "c4"; ourAnimals[2, 2] = "?";
            ourAnimals[2, 3] = ""; // missing physical description
            ourAnimals[2, 4] = ""; // missing personality description
            ourAnimals[2, 5] = ""; // missing nickname

            // Verificar e solicitar entrada para dados ausentes ou incompletos
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1] != null && ourAnimals[i, 1] != "") // Checa se o ID do animal não é nulo ou vazio
                {
                    // Checar e solicitar apelido se estiver faltando ou inválido
                    while (string.IsNullOrWhiteSpace(ourAnimals[i, 5]))
                    {
                        Console.WriteLine($"Enter a nickname for ID #: {ourAnimals[i, 1]}");
                        ourAnimals[i, 5] = Console.ReadLine();
                    }

                    // Checar e solicitar descrição de personalidade se estiver faltando ou inválido
                    while (string.IsNullOrWhiteSpace(ourAnimals[i, 4]))
                    {
                        Console.WriteLine($"Enter a personality description for ID #: {ourAnimals[i, 1]} (likes or dislikes, tricks, energy level)");
                        ourAnimals[i, 4] = Console.ReadLine();
                    }
                }
            }

            // Confirmar que todos os requisitos de dados foram atendidos
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();


                        string customerName = "Ms. Barros";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            // Lógica para gerar a mensagem personalizada
            string message = $@"
            Dear {customerName},
            As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.

            Currently, you own {currentShares:n} shares at a return of {currentReturn:p2}.

            Our new product, {newProduct} offers a return of {newReturn:p2}.  Given your current volume, your potential profit would be ¤{newProfit:n}.

            Here's a quick comparison:

            {currentProduct}         {currentReturn:p2}   ${currentProfit:n}      
            {newProduct}     {newReturn:p2}   ${newProfit:n}
            ";

            // Exibir a mensagem
            Console.WriteLine(message);

        }
    }
}
