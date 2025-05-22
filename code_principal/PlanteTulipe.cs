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
        this.Maladies = new List<string> { "botrytis", "pourriture grise", "virus de la mosaïque" };
        this.EsperanceVie = 5;
        this.NbPousses = 1; //1tige florale par bulbe

    }

    public override void ChangerAffichage()
    {
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
