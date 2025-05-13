public abstract class Mode
{
   
    public string ObsBF{get;set;}
    public enum Evenement
    {
        Urgence, Classique
    }
    public static Evenement evenementActuel;
    public enum Obstacles
    {
        Pietineur=1, Taupe=2, Oiseaux=3
    }
    public enum ObstaclesUrgence
    {
        Grele=1, Tempete=2, MaladieGrave=3 
    }
    public enum BonnesFees
    {
        VerDeTerre=1, Abeille=2, Hérisson=3
    }
    public Mode()
    {
        evenementActuel=Evenement.Classique;
        ObsBF="";
    }

    public abstract void Simuler();
}