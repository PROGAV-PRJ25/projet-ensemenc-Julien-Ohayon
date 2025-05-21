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

    public abstract bool PouvoirPlanter(List<int[]> cases);      //vérifie qu'il y a assez de place pour planter sur la case sélectionnée par le joueur, et qu'on est à la bonne saison 
    //case dispo si point 
        //pour voir si elles sont bien côte à côte, on regarde si toutes les lignes ou (exclusif) toutes les colonnes sont les mêmes et si leurs numéros se suivent
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