public abstract class Mode
{
   
    public string ObsBFActif{get;set;}      //l'obstacle ou la bonne fée active 
    public enum Evenement  
    {
        Urgence, Classique
    }
    public static Evenement evenementActuel = Evenement.Classique;  //au départ on est dans le mode classique
    protected enum Obstacles
    {
        Pietineur=1, Taupe=2, Oiseaux=3
    }
    protected enum ObstaclesUrgence
    {
        Grele=1, Tempete=2, MaladieGrave=3 
    }
    protected enum ActionsUrgence
    {
        Serre=1, Epouventail+2, PotionMagique=3
    }
    protected enum BonnesFees
    {
        VerDeTerre = 1, Abeille = 2, Hérisson = 3
    }
    //actions classique ?? 
    public Mode()
    {
        ObsBFActif = "";
    }

    public abstract void Simuler(List<Terrain> terrains);
}