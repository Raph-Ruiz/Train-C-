using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Joueur j1 = new Joueur();
            Joueur j2 = new Joueur();


            j1.setnom("Raph");
            j2.setnom("Jerem");

            string j1name = j1.getnom();
            string j2name = j2.getnom(); 

            int nb_tours = 0;
            while (true)
            {
                nb_tours++;
                j1.afficher();
                j2.afficher();
                Console.WriteLine("Tour n° " + nb_tours + " :");

                //TOUR DES JOUEUR 
                Console.WriteLine("C'est à votre tour\n");
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1 : Attaque");
                Console.WriteLine("2 : Soin");
                Console.WriteLine("3 : Contre-attaque");


                //CHOIX DES JOUEURS
                Console.WriteLine("\n Le joueur "+ j1name + " choisi : ");
                string Choix = Console.ReadLine();
                Console.WriteLine("\n Le Joueur " +j2name + " choisi : ");
                string Choix2 = Console.ReadLine();

                // SI je n'arrive pas a faire 2 joueur
                // Choix de l'ennemi
                // int Choix2 = new Random().Next(1, 3);


                if (Choix == "2")
                {
                    Console.WriteLine("Le Joueur "+ j1name +" se soigne.");
                    j1.soigner();
                }
                if (Choix2 == "2")
                {
                    Console.WriteLine("Le Joueur "+ j2name  +" se soigne.");
                    j2.soigner();
                }

                // Atq du J1
                if (Choix == "1") 
                {
                    Console.WriteLine(j1name + " attaque !");
                    if (Choix2 == "3") // Contre attaque du J2
                    {
                        Console.WriteLine("Mais " + j2name + " contre-attaque.");
                        j2.contratq(j1);
                    }
                    else
                    {
                        j1.attaque(j2);
                    }
                }

                // Atq du J2
                if (Choix2 == "1") 
                {
                    Console.WriteLine(j2name + " attaque !");
                    if (Choix == "3") // Contre attaque du J1
                    {
                        Console.WriteLine("Mais " + j1name + " contre-attaque.");
                        j1.contratq(j2);
                    }
                    else
                    {
                        j2.attaque(j1);
                    }
                }

                // Contre attaque inefficace
                if (Choix == "3" && Choix2 != "1")
                {
                    Console.WriteLine(j1name +" contre-attaque !");
                    Console.WriteLine("Mais c'est inefficace\n");
                    j1.pv -= j1.coutca;
                    Console.WriteLine(j1name + " perd " + j1.coutca + " pv");
                }

                if (Choix2 == "3" && Choix != "1")
                {
                    Console.WriteLine(j2name + " contre-attaque !");
                    Console.WriteLine("Mais c'est inefficace\n");
                    j2.pv -= j2.coutca;
                    Console.WriteLine(j2name + " perd " + j2.coutca + " pv");
                }

                // FIN DE PARTIE
                if (j1.pv <= 0)
                {
                    Console.WriteLine(j2name + " a gagné !");
                    break;
                }

                if (j2.pv <= 0)
                {
                    Console.WriteLine(j1name + " a gagné !");
                    break;
                }

            }






            Console.WriteLine("Merci d'avoir joué!");
            Console.Write("Appuyez sur n'importe quelle touche pour finir\n");
            Console.ReadKey(true);
        }


        class Joueur
        {
            public int pv = 30;      //PV de base
            private string nom = ""; 
            public int coutca = 5;   //Cout en PV de la contre-attaque


            //SOIN
            public void soigner()
            {
                Random r = new Random();
                int soin = r.Next(5, 10);
                Console.WriteLine(soin);
                this.pv = pv + soin;
                Console.WriteLine("Le joueur "+this.nom +" a " +pv +" points de vie");
            }
            public void setnom(string n)
            {
                this.nom = n;

            }
            public string getnom()
            {
                return this.nom;
            }

            public void afficher()
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Le Joueur " + this.nom + " a " + pv + " pv.\n");              
            }

            // ATTAQUE
            public void attaque(Joueur x)
            {
                Random i = new Random();
                int atq = i.Next(0, 15);
                Console.WriteLine(atq);
                x.pv = x.pv - atq;
                Console.WriteLine("Le Joueur " + this.nom +" a infligé " + atq + " point de dégats\n");
            }

            // CONTRE-ATTAQUE
            public void contratq(Joueur x)
            {
                Random z = new Random();
                int catq = z.Next(3, 10);
                Console.WriteLine(catq);
                x.pv = x.pv - catq;
                Console.WriteLine("Le Joueur " + this.nom + " a infligé " + catq + " point de dégats\n");
            }



        }
        }




    }

