public abstract class Plante
{
    public List<int[]> CoordPlante { get; set; }
    public string? Affichage { get; set; }
    public static int espacement = 1;
    public int PlaceRequise {get;set;}
    public int NbPousses { get; set; }
    public int BesoinEau { get; set; }
    public int EsperanceVie {get;set;}  //du plant, en années

    public double ScoreGlobal { get; set; }     
    public int MoisRestant { get; set; }
    public enum statutPlante
    {
        graine, jeunePousse, auTop, mourrante, morte
    }

    public statutPlante etat = statutPlante.graine;     //toujours une graine au début

    public Plante(List<int[]> coord)
    {
        this.CoordPlante = coord;
    }

    public abstract void ChangerAffichage();  

    public abstract void ChangerEtat();

   
}
