public abstract class Terrain
{
    public double EauTerrain {get;set;}
    public int Numero {get;}
    private static int numeroSuivant = 1;
    public List<Plante> Plants {get; set;}
    private int taille = 5;

    public Terrain (List<Plante> Plants)
    {
        Numero = numeroSuivant;
        numeroSuivant++;
        this.Plants=Plants;
    }

    public void Planter(Plante Semi)
    {

    }

    //Semi.PlaceRequise
    Semi.Espacement
}