public abstract class Terrain
{
    public double EauTerrain {get;set;}
    public int Numero {get;}
    private static int numeroSuivant = 1;
    public List<Plante> Plants {get; set;}
    private static int taille = 5;      //doit être static pour faire un tableau avec ces dimensions
    public string [,] tableau = new string [taille,taille];

    public Terrain (List<Plante> Plants)
    {
        taille = 5;
        this.Tableau = new string [taille,taille];
        Numero = numeroSuivant;
        numeroSuivant++;
        this.Plants=Plants;
        for(int i=0;i<taille;i++)
        {
            for(int j=0;j<taille;j++)
            {
                Tableau[i,j]="+";
            }
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

    public int EtreEntier(int min,int max)  //pour vérifier que l'utilisateur entre les coordonnées d'une case qui existe, adapter min et max selon la taille de nos terrains
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
        while (nombre<min || nombre>max);
        return nombre;
    } 

    public abstract bool PouvoirPlanter(List<int[]> cases);      //vérifie qu'il y a assez de place pour planter sur la case sélectionnée par le joueur, et qu'on est à la bonne saison 
    //case dispo si point 
        //pour voir si elles sont bien côte à côte, on regarde si toutes les lignes ou (exclusif) toutes les colonnes sont les mêmes et si leurs numéros se suivent
    public abstract void Semer();      //comment gérer la place requise ?        

    
    



}