public abstract class Terrain
{
    public string TypeTerrain {get;}
    public double EauTerrain {get;set;}
    public int Numero {get;}
    private static int numeroSuivant = 1;

    public Terrain (string TypeTerrain, double EauTerrain)
    {
        this.TypeTerrain=TypeTerrain;
        this.EauTerrain=EauTerrain;
        Numero = numeroSuivant;
        numeroSuivant++;
    }


}