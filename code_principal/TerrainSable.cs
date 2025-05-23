public class TerrainSable : Terrain
{
    //terrain des jacinthes

    public TerrainSable() : base()
    {
        EauTerrain = 20;
    }


    public override void Semer()
    {
        int ligne1;
        int colonne1;
        int ligne2;
        int colonne2;

        Console.WriteLine("Vous allez choisir les coordonnées de votre jacinthe, elle occupera 2 cases juxtaposées. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne de la 1e case sur laquelle vous souhaitez semer :");
        ligne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 1e case sur laquelle vous souhaitez semer :");
        colonne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la ligne de la 2e case sur laquelle vous souhaitez semer :");
        ligne2 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 2e case sur laquelle vous souhaitez semer :");
        colonne2 = EtreEntier(1,9);
        //vérifier s'il y a la place de planter  et si les cases sont alignées -> if PouvoirPlanter(ligne,colonne)==true
        int[] coord1 = new int [] {ligne1, colonne1};   //tableau des coordonnées de la 1e case
        int[] coord2 = new int [] {ligne2, colonne2};   //tableau des coordonnées de la 2e case
       
        List<int[]> casesChoisies = new List<int[]> { coord1, coord2 };
        if (VerifierAlign(casesChoisies) && PouvoirPlanter(casesChoisies))
        {
            PlanteJacinthe jacinthe = new PlanteJacinthe(casesChoisies);   
            Plants.Add(jacinthe);  
            Console.WriteLine("Vous avez planté une jacinthe !");
        }
        else
        {
            Console.WriteLine("Vous ne pouvez pas planter ici !");
        }       
                
    }

}