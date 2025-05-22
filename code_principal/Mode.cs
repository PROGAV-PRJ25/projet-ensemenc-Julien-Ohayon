public abstract class Mode
{
    public enum ObsBF
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
    public static Evenement evenementActuel = Evenement.Classique;  //au départ on est dans le mode classique
    
    public enum ActionsUrgence
    {
        Serre = 1, PotionMagique = 2
    }

    public Mode(){ }

    public static readonly Random rnd = new Random();  //à voir la déf de readonly

    public abstract void Simuler(List<Terrain> terrains);

    public Terrain ChoisirAleaTerrain(List<Terrain> terrains)
    {

        int nbrTerrains = terrains.Count;       //choisi aléatoire du terrain sur lequel va être l'obstacle ou la bonne fée
        int numAlea = rnd.Next(1, nbrTerrains + 1);
        Terrain terrainTrouve = null;
        foreach (Terrain t in terrains)
        {
            if (t.Numero == numAlea)
            {
                terrainTrouve = t;
            }
        }
        return terrainTrouve;   //jamais null car on a implémenté le numéro des terrains à partir de t1
    }
}