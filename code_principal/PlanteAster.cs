public class PlanteAster : Plante
{
    public PlanteAster(List<int[]> coord) : base(coord)
    {
        this.PlaceRequise = 3;
        this.BesoinEau = 11;     //modéré+
        this.EsperanceVie = 12; //en mois 
        this.NbPousses = 10; //1tige florale par bulbe
        ScoreGlobal = EsperanceVie;
        MoisRestant = EsperanceVie;

    }

    public override void ChangerEtat()
    {
        if (ScoreGlobal == 0)
        {
            this.etat = statutPlante.morte;
    
        }
        else if (ScoreGlobal < 3)
        {
            this.etat = statutPlante.mourrante;
        }
        else if (ScoreGlobal < 7)
        {
            this.etat = statutPlante.auTop;
        }
        else if (ScoreGlobal < 12)
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
            Affichage = "🌼";
        }
        else
        {
            Affichage = "🥀";
        }
    }
} 