public abstract class Terrain
{
    public double EauTerrain {get;set;}
    public int Numero {get;}
    private static int numeroSuivant = 1;
    public List<Plante> Plants {get; set;}
    public string[,] tableau;
    public int taille;

    public Terrain (List<Plante> Plants)
    {
        taille = 5;
        tableau = new string[taille, taille];
        Numero = numeroSuivant;
        numeroSuivant++;
        this.Plants=Plants;
        for (int i = 0; i < taille; i++)
        {
            for (int j = 0; j < taille; j++)
            {
                tableau[i, j] = "+";
            }
        }
    }
    
    public void Afficher()
    {
        Console.WriteLine($"\nTerrain : {Numero}\n");
            for(int i=0;i<taille;i++)
            {
                for (int j=0;j<taille;j++)
                {
                    if (tableau[i,j]=="+" || tableau[i,j]==" ")
                    {
                        Console.Write($" {tableau[i,j]} ");
                    }
                    else
                    Console.Write($"{tableau[i,j]} ");
                }
                Console.Write("");
                Console.WriteLine();
            }
    }

    /*public bool VerifierEspace(int x, int y, int espacement)
    {
        bool place= true;
        for(int esp=1;esp<=espacement;esp++)
        {
            if (i-esp>=0)
            {
                if(tableau[])
            }

        }
        return place;
    }

    public bool PouvoirPlanter(Semi.)
    {
        int place=0;
        int espace=0;
        
        
        for(int i=1;i<taille;i++)       //vérifier si on peut planter par ligne
        {
            for(int j=1;j<taille;j++)
            {
                while (place!=Semi.PlaceRequise && espace!=Semi.PlaceRequise)
                {
                    if(tableau[i,j]==".")
                    {
                        place+=1;
                        if(VerifierEspace(i,j,Semi.Espacement)==true)
                        espace+=1;
                        else
                        espace=0;
                    }
                    else
                    place=0;
                }
            }
        }
    }
*/

    public int EtreEntier(int min, int max)  //pour vérifier que l'utilisateur entre les coordonnées d'une case qui existe, adapter min et max selon la taille de nos terrains
    {
        bool nombreOk = false;
        string stringNombre;
        int nombre;
        bool validation = true;

        do  //test si le nombre est compris entre les valeurs souhaitées
        {
            do  //test si l'utilisateur entre un entier
            {
                if (validation == false)
                {
                    Console.WriteLine("Erreur : réessayez");
                }
                Console.WriteLine($"Entrez un nombre entier compris entre {min} et {max} :");
                stringNombre = Console.ReadLine()!;
                nombreOk = int.TryParse(stringNombre, out int numericValue);
                validation = false;
            }
            while (nombreOk == false);
            nombre = Convert.ToInt32(stringNombre);
        }
        while (nombre < min || nombre > max);
        return nombre;
    }

    //vérifie qu'il y a assez de place pour planter sur la case sélectionnée par le joueur, et qu'on est à la bonne saison 
    //virtual car vérifie que les cases soient juxtaposées si le joueur en entre plusieurs
     
    public virtual bool PouvoirPlanter(List<int[]> cases)      //fonction à déplacer dans terrain
    {
        bool planter = false;
        bool dispo = true;
        bool espaceHaut = true;
        bool espaceBas = true;
        bool espaceGauche = true;
        bool espaceDroite = true;


        foreach (int[] elem in cases)
        {
            //on regarde chaque case de la liste, et si c'est pas un plus sur le terrain, elle n'est pas dispo donc false
            if (tableau[elem[0], elem[1]] != "+")
            {
                dispo = false;
            }

            //si dispo false, pas besoin de regarder l'espacement : soit on parcourt une fois la liste, soit 2

            //on regarde si la case en dessous existe, puis si elle est libre 
            if (elem[0] + Plante.espacement < taille)
            {
                if (tableau[elem[0] + Plante.espacement, elem[1]] != "+") //(ou x si on les met ensuite)
                {
                    espaceBas = false;
                }
            }

            //on regarde si la case au dessus existe, puis si elle est libre 
            if (elem[0] - Plante.espacement >= 0)
            {
                if (tableau[elem[0] - Plante.espacement, elem[1]] != "+") //(ou x si on les met ensuite)
                {
                    espaceHaut = false;
                }
            }

            //on regarde si la case à droite existe, puis si elle est libre 
            if (elem[1] + Plante.espacement < taille)
            {
                if (tableau[elem[0], elem[1] + Plante.espacement] != "+") //(ou x si on les met ensuite)
                {
                    espaceDroite = false;
                }
            }

            //on regarde si la case à gauche existe, puis si elle est libre 
            if (elem[1] - Plante.espacement >= 0)
            {
                if (tableau[elem[0], elem[1] - Plante.espacement] != "+") //(ou x si on les met ensuite)
                {
                    espaceGauche = false;
                }
            }
        }

        //pour voir si elles sont bien côte à côte, on regarde si toutes les lignes ou (exclusif) toutes les colonnes sont les mêmes et si leurs numéros se suivent

        if (dispo && espaceHaut && espaceBas && espaceGauche && espaceDroite) //on plante si la place requise et l'espacement sont vérifiés
        {
            planter = true;
        }

        return planter;
    }
    public abstract void Semer();      //comment gérer la place requise ? 

    public abstract void Fertiliser()
    {
        Console.WriteLine("Grâce aux vers de terre, votre terrain va être fertilisé !");
    }


    //fonctions abstract des bonnes fees
    public abstract void Fleurir()
    {
        Console.WriteLine("Grâce aux abeilles, votre terrain va fleurir"):
    }

    public abstract void Assainir()
    {
        Console.WriteLine("Grâce aux hérissons, votre terrain est assaini !");
    }

    //fonction abstract des obstacles
    public abstract void DetruirePlante()
    {
        Console.WriteLine("A cause de piétineurs, une partie de vos plantes sont écrasées..."):
        //faire un random sur la liste de plante et supprimer plus ou moins de plantes
    }

    public abstract void Deranger()
    {
        Console.WriteLine("A cause des taupes, votre terrain a été dérangé...");
        //en fonction du terrain ça dérange plus ou moins
    }

    public abstract void MangerGraine()
    {
        Console.WriteLine("A cause des taupes, votre terrain a été dérangé...");
        //manger les plantes qui viennent d'être semées le mois dernier
    }

}