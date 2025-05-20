public class TerrainSable : Terrain
{

    public TerrainSable (List<Plante> Plants) : base(Plants)
    {
        EauTerrain = 20;
    }

        public override bool PouvoirPlanter(List<int[]> cases)
    {
        bool planter = false;
        bool aligne = false;
        bool dispo = true;
        bool espace = true;
        int ligneComp = (cases[0])[0];  //on prend la ligne de la 1e case pour comparer les suivantes
        int colonneComp = (cases[0])[1];    //on prend la colonne de la 1e case pour comparer les suivantes

        foreach(int[] elem in cases)
        {

        }


        
        foreach (int[] elem in cases)
        {
            if(tableau[elem[0],elem[1]]!=".")   //on regarde chaque case de la liste, et si c'est pas un point sur le terrain, elle n'est pas dispo donc false
            {
                dispo = false;
            }
        }

        if(dispo && espace) //on plante si la place requise et l'espacement sont vérifiés
        {
            planter = true;
        }
        
        return planter;

    }

    public override void Semer()
    {
        int ligne1;
        int colonne1;
        int ligne2;
        int colonne2;

        Console.WriteLine("Vous allez choisir les coordonnées de votre plante, elle occupera 2 cases juxtaposées. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne de la 1e case sur laquelle vous souhaitez semer :");
        ligne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 1e case sur laquelle vous souhaitez semer :");
        colonne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la ligne de la 2e case sur laquelle vous souhaitez semer :");
        ligne2 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 2e case sur laquelle vous souhaitez semer :");
        colonne2 = EtreEntier(1,9);
        //vérifier s'il y a la place de planter -> if PouvoirPlanter(ligne,colonne)==true
        int[] coord1 = new int [] {ligne1, colonne1};   //tableau des coordonnées de la 1e case
        int[] coord2 = new int [] {ligne2, colonne2};   //tableau des coordonnées de la 2e case
        PlanteJacinthe jacinthe = new PlanteJacinthe(new List<int[]> {coord1, coord2});     //voir comment on les cueille car est sur plusieurs cases
                
    }

}