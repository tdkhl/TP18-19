namespace TP19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Jeu du Nombre Mystère";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Jeu du nombre mystère : vous devez trouver un nombre compris entre 0 et 10\n (en 3 essais maximum).");
            Random rdm = new Random();
            byte goal = Convert.ToByte(rdm.Next(10));
            byte essais = 0;
            bool found = false;
            // Une boucle do-while aurait été + opti
            while(essais < 3)
            {
                Console.Write($"Essai n°{essais.ToString()} : ");
                byte answ = byte.Parse(Console.ReadLine()!);
                if(answ == goal)
                {
                    if(essais == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Félicitation, vous avez trouvé du premier coup !");
                        found = true;
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Félicitation, vous avez trouvé le nombre mystère.");
                    found = true;
                    break;
                }
                else
                {
                    if(answ > goal)
                    {
                        Console.WriteLine("Le nombre mystère est plus petit");
                    }
                    else
                    {
                        Console.WriteLine("Le nombre mystère est plus grand");
                    }
                }
                essais++;
            }
            if(!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dommage le nombre mystère était : {goal.ToString()}");
            }

            // On empêche la fenêtre de se fermer..
            Console.ReadKey();

        }
    }
}
