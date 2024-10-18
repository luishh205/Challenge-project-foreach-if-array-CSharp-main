using System;

namespace AppZoologico
{
    class Program
    {
        static string[] pettingZoo =
        {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",

        }

        public static void Main(string[] args)
        {
            // Planejar as visitas das escolas
            PlanSchoolVisit("School A");
            PlanSchoolVisit("School B", 3);
            PlanSchoolVisit("School C", 2);
        }

        static void PlanSchoolVisit(string schoolName, int groups = 6)
        {
            // Embaralhar os animais
            RandomizeAnimals();

            // Atribuir os grupos
            string[,] group1 = AssignGroup(groups);

            // Exibir o nome da escola e os grupos de animais
            Console.WriteLine(schoolName);
            PrintGroup(group1);
        }

        static void RandomizeAnimals()
        {
            Random random = new Random();

            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int r = random.Next(i, pettingZoo.Length);

                string temp = pettingZoo[r];
                pettingZoo[r] = pettingZoo[i];
                pettingZoo[i] = temp;
            }
        }

        static string[,] AssignGroup(int groups = 6)
        {
            int groupSize = pettingZoo.Length / groups;
            string[,] result = new string[groups, groupSize];
            int start = 0;

            for (int i = 0; i < groups; i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = pettingZoo[start++];
                }
            }

            return result;
        }

        static void PrintGroup(string[,] groups)
        {
            for (int i = 0; i < groups.GetLength(0); i++)
            {
                Console.Write($"Group {i + 1}: ");
                for (int j = 0; j < groups.GetLength(1); j++)
                {
                    Console.Write($"{groups[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
    }
}
    