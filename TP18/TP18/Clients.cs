using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP18
{
    class Clients
    {
        // On définit plusieurs champs privés qui nous servirons pour certains calculs / exceptions.
        // Le champ prime n'est pas défini pour l'instant mais on peut imaginer qu'il le serait dans le futur
        private byte ageConducteur;
        private short dateObtention;
        private byte garantie;
        private byte power;
        private short km;
        private bool nvlVoiture;
        private float prime = 0;

        // Méthodes pour modifier les champs privés en sureté
        public void SetAge(byte age)
        {
            // Gestion d'erreurs..
            if(age < 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Nous n'assurons pas les moins de 20 ans ", "Age du conducteur");
            }
            ageConducteur = age;
        }

        public void SetDateObt(short annee)
        {
            // Gestion d'erreurs..
            if (DateTime.Now.Year - annee < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Nous n'assurons pas les jeunes conducteurs ", "Année d'obtention du permis");
            }
            dateObtention = annee;
        }

        public void SetGarantie(byte garant)
        {
            // Gestion d'erreurs..
            if (garant < 1 || garant > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Type de garantie invalide", "Type de garantie");
            }
            switch(garant)
            {
                case 1:
                    garantie = 70;
                    break;
                case 2:
                    garantie = 85;
                    break;
                case 3:
                    garantie = 100;
                    break;
            }         
        }

        public void SetPower(byte pow)
        {
            power = pow;
        }

        public void SetKilometers(short kilometers)
        {
            if(kilometers <= 3000)
            {
                Console.Write("\nAnnée de 1er mise en circulation : ");
                short rep = Convert.ToInt16(Console.ReadLine());
                if(DateTime.Now.Year - rep < 5)
                {
                    nvlVoiture = true;
                }

            }
            km = kilometers;
        }

        // Methode publique pour calculer le montant de la prime, affecter sa valeur au champ privé et la retourner
        public float GetPrimeAmount()
        {
            float Prime = 0;
            if(km <= 3000)
            {
                if(nvlVoiture)
                {
                    Prime = (power * garantie) * 0.70f;
                }
                else
                {
                    Prime = (power * garantie) * 0.75f;
                }
                
            }
            else if(km <= 5000)
            {
                Prime = (power * garantie) * 0.75f;
            }
            else if(km <= 7000)
            {
                
                Console.Write("\nUtilisez-vous votre véhicule pour aller au travail (O/N) ? : ");
                if(Console.ReadLine()!.ToUpper() == "O")
                {
                    Prime = (power * garantie) * 1.05f;
                }
                else
                {
                    Prime = (power * garantie) * 0.85f;
                }
            }
            prime = Prime;
            return Prime;
        }

        // Ici on override le ToString pour pouvoir afficher notre prime d'assurance plus facilement
        public override string ToString()
        {
            if(prime == 0)
            {
                GetPrimeAmount();
            }
            return $"Votre prime d'assurance est de : {prime} euros.";
        }

    }
}
