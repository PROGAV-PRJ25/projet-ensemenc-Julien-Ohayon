public class PlanteAster : Plante
{
    public PlanteAster(List<int[]> coord) : base(coord)
    {

        this.Nature = "annuelle";
        this.Saison = "printemps";
        this.TerrainPref = "terre";
        this.PlaceRequise = 3;
        this.Vitesse = 5;   //fleuri 5 mois après la plantation
        this.BesoinEau = 11;     //modéré+
        this.BesoinLumi = 75;     //soleil à mi-ombre
        this.TempMin = 15;
        this.TempMax = 25;
        this.Maladies = new List<string> { "oïdium", "pourriture", "rouille" };
        this.EsperanceVie = 1;
        this.NbPousses = 10; //1tige florale par bulbe

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
            Affichage = "🌼";
        }
        else
        {
            Affichage = "🥀";
        }
    }
} 