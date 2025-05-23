public class TerrainArgile : Terrain
{
    //terrain des tulipes
    public TerrainArgile() : base()
    {
        EauTerrain = 80;
    }
    
    //on ne peut planter que des tulipes, qui prennent qu'une seule case donc toutes les cases entrées par l'utilisateur sont forcément alignées
    public override bool VerifierAlign(List<int[]> cases)
    {
        return true;
    }
    public override void Semer()
    {
        int ligne;
        int colonne;
        Console.WriteLine("Vous allez choisir les coordonnées de votre tulipe, elle occupera 1 case. Choisissez bien !");
        Console.WriteLine("Choisissez le numéro de la ligne sur laquelle vous souhaitez semer :");
        ligne = EtreEntier(1, 9);
        Console.WriteLine("Choisissez le numéro de la colonne sur laquelle vous souhaitez semer :");
        colonne = EtreEntier(1, 9);


        int[] coord = new int[] { ligne, colonne };
        List<int[]> casesChoisies = new List<int[]> { coord };
        if (VerifierAlign(casesChoisies) && PouvoirPlanter(casesChoisies))
        {
            PlanteTulipe tulipe = new PlanteTulipe(casesChoisies);
            Plants.Add(tulipe);
            Console.WriteLine("Vous avez planté une tulipe !");
        }
        else
        {
            Console.WriteLine("Vous ne pouvez pas planter ici !");
        }


    }

    
}        