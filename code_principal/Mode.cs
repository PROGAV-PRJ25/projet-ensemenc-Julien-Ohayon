public abstract class Mode
{
    public enum ObsBF   //les obstacles et les bonnes fées 
    {
        //bonnes fées
        VerDeTerre,
        Abeille,

        //Obstacles
        Pietineur,
        Oiseaux,

        //Obstacles urgence
        Tempête, 
        MaladieGrave

    }

    public ObsBF ObsBFActif { get; set; }

    public enum Evenement
    {
        Urgence, Classique
    }
    public static Random rnd = new Random();

    public static Evenement evenementActuel = Evenement.Classique;  //au départ on est dans le mode classique

    public Mode(){ }    // constructeur

    public abstract void Simuler(List<Terrain> terrains);

    protected Terrain ChoisirAleaTerrain(List<Terrain> terrains)   //choisit aléatoirement un terrain parmi une liste de terrains
    {

        int nbrTerrains = terrains.Count; 
        int numAlea = rnd.Next(1, nbrTerrains + 1);
        Terrain? terrainTrouve = null;
        foreach (Terrain t in terrains)
            {
                if (t.Numero == numAlea)
                {
                    terrainTrouve = t;
                }
            }
        return terrainTrouve!;   //jamais null car on a implémenté le numéro des terrains à partir de t1
    }
}