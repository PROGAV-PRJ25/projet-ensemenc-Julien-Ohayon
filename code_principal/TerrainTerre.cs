public class TerrainTerre : Terrain
{
    //terrain des asters
    public TerrainTerre() : base()
    {
        EauTerrain = 50;
    }

    public override void Semer()
    {
        int ligne1;
        int colonne1;
        int ligne2;
        int colonne2;
        int ligne3;
        int colonne3;

        Console.WriteLine("Vous allez choisir les coordonnées de votre aster, elle occupera 3 cases juxtaposées. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne de la 1e case sur laquelle vous souhaitez semer :");
        ligne1 = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la colonne de la 1e case sur laquelle vous souhaitez semer :");
        colonne1 = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la ligne de la 2e case sur laquelle vous souhaitez semer :");
        ligne2 = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la colonne de la 2e case sur laquelle vous souhaitez semer :");
        colonne2 = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la ligne de la 3e case sur laquelle vous souhaitez semer :");
        ligne3 = EtreEntier(1, Taille);
        Console.WriteLine("Choisissez le numéro de la colonne de la 3e case sur laquelle vous souhaitez semer :");
        colonne3 = EtreEntier(1, Taille);

        int[] coord1 = new int[] { ligne1 - 1, colonne1 - 1 };   //tableau des coordonnées de la 1e case
        int[] coord2 = new int[] { ligne2 - 1, colonne2 - 1};   //tableau des coordonnées de la 2e case
        int[] coord3 = new int[] { ligne3 - 1, colonne3 - 1};   //tableau des coordonnées de la 3e case

        List<int[]> casesChoisies = new List<int[]> { coord1, coord2, coord3 };
        if (VerifierAlign(casesChoisies) && PouvoirPlanter(casesChoisies))
        {
            PlanteAster aster = new PlanteAster(casesChoisies);
            Plants.Add(aster);
            Console.WriteLine("Vous avez planté un aster !");
        }
        else
        {
            Console.WriteLine("Vous ne pouvez pas planter ici !");
        }

    }
    
        public override void Fleurir()
        {
            foreach (Plante p in Plants)
            {
                p.ScoreGlobal = 6;     // toutes les plantes passent au score haut de "au top"
            }
            
        }
}