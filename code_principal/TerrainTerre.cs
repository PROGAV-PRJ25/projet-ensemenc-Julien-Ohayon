public class TerrainTerre : Terrain
{
    //terrain des asters
    public TerrainTerre () : base()
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

        Console.WriteLine("Vous allez choisir les coordonnées de votre plante, elle occupera 3 cases juxtaposées. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne de la 1e case sur laquelle vous souhaitez semer :");
        ligne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 1e case sur laquelle vous souhaitez semer :");
        colonne1 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la ligne de la 2e case sur laquelle vous souhaitez semer :");
        ligne2 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 2e case sur laquelle vous souhaitez semer :");
        colonne2 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la ligne de la 3e case sur laquelle vous souhaitez semer :");
        ligne3 = EtreEntier(1,9);
        Console.WriteLine("Choisissez le numéro de la colonne de la 3e case sur laquelle vous souhaitez semer :");
        colonne3 = EtreEntier(1,9);

        //vérifier s'il y a la place de planter -> if PouvoirPlanter(ligne,colonne)==true
        int[] coord1 = new int [] {ligne1, colonne1};   //tableau des coordonnées de la 1e case
        int[] coord2 = new int [] {ligne2, colonne2};   //tableau des coordonnées de la 2e case
        int[] coord3 = new int [] {ligne3, colonne3};   //tableau des coordonnées de la 3e case

        PlanteAster aster = new PlanteAster(new List<int[]> {coord1, coord2,coord3});     //voir comment on les cueille car est sur plusieurs cases
                
    }
}