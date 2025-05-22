public class TerrainArgile : Terrain
{
    //terrain des tulipes
    public TerrainArgile(List<Plante> Plants) : base(Plants)
    {
        EauTerrain = 80;
    }

    
    public override void Semer()
    {
        int ligne;
        int colonne;
        Console.WriteLine("Vous allez choisir les coordonnées de votre plante, elle occupera 1 case. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne sur laquelle vous souhaitez semer :");
        ligne = EtreEntier(1, 9);
        Console.WriteLine("Choisissez le numéro de la colonne sur laquelle vous souhaitez semer :");
        colonne = EtreEntier(1, 9);

        //vérifier s'il y a la place de planter -> if PouvoirPlanter(ligne,colonne)==true
        int[] coord = new int[] { ligne, colonne };
        PlanteTulipe tulipe = new PlanteTulipe(new List<int[]> { coord });


    }

    
}        