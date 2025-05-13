public abstract class Terrain
{
    public double EauTerrain {get;set;}
    public int Numero {get;}
    private static int numeroSuivant = 1;
    public List<Plante> Plants {get; set;}
    private static int taille;
    public string [,] Tableau {get;set;}

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


    public void Planter(Plante Semi)
    {
        if(PouvoirPlanter==true)
        
        tableau
    }

    Semi.PlaceRequise
    */
}