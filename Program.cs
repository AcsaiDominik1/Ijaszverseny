namespace Ijaszverseny
{
    internal class Program
    {
        static int[,] players;
        static Random r = new Random();

        static string[] JatekosokNevei(int jatekosokSzama)
        {
            string[] nevek = { "Anna", "Bence", "Csaba", "Dóra", "Eszter", "Ferenc", "Gábor", "Hanna", "István", "Judit", "Katalin", "László", "Márk", "Nóra", "Orsolya", "Péter", "Réka", "Sándor", "Tamás", "Viktória", "Zoltán", "Ádám", "Balázs", "Cecília", "Dávid", "Emese", "Flóra", "György", "Levente", "Mihály" };
            string[] jatekosok = new string[jatekosokSzama];
            for (int i = 0; i < jatekosokSzama; i++)
            {
                int index = r.Next(0, nevek.Length);
                jatekosok[i] = nevek[index];
            }
            return jatekosok;
        }

        static int[,] Feltoltes(int jatekosokSzama)
        {
            int[,] matrix = new int[jatekosokSzama, 5];
            for (int i = 0; i < jatekosokSzama; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = r.Next(0, 26);
                }
            }
            return matrix;
        }

        static void Gyoztes(string[] jatekosok, int jatekosokSzama)
        {
            int[] osszPontok = new int[jatekosokSzama]; 
            for (int i = 0; i < players.GetLength(0); i++)
            {
                int osszeg = 0;
                for (int j = 0; j < players.GetLength(1); j++)
                {
                    osszeg += players[i, j];
                }
                osszPontok[i] = osszeg;
            }

            int max = 0;
            int maxIndex = 0;
            int winnersNumber = 0;
            for (int i = 0; i < osszPontok.Length; i++)
            {
                if (max <  osszPontok[i])
                {
                    max = osszPontok[i];
                    maxIndex = i;
                }
            }

            for (int i = 0; i < osszPontok.Length; i++)
            {
                if (max == osszPontok[i])
                {
                    winnersNumber++;
                }
            }

            if (winnersNumber == 0 || winnersNumber == 1)
            {
                Console.WriteLine("A verseny győztese: " + jatekosok[maxIndex] + ", " + osszPontok[maxIndex] + " pontal.");
            } else
            {
                int index = 1;
                for (int i = 0; i < osszPontok.Length; i++)
                {
                    if (max == osszPontok[i])
                    {
                        Console.WriteLine($"A(z) {index}. győztes: {jatekosok[i]}, {osszPontok[i]} pontal.");
                        index++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Játékosok száma: ");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());

            players = Feltoltes(jatekosokSzama);
            string[] jatekosok = JatekosokNevei(jatekosokSzama);

            for (int i = 0; i < players.GetLength(0); i++)
            {
                Console.Write($"A(z) {i + 1, 2}. játékos: {jatekosok[i], -8}\t pontjai: ");
                int osszeg = 0;
                for (int j = 0; j < players.GetLength(1); j++)
                {
                    osszeg += players[i, j];
                    Console.Write($"{players[i, j],4}");
                }
                Console.Write("\t = " + osszeg + " pont");
                Console.WriteLine();
            }
            Gyoztes(jatekosok, jatekosokSzama);
        }
    }
}
