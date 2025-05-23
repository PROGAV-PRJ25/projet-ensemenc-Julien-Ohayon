public class PlanteTulipe : Plante
{
    public PlanteTulipe(List<int[]> coord) : base(coord)
    {
        this.Nature = "vivace";
        this.Saison = "automne";
        this.TerrainPref = "argile";
        this.PlaceRequise = 1;
        this.Vitesse = 5;   //fleuri 5 mois après la plantation
        this.BesoinEau = 10;     //modéré
        this.BesoinLumi = 100;     //plein soleil
        this.TempMin = 10;
        this.TempMax = 18;
        this.Maladies = new List<string> {"botrytis", "pourriture grise", "virus de la mosaïque"};
        this.EsperanceVie = 60;     //en mois
        this.NbPousses = 1; //1tige florale par bulbe

    }

    public override void ChangerEtat()
    {
        if (ScoreGlobal == 0)
        {
            this.etat = statutPlante.morte;
            //Enlever plante la fonction 
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
