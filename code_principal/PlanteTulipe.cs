public class PlanteTulipe : Plante
{
    public PlanteTulipe(List<int[]> coord) : base(coord)
    {
        this.PlaceRequise = 1;
        this.BesoinEau = 10;     //modéré
        this.EsperanceVie = 60;     //en mois
        this.NbPousses = 1; //1tige florale par bulbe
        ScoreGlobal = EsperanceVie;
        MoisRestant = EsperanceVie;

    }

    public override void ChangerEtat()
    {
        if (ScoreGlobal == 0)
        {
            this.etat = statutPlante.morte;
    
        }
        else if (ScoreGlobal < 13)
        {
            this.etat = statutPlante.mourrante;
        }
        else if (ScoreGlobal < 38)
        {
            this.etat = statutPlante.auTop;
        }
        else if (ScoreGlobal < 53)
        {
            this.etat = statutPlante.jeunePousse;
        }
        else
        {
            this.etat = statutPlante.graine;
        }
    }
    public override void ChangerAffichage()
    {
        ChangerEtat();
        if (this.etat == statutPlante.graine)
        {
            Affichage = "🟢";
        }
        else if (this.etat == statutPlante.jeunePousse)
        {
            Affichage = "🌱";
        }
        else if (this.etat == statutPlante.auTop)
        {
            Affichage = "🌷";
        }
        else
        {
            Affichage = "🥀";
        }
    }
} 
