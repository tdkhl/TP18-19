namespace TP18
{
    class Program
    {

        // Définition de 2 méthodes pour éviter les répétitions de byte.Parse(...) et short.Parse(..)

        // Short et Byte ont étés utilisés pour réduire le nombre de bits utilisés en mémoire
        public static byte ReadByte() => byte.Parse(Console.ReadLine()!);
        public static short ReadShort() => short.Parse(Console.ReadLine()!);
        static void Main(string[] args)
        {
            Console.Title = "TP18";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**** Calcul prime d'assurance auto ****");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Age du conducteur à assurer : ");
            Clients cl = new Clients();
            cl.SetAge(ReadByte());
            Console.Write("\nAnnée d'obtention du permis : ");
            cl.SetDateObt(ReadShort());
            Console.WriteLine("\nGaranties disponibles :\n1. Tiers\n2. Tiers Confort\n3. Tous risques");
            Console.Write("Saisir la garantie souhaitée : ");
            cl.SetGarantie(ReadByte());
            Console.Write("\nPuissance du véhicule : ");
            cl.SetPower(ReadByte());
            Console.Write("\nCombien de kilomètres prévoyez-vous de faire en une année ? ");
            cl.SetKilometers(ReadShort());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(cl.ToString());

            // On empêche la fenêtre de se fermer
            Console.ReadKey();
        }
    }
}